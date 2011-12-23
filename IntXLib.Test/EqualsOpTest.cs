using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class EqualsOpTest
	{
		[Test]
		public void Equals2IntX()
		{
			IntX int1 = new IntX(8);
			IntX int2 = new IntX(8);
			Assert.IsTrue(int1.Equals(int2));
		}
		[Test]
		public void EqualsZeroIntX()
		{
			Assert.IsFalse(new IntX(0) == 1);
		}
		
		[Test]
		public void EqualsIntIntX()
		{
			IntX int1 = new IntX(8);
			Assert.IsTrue(int1 == 8);
		}
		
		[Test]
		public void EqualsNullIntX()
		{
			IntX int1 = new IntX(8);
			Assert.IsFalse(int1 == null);
		}
		
		[Test]
		public void Equals2IntXOp()
		{
			IntX int1 = new IntX(8);
			IntX int2 = new IntX(8);
			Assert.IsTrue(int1 == int2);
		}
	}
}
