using System;
using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class DivOpTest
	{
		[Test]
		public void Simple()
		{
			IntX int1 = 16;
			IntX int2 = 5;
			Assert.IsTrue(int1 / int2 == 3);
		}
		
		[Test]
		public void Neg()
		{
			IntX int1 = -16;
			IntX int2 = 5;
			Assert.IsTrue(int1 / int2 == -3);
			int1 = 16;
			int2 = -5;
			Assert.IsTrue(int1 / int2 == -3);
			int1 = -16;
			int2 = -5;
			Assert.IsTrue(int1 / int2 == 3);
		}
		
		[Test]
		public void Zero()
		{
			IntX int1 = 0;
			IntX int2 = 25;
			Assert.IsTrue(int1 / int2 == 0);
			int1 = 0;
			int2 = -25;
			Assert.IsTrue(int1 / int2 == 0);
			int1 = 16;
			int2 = 25;
			Assert.IsTrue(int1 / int2 == 0);
			int1 = -16;
			int2 = 25;
			Assert.IsTrue(int1 / int2 == 0);
			int1 = 16;
			int2 = -25;
			Assert.IsTrue(int1 / int2 == 0);
			int1 = -16;
			int2 = -25;
			Assert.IsTrue(int1 / int2 == 0);
		}
		
		[Test, ExpectedException(typeof(DivideByZeroException))]
		public void ZeroException()
		{
			IntX int1 = 0;
			IntX int2 = 0;
			int1 = int1 / int2;
		}
		
		[Test]
		public void Big()
		{
			IntX int1 = new IntX(new uint[] {0, 0, 0x80000000U, 0x7fffffffU}, false);
			IntX int2 = new IntX(new uint[] {1, 0, 0x80000000U}, false);
			Assert.IsTrue(int1 / int2 == 0xfffffffeU);
		}
		
		[Test]
		public void Big2()
		{
			IntX int1 = new IntX("4574586690780877990306040650779005020012387464357");
			IntX int2 = new IntX("856778798907978995905496597069809708960893");
			IntX int3 = new IntX("8567787989079799590496597069809708960893");
			IntX int4 = int1 * int2 + int3;
			Assert.IsTrue(int4 / int2 == int1);
			Assert.IsTrue(int4 % int2 == int3);
		}
		
		[Test]
		public void BigDec()
		{
			IntX int1 = new IntX("100000000000000000000000000000000000000000000");
			IntX int2 = new IntX("100000000000000000000000000000000000000000");
			Assert.IsTrue(int1 / int2 == 1000);
		}
		
		[Test]
		public void BigDecNeg()
		{
			IntX int1 = new IntX("-100000000000000000000000000000000000000000000");
			IntX int2 = new IntX("100000000000000000000000000000000000000000");
			Assert.IsTrue(int1 / int2 == -1000);
		}
	}
}
