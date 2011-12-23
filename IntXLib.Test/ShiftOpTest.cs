using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class ShiftOpTest
	{
		[Test]
		public void Zero()
		{
			IntX int1 = new IntX();
			Assert.IsTrue(int1 << 100 == 0);
			Assert.IsTrue(int1 >> 100 == 0);
		}
		
		[Test]
		public void SimpleAndNeg()
		{
			IntX int1 = new IntX(8);
			Assert.IsTrue(int1 << 0 == int1 >> 0 && int1 << 0 == 8);
			Assert.IsTrue(int1 << 32 == int1 >> -32 && int1 << 32 == new IntX(new uint[] { 0, 8 }, false));
		}
		
		[Test]
		public void Complex()
		{
			IntX int1 = new IntX("0x0080808080808080");
			Assert.IsTrue((int1 << 4).ToString(16) == "808080808080800");
			Assert.IsTrue(int1 >> 36 == 0x80808);
		}
		
		[Test]
		public void BigShift()
		{
			IntX int1 = 8;
			Assert.IsTrue(int1 >> 777 == 0);
		}

		[Test]
		public void MassiveShift()
		{
			for (int i = 1; i < 2000; i++)
			{
				IntX n = i;
				n = n << i;
				n = n >> i;
				Assert.AreEqual(new IntX(i), n);
			}
		}
	}
}
