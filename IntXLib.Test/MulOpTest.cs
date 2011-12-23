using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class MulOpTest
	{
		[TestFixtureSetUp]
		public void SetUp()
		{
			IntX.GlobalSettings.MultiplyMode = MultiplyMode.Classic;
		}
		
		
		[Test]
		public void PureIntX()
		{
			Assert.AreEqual(new IntX(3) * new IntX(5), new IntX(15));
		}
		
		[Test]
		public void PureIntXSign()
		{
			Assert.AreEqual(new IntX(-3) * new IntX(5), new IntX(-15));
		}
		
		[Test]
		public void IntAndIntX()
		{
			Assert.IsTrue(new IntX(3) * 5 == 15);
		}
		
		[Test]
		public void Zero()
		{
			Assert.IsTrue(0 * new IntX(3) == 0);
		}
		
		[Test]
		public void Big()
		{
			IntX int1   = new IntX(new uint[] { 1, 1 }, false);
			IntX int2   = new IntX(new uint[] { 1, 1 }, false);
			IntX intRes = new IntX(new uint[] { 1, 2, 1 }, false);
			Assert.AreEqual(int1 * int2, intRes);
		}
		
		[Test]
		public void Big2()
		{
			IntX int1   = new IntX(new uint[] { 1, 1 }, false);
			IntX int2   = new IntX(new uint[] { 2 }, false);
			IntX intRes = new IntX(new uint[] { 2, 2 }, false);
			Assert.AreEqual(intRes, int1 * int2);
			Assert.AreEqual(intRes, int2 * int1);
		}
		
		[Test]
		public void Big3()
		{
			IntX int1   = new IntX(new uint[] { uint.MaxValue, uint.MaxValue }, false);
			IntX int2   = new IntX(new uint[] { uint.MaxValue, uint.MaxValue }, false);
			IntX intRes = new IntX(new uint[] { 1, 0, uint.MaxValue - 1, uint.MaxValue }, false);
			Assert.IsTrue(int1 * int2 == intRes);
		}
		
		[Test]
		public void Performance()
		{
			IntX intX  = new IntX(new uint[] { 0, 1 }, false);
			IntX intX2 = intX;
			for (int i = 0; i < 1000; ++i) {
				intX2 *= intX;
			}
		}
	}
}
