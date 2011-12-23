using System;
using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class ModOpTest
	{
		[Test]
		public void Simple()
		{
			IntX int1 = 16;
			IntX int2 = 5;
			Assert.IsTrue(int1 % int2 == 1);
		}
		
		[Test]
		public void Neg()
		{
			IntX int1 = -16;
			IntX int2 = 5;
			Assert.IsTrue(int1 % int2 == -1);
			int1 = 16;
			int2 = -5;
			Assert.IsTrue(int1 % int2 == 1);
			int1 = -16;
			int2 = -5;
			Assert.IsTrue(int1 % int2 == -1);
		}
		
		[Test]
		public void Zero()
		{
			IntX int1 = 0;
			IntX int2 = 25;
			Assert.IsTrue(int1 % int2 == 0);
			int1 = 0;
			int2 = -25;
			Assert.IsTrue(int1 % int2 == 0);
			int1 = 16;
			int2 = 25;
			Assert.IsTrue(int1 % int2 == 16);
			int1 = -16;
			int2 = 25;
			Assert.IsTrue(int1 % int2 == -16);
			int1 = 16;
			int2 = -25;
			Assert.IsTrue(int1 % int2 == 16);
			int1 = -16;
			int2 = -25;
			Assert.IsTrue(int1 % int2 == -16);
			int1 = 50;
			int2 = 25;
			Assert.IsTrue(int1 % int2 == 0);
			int1 = -50;
			int2 = -25;
			Assert.IsTrue(int1 % int2 == 0);
		}
		
		[Test, ExpectedException(typeof(DivideByZeroException))]
		public void ZeroException()
		{
			IntX int1 = 0;
			IntX int2 = 0;
			int1 = int1 % int2;
		}
		
		[Test]
		public void Big()
		{
			IntX int1 = new IntX(new uint[] {0, 0, 0x80000000U, 0x7fffffffU}, false);
			IntX int2 = new IntX(new uint[] {1, 0, 0x80000000U}, false);
			IntX intM = new IntX(new uint[] {2, 0xffffffffU, 0x7fffffffU}, false);
			Assert.IsTrue(int1 % int2 == intM);
		}
		
		[Test]
		public void BigDec()
		{
			IntX int1 = new IntX("100000000000000000000000000000000000000000000");
			IntX int2 = new IntX("100000000000000000000000000000000000000000");
			Assert.IsTrue(int1 % int2 == 0);
		}
		
		[Test]
		public void BigDecNeg()
		{
			IntX int1 = new IntX("-100000000000000000000000000000000000000000001");
			IntX int2 = new IntX("100000000000000000000000000000000000000000");
			Assert.IsTrue(int1 % int2 == -1);
		}
	}
}
