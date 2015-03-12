using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class OnesComplementOpTest
	{
		[Test]
		public void ShouldOnesComplementIntX()
		{
			IntX value = new IntX(11);

			IntX result = ~value;

			Assert.That(result, Is.EqualTo(-~(uint)11));
		}

		[Test]
		public void ShouldOnesComplementNegativeIntX()
		{
			IntX value = new IntX(-11);

			IntX result = ~value;

			Assert.That(result, Is.EqualTo(~(uint)11));
		}

		[Test]
		public void ShouldOnesComplementZero()
		{
			IntX value = new IntX();

			IntX result = ~value;

			Assert.That(result, Is.EqualTo(0));
		}

		[Test]
		public void ShouldOnesComplementBigIntX()
		{
			IntX value = new IntX(new uint[] { 3, 5, uint.MaxValue }, false);

			IntX result = ~value;

			Assert.That(result, Is.EqualTo(new IntX(new uint[] { ~(uint)3, ~(uint)5 }, true)));
		}
	}
}