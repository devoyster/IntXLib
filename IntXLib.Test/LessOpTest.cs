using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class LessOpTest
	{
		[Test]
		public void Simple()
		{
			IntX int1 = new IntX(7);
			IntX int2 = new IntX(8);
			Assert.IsTrue(int1 < int2);
		}
		
		[Test]
		public void SimpleFail()
		{
			IntX int1 = new IntX(8);
			Assert.IsFalse(int1 < 7);
		}
		
		[Test]
		public void Big()
		{
			IntX int1 = new IntX(new uint[] { 1, 2 }, false);
			IntX int2 = new IntX(new uint[] { 1, 2, 3 }, true);
			Assert.IsTrue(int2 < int1);
		}
		
		[Test]
		public void BigFail()
		{
			IntX int1 = new IntX(new uint[] { 1, 2 }, false);
			IntX int2 = new IntX(new uint[] { 1, 2, 3 }, true);
			Assert.IsFalse(int1 < int2);
		}
		
		[Test]
		public void EqualValues()
		{
			IntX int1 = new IntX(new uint[] { 1, 2, 3 }, true);
			IntX int2 = new IntX(new uint[] { 1, 2, 3 }, true);
			Assert.IsFalse(int1 < int2);
		}
		
		[Test]
		public void Neg()
		{
			IntX int1 = new IntX(-10);
			IntX int2 = new IntX(-2);
			Assert.IsTrue(int1 < int2);
		}
	}
}
