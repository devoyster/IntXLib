using System;
using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class SubOpTest
	{
		[Test]
		public void Sub2IntX()
		{
			IntX int1 = new IntX(3);
			IntX int2 = new IntX(5);
			Assert.IsTrue(int1 - int2 == -2);
		}
		[Test]
		public void Sub2IntXNeg()
		{
			IntX int1 = new IntX(-3);
			IntX int2 = new IntX(-5);
			Assert.IsTrue(int1 - int2 == 2);
		}
		
		[Test]
		public void SubIntIntX()
		{
			IntX intX = new IntX(3);
			Assert.IsTrue(intX - 5 == -2);
		}
		
		[Test]
		public void SubIntXInt()
		{
			IntX intX = new IntX(3);
			Assert.IsTrue(5 - intX == 2);
		}
		
		[Test, ExpectedException(typeof(ArgumentNullException))]
		public void SubNullIntX()
		{
			IntX int1 = new IntX(3);
			int1 = int1 - null;
		}
		
		[Test]
		public void Sub0IntX()
		{
			IntX int1 = new IntX(3);
			Assert.IsTrue(int1 - 0 == 3);
			Assert.IsTrue(0 - int1 == -3);
			Assert.IsTrue(int1 - new IntX() == 3);
			Assert.IsTrue(new IntX() - int1 == -3);
		}

		[Test]
		public void Sub0IntXNeg()
		{
			IntX int1 = new IntX(-3);
			Assert.IsTrue(int1 - 0 == -3);
			Assert.IsTrue(0 - int1 == 3);
			Assert.IsTrue(int1 - new IntX() == -3);
			Assert.IsTrue(new IntX() - int1 == 3);
		}
		
		[Test]
		public void Sub2BigIntX()
		{
			IntX int1 = new IntX(new uint[] { 1, 2, 3 }, false);
			IntX int2 = new IntX(new uint[] { 3, 4, 5 }, false);
			IntX int3 = new IntX(new uint[] { 2, 2, 2 }, true);
			Assert.IsTrue(int1 - int2 == int3);
		}
		
		[Test]
		public void Sub2BigIntXC()
		{
			IntX int1 = new IntX(new uint[] { uint.MaxValue, uint.MaxValue - 1 }, false);
			IntX int2 = new IntX(new uint[] { 1, 1 }, false);
			IntX int3 = new IntX(new uint[] { 0, 0, 1 }, false);
			Assert.IsTrue(int1 == int3 - int2);
		}
		
		[Test]
		public void Sub2BigIntXC2()
		{
			IntX int1 = new IntX(new uint[] { uint.MaxValue - 1, uint.MaxValue - 1 }, false);
			IntX int2 = new IntX(new uint[] { 1, 1 }, false);
			IntX int3 = new IntX(new uint[] { uint.MaxValue, uint.MaxValue }, false);
			Assert.IsTrue(int1 == int3 - int2);
		}
		
		[Test]
		public void Sub2BigIntXC3()
		{
			IntX int1 = new IntX(new uint[] { uint.MaxValue, uint.MaxValue }, false);
			IntX int2 = new IntX(new uint[] { 1, 1 }, false);
			IntX int3 = new IntX(new uint[] { 0, 1, 1 }, false);
			Assert.IsTrue(int1 == int3 - int2);
		}
		
		[Test]
		public void Sub2BigIntXC4()
		{
			IntX int1 = new IntX(new uint[] { uint.MaxValue, uint.MaxValue, 1, 1 }, false);
			IntX int2 = new IntX(new uint[] { 1, 1 }, false);
			IntX int3 = new IntX(new uint[] { 0, 1, 2, 1 }, false);
			Assert.IsTrue(int1 == int3 - int2);
		}
		
		[Test]
		public void SubAdd()
		{
			IntX int1 = new IntX(2);
			IntX int2 = new IntX(-3);
			Assert.IsTrue(int1 - int2 == 5);
		}
	}
}
