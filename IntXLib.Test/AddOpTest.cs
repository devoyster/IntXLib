using System;
using System.IO;
using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class AddOpTest
	{
		[Test]
		public void Add2IntX()
		{
			IntX int1 = new IntX(3);
			IntX int2 = new IntX(5);
			Assert.IsTrue(int1 + int2 == 8);
		}
		
		[Test]
		public void Add2IntXNeg()
		{
			IntX int1 = new IntX(-3);
			IntX int2 = new IntX(-5);
			Assert.IsTrue(int1 + int2 == -8);
		}
		
		[Test]
		public void AddIntIntX()
		{
			IntX intX = new IntX(3);
			Assert.IsTrue(intX + 5 == 8);
		}
		
		[Test]
		public void AddIntXInt()
		{
			IntX intX = new IntX(3);
			Assert.IsTrue(5 + intX == 8);
		}
		
		[Test, ExpectedException(typeof(ArgumentNullException))]
		public void AddNullIntX()
		{
			IntX int1 = new IntX(3);
			int1 = int1 + null;
		}
		
		[Test]
		public void Add0IntX()
		{
			IntX int1 = new IntX(3);
			Assert.IsTrue(int1 + 0 == 3);
			Assert.IsTrue(int1 + new IntX() == 3);
		}

		[Test]
		public void Add0IntXNeg()
		{
			IntX int1 = new IntX(-3);
			Assert.IsTrue(int1 + 0 == -3);
			Assert.IsTrue(int1 + new IntX() == -3);
			Assert.IsTrue(new IntX(0) + new IntX(-1) == -1);
		}
		
		[Test]
		public void Add2BigIntX()
		{
			IntX int1 = new IntX(new uint[] { 1, 2, 3 }, false);
			IntX int2 = new IntX(new uint[] { 3, 4, 5 }, false);
			IntX int3 = new IntX(new uint[] { 4, 6, 8 }, false);
			Assert.IsTrue(int1 + int2 == int3);
		}
		
		[Test]
		public void Add2BigIntXC()
		{
			IntX int1 = new IntX(new uint[] { uint.MaxValue, uint.MaxValue - 1 }, false);
			IntX int2 = new IntX(new uint[] { 1, 1 }, false);
			IntX int3 = new IntX(new uint[] { 0, 0, 1 }, false);
			Assert.IsTrue(int1 + int2 == int3);
		}
		
		[Test]
		public void Add2BigIntXC2()
		{
			IntX int1 = new IntX(new uint[] { uint.MaxValue - 1, uint.MaxValue - 1 }, false);
			IntX int2 = new IntX(new uint[] { 1, 1 }, false);
			IntX int3 = new IntX(new uint[] { uint.MaxValue, uint.MaxValue }, false);
			Assert.IsTrue(int1 + int2 == int3);
		}
		
		[Test]
		public void Add2BigIntXC3()
		{
			IntX int1 = new IntX(new uint[] { uint.MaxValue, uint.MaxValue }, false);
			IntX int2 = new IntX(new uint[] { 1, 1 }, false);
			IntX int3 = new IntX(new uint[] { 0, 1, 1 }, false);
			Assert.IsTrue(int1 + int2 == int3);
		}
		
		[Test]
		public void Add2BigIntXC4()
		{
			IntX int1 = new IntX(new uint[] { uint.MaxValue, uint.MaxValue, 1, 1 }, false);
			IntX int2 = new IntX(new uint[] { 1, 1 }, false);
			IntX int3 = new IntX(new uint[] { 0, 1, 2, 1 }, false);
			Assert.IsTrue(int1 + int2 == int3);
		}
		
		[Test]
		public void Fibon()
		{
			IntX int1 = new IntX(1);
			IntX int2 = int1;
			IntX int3 = null;
			for (int i = 0; i < 10000; ++i) {
				int3 = int1 + int2;
				int1 = int2;
				int2 = int3;
			}
		}
		
		[Test]
		public void AddSub()
		{
			IntX int1 = new IntX(2);
			IntX int2 = new IntX(-2);
			Assert.IsTrue(int1 + int2 == 0);
		}
		
		// Simple output (hex Fibonacci numbers). Uncomment to see
		//[Test]
		//public void FibonOut()
		//{
		//  uint numberBase = 16;
		//  using (StreamWriter file = File.CreateText(@"C:\fibon.txt"))
		//  {
		//    IntX int1 = new IntX(1);
		//    file.WriteLine(int1.ToString(numberBase));

		//    IntX int2 = int1;
		//    file.WriteLine(int2.ToString(numberBase));

		//    IntX int3 = null;
		//    for (int i = 0; i < 1000; ++i)
		//    {
		//      int3 = int1 + int2;
		//      file.WriteLine(int3.ToString(numberBase));
		//      int1 = int2;
		//      int2 = int3;
		//    }
		//  }
		//}
	}
}
