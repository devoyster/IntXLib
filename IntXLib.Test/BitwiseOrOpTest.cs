using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class BitwiseOrOpTest
	{
		[Test]
		public void ShouldBitwiseOrTwoIntX()
		{
			IntX int1 = new IntX(3);
			IntX int2 = new IntX(5);

			IntX result = int1 | int2;

			Assert.That(result, Is.EqualTo(7));
		}

		[Test]
		public void ShouldBitwiseOrPositiveAndNegativeIntX()
		{
			IntX int1 = new IntX(-3);
			IntX int2 = new IntX(5);

			IntX result = int1 | int2;

			Assert.That(result, Is.EqualTo(-7));
		}

		[Test]
		public void ShouldBitwiseOrTwoNegativeIntX()
		{
			IntX int1 = new IntX(-3);
			IntX int2 = new IntX(-5);

			IntX result = int1 | int2;

			Assert.That(result, Is.EqualTo(-7));
		}

		[Test]
		public void ShouldBitwiseOrIntXAndZero()
		{
			IntX int1 = new IntX(3);
			IntX int2 = new IntX();

			IntX result = int1 | int2;

			Assert.That(result, Is.EqualTo(int1));
		}

		[Test]
		public void ShouldBitwiseOrTwoBigIntX()
		{
			IntX int1 = new IntX(new uint[] { 3, 5, uint.MaxValue }, false);
			IntX int2 = new IntX(new uint[] { 1, 8 }, false);

			IntX result = int1 | int2;

			Assert.That(result, Is.EqualTo(new IntX(new uint[] { 3, 13, uint.MaxValue }, false)));
		}
	}
}