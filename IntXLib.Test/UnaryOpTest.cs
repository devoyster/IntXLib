using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class UnaryOpTest
	{
		[Test]
		public void Plus()
		{
			IntX intX = 77;
			Assert.AreEqual(intX, +intX);
		}
		
		[Test]
		public void Minus()
		{
			IntX intX = 77;
			Assert.IsTrue(-intX == -77);
		}
		
		[Test]
		public void Zero()
		{
			IntX intX = 0;
			Assert.AreEqual(intX, +intX);
			Assert.AreEqual(intX, -intX);
		}
		
		[Test]
		public void PlusPlus()
		{
			IntX intX = 77;
			Assert.IsTrue(intX++ == 77);
			Assert.IsTrue(++intX == 79);
		}
		
		[Test]
		public void MinusMinus()
		{
			IntX intX = 77;
			Assert.IsTrue(intX-- == 77);
			Assert.IsTrue(--intX == 75);
		}
	}
}
