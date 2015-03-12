using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class IsOddTest
	{
		[Test]
		public void ShouldBeFalseForZero()
		{
			IntX value = new IntX();

			bool result = value.IsOdd;

			Assert.That(result, Is.False);
		}

		[Test]
		public void ShouldBeFalseForEvenNumber()
		{
			IntX value = new IntX(42);

			bool result = value.IsOdd;

			Assert.That(result, Is.False);
		}

		[Test]
		public void ShouldBeTrueForOddNumber()
		{
			IntX value = new IntX(57);

			bool result = value.IsOdd;

			Assert.That(result, Is.True);
		}
	}
}