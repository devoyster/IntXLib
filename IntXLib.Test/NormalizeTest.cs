using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class NormalizeTest
	{
		[Test]
		public void Zero()
		{
			IntX int1 = new IntX(7) - 7;
			int1.Normalize();
			Assert.IsTrue(int1 == 0);
		}
		
		[Test]
		public void Simple()
		{
			IntX int1 = new IntX(8);
			int1 *= int1;
			int1.Normalize();
			Assert.IsTrue(int1 == 64);
		}
	}
}
