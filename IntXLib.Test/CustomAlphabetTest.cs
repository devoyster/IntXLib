using System;
using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class CustomAlphabetTest
	{
		[Test, ExpectedException(typeof(ArgumentNullException))]
		public void AlphabetNull()
		{
			IntX.Parse("", 20, null);
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void AlphabetShort()
		{
			IntX.Parse("", 20, "1234");
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void AlphabetRepeatingChars()
		{
			IntX.Parse("", 20, "0123456789ABCDEFGHIJ0");
		}
		
		[Test]
		public void Parse()
		{
			Assert.AreEqual(19 * 20 + 18, (int)IntX.Parse("JI", 20, "0123456789ABCDEFGHIJ"));
		}

		[Test]
		public void ToStringTest()
		{
			Assert.AreEqual("JI", new IntX(19 * 20 + 18).ToString(20, "0123456789ABCDEFGHIJ"));
		}
	}
}
