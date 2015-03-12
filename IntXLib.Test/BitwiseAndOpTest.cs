using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class BitwiseAndOpTest
	{
		[Test]
		public void ShouldBitwiseAndTwoIntX()
		{
			IntX int1 = new IntX(11);
			IntX int2 = new IntX(13);

			IntX result = int1 & int2;

			Assert.That(result, Is.EqualTo(9));
		}

		[Test]
		public void ShouldBitwiseAndPositiveAndNegativeIntX()
		{
			IntX int1 = new IntX(-11);
			IntX int2 = new IntX(13);

			IntX result = int1 & int2;

			Assert.That(result, Is.EqualTo(9));
		}

		[Test]
		public void ShouldBitwiseAndTwoNegativeIntX()
		{
			IntX int1 = new IntX(-11);
			IntX int2 = new IntX(-13);

			IntX result = int1 & int2;

			Assert.That(result, Is.EqualTo(-9));
		}

		[Test]
		public void ShouldBitwiseAndIntXAndZero()
		{
			IntX int1 = new IntX(11);
			IntX int2 = new IntX();

			IntX result = int1 & int2;

			Assert.That(result, Is.EqualTo(0));
		}

		[Test]
		public void ShouldBitwiseAndTwoBigIntX()
		{
			IntX int1 = new IntX(new uint[] { 11, 6, uint.MaxValue, uint.MaxValue }, false);
			IntX int2 = new IntX(new uint[] { 13, 3, 0 }, false);

			IntX result = int1 & int2;

			Assert.That(result, Is.EqualTo(new IntX(new uint[] { 9, 2 }, false)));
		}
	}
}