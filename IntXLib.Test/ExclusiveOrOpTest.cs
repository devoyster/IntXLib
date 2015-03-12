using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class ExclusiveOrOpTest
	{
		[Test]
		public void ShouldExclusiveOrTwoIntX()
		{
			IntX int1 = new IntX(3);
			IntX int2 = new IntX(5);

			IntX result = int1 ^ int2;

			Assert.That(result, Is.EqualTo(6));
		}

		[Test]
		public void ShouldExclusiveOrPositiveAndNegativeIntX()
		{
			IntX int1 = new IntX(-3);
			IntX int2 = new IntX(5);

			IntX result = int1 ^ int2;

			Assert.That(result, Is.EqualTo(-6));
		}

		[Test]
		public void ShouldExclusiveOrTwoNegativeIntX()
		{
			IntX int1 = new IntX(-3);
			IntX int2 = new IntX(-5);

			IntX result = int1 ^ int2;

			Assert.That(result, Is.EqualTo(6));
		}

		[Test]
		public void ShouldExclusiveOrIntXAndZero()
		{
			IntX int1 = new IntX(3);
			IntX int2 = new IntX();

			IntX result = int1 ^ int2;

			Assert.That(result, Is.EqualTo(int1));
		}

		[Test]
		public void ShouldExclusiveOrTwoBigIntX()
		{
			IntX int1 = new IntX(new uint[] { 3, 5, uint.MaxValue }, false);
			IntX int2 = new IntX(new uint[] { 1, 8, uint.MaxValue }, false);

			IntX result = int1 ^ int2;

			Assert.That(result, Is.EqualTo(new IntX(new uint[] { 2, 13 }, false)));
		}

		[Test]
		public void ShouldExclusiveOrTwoBigIntXOfDifferentLength()
		{
			IntX int1 = new IntX(new uint[] { 3, 5, uint.MaxValue, uint.MaxValue }, false);
			IntX int2 = new IntX(new uint[] { 1, 8, uint.MaxValue }, false);

			IntX result = int1 ^ int2;

			Assert.That(result, Is.EqualTo(new IntX(new uint[] { 2, 13, 0, uint.MaxValue }, false)));
		}
	}
}