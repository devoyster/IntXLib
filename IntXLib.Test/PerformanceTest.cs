using System;
using System.Diagnostics;
using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture, Explicit]
	public class PerformanceTest
	{
		[Test]
		public void Multiply128BitNumbers()
		{
			IntX int1 = new IntX(new uint[] { 47668, 58687, 223234234, 42424242 }, false);
			IntX int2 = new IntX(new uint[] { 5674356, 34656476, 45667, 678645646 }, false);

			Stopwatch stopwatch = Stopwatch.StartNew();
			
			TestHelper.Repeat(
				100000,
				delegate
					{
						IntX.Multiply(int1, int2, MultiplyMode.Classic);
					}
			);

			stopwatch.Stop();
			Console.WriteLine(stopwatch.ElapsedMilliseconds);
		}
	}
}
