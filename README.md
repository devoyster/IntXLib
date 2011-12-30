IntX
====

IntX is an arbitrary precision integers library written in pure C# 2.0 with fast -- about O(N * log N) -- multiplication/division algorithms implementation. It provides all the basic arithmetic operations on integers, comparing, bitwise shifting etc. It also allows parsing numbers in different bases and converting them to string, also in any base. The advantage of this library is fast multiplication, division and from base/to base conversion algorithms -- all the fast versions of the algorithms are based on fast multiplication of big integers using Fast Hartley Transform which runs for O(N * log N * log log N) time instead of classic O(N^2).

You can [download IntX from NuGet](http://nuget.org/packages/IntX).

Bits of History
---------------

I have written IntX basically because I like big numbers and had some free time. Initial implementation was standard -- I was using standard big integers +, -, *, / algorithms from Khuth book. After library was written I've decided to participate in contest held by [GotDotNet.ru](http://gotdotnet.ru/) and received some replies which were saying that my library is too ... usual. Well, it was true, so I've decided to implement some more interesting algorithms in it.

I've started with writing multiplication using [Fast Hartley Transform](http://en.wikipedia.org/wiki/Discrete_Hartley_transform) so big integers multiplication time estimate became to be O(N * log N * log log N) (here N is amount of DWORDs in number representation) which was a bit better then O(N^2) with classic algorithm :) Then I saw fast algorithm for transforming from one base to another in Knuth book; it was based on fast multiplication so `Parse()/ToString()` started working faster -- O(N * (log N)^2) instead of O(N^2). Finally division was also optimized (again, with the help of fast multiplication) -- became as fast as multiplication.

All this happened in 2005 year and in 2008 I've decided to publish this library on CodePlex -- maybe it will be useful for someone out there (well, there is not so many similar libraries under .NET). Before publishing it on CodePlex I also made some cosmetic changes in code -- used new .NET 2.0 features like generics (to minimize code duplication) and rewritten unit tests to use NUnit (they were previously written for MbUnit which is almost unknown and not used by community).

And in 2011 it's on GitHub and NuGet.

Code Example
------------

Here is the sample of code which uses IntX and calculates 42 in power 1048576 (which is 2^20):

    using System;
    using System.Diagnostics;
    using Oyster.Math;

    namespace IntxTestApp
    {
        class Program
        {
            static void Calc()
            {
                Stopwatch sw = Stopwatch.StartNew();
                IntX.Pow(42, 1 << 20);
                sw.Stop();
                Console.WriteLine("{0} ms", sw.ElapsedMilliseconds);
            }

            static void Main()
            {
                Calc();

                IntX.GlobalSettings.MultiplyMode = MultiplyMode.Classic;
                Calc();
            }
        }
    }

First `Calc()` call uses fast multiplication implementation (which is default), second -- classic one. On my machine (Win XP Pro SP2, P4 2.8 GHz, 2 GB RAM) first call is **70 times** faster than the second one (1 second against 68 seconds). Resulting number has 1,702,101 digits.

Another example is factorial calculation:

    using System;
    using Oyster.Math;
 
    namespace IntxTestApp
    {
        class Program
        {
            static IntX Factorial(IntX n)
            {
                if (n < 0)
                {
                    throw new ArgumentException("Can't calculate factorial for negative number.", "n");
                }
                return n == 0 ? 1 : n * Factorial(n - 1);
            }

            static void Main()
            {
                Console.WriteLine(Factorial(10000));
            }
        }
    }

As you can see, IntX implements all the standard arithmetic operators so its usage is transparent for developer -- like if you're working with usual integer.

FHT and Calculations Precision
------------------------------

Internally IntX library operates with floating-point numbers when multiplication using FHT is performed so at some point it stops working correctly and loses precision. Luckily, this unpleasant side-effects effects are starting to appear when integer size is about 2^28 bytes i.e. for really huge integers. Anyway, to catch such errors I have added FHT multiplication result validity check into code -- it takes N last digits of each big integer, multiplies them using classic approach and then compares last N digits of classic result with last N digits of FHT result (so it's kind of simplified CRC check). If any inconsistency is found then FhtMultiplicationException is thrown; this check can be disabled using global settings.

Internal Representation and ToString() Performance
--------------------------------------------------

For a really huge integer numbers (like 42 in power 1048576 above) `ToString()` call can take a very long time to execute. This is because internally IntX big integer is stored as 2^32-base number in `uint[]` array and to generate decimal string output it should be converted from 2^32 base to decimal base. Such digits storage approach was chosen intentionally -- it makes `ToString()` slower but uses memory efficiently and makes primitive operations on digits faster than power of 10-base storage (which would make `ToString()` working faster) and I think that usually computations are used more often than `ToString()`.

Future Plans
------------

I have no plans to further develop this library -- I'm just sharing it with the community.

System.Numerics.BigInteger in .NET 4.0
--------------------------------------

`System.Numerics.BigInteger` class was introduced in .NET 4.0 so I was interested in performance of this solution. I did some tests and it appears that `BigInteger` has performance in general comparable with IntX on standard operations but starts losing when FHT comes into play (when multiplying really big integers, for example).

So internally `System.Numerics.BigInteger` seems to use standard arbitrary arithmetic algorithms and I am not worrying about IntX library since, due to its use of FHT, it can be times faster for really big integers.

Comparing IntX Performance to GMP
---------------------------------

While IntX library is fast among other libraries written for .NET it can't really compete with [The GNU MP Library](http://gmplib.org/) -- one of the fastest well-known Bignum libraries in the world. GNU MP (or GMP) is written in plain C and Assembly language so it compiles into optimized native code, it also uses fast calculation algorithms -- that's why it's very fast. I have compared IntX performance to GMP on basic arithmetic operations and it appeared that GMP is up to 8 times faster than IntX on certain operations. Actually for me it is a good result -- IntX written in managed code is still quite fast :) GMP also has comparable performance on huge integers multiplication since, as well as IntX, it implements fast multiplication algorithm using FFT; it's also worth noticing that division for huge integers works few times faster in GMP comparing to IntX. GMP also has support for big floating-point numbers as well as for many numeric algorithms. For tests I was using GMP 5.0.0 DLL built for Windows using MinGW; I also want to add that my performance comparing was primitive and its results are very approximate.

So if you need to perform a lot of operations with big integers and must get the fastest possible speed from them then I'd suggest you using [GMP](http://gmplib.org/) (distributed under LGPL license); if you work in Windows you can build it with Cygwin/MinGW or use some GMP Windows-friendly port like [MPIR](http://www.mpir.org/). However, if 8x speed loss on some operations is okay for your project and/or you don't want to include unmanaged code into your application then IntX should be enough for you.

Btw, using GMP from C# is quite easy because there are GMP C#-wrappers available [here](http://www.emilstefanov.net/Projects/GnuMpDotNet/) (this one I was using for tests) and [there](http://gnumpnet.codeplex.com/). But be careful with them -- both wrappers I saw are releasing unmanaged resource they are referring (which is memory) only in `Finalize()` method override and not implementing `IDisposable` so you can end up with unexpected `OutOfMemoryException` as I did.