using System;
using System.Text;
using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class ParseFastTest
	{
		const int StartLength     = 1024;
		const int LengthIncrement = 101;
		const int RepeatCount     = 50;
		
		const int RandomStartLength = 1024;
		const int RandomEndLength   = 4000;
		const int RandomRepeatCount = 50;
		
		int _length = StartLength;
		
		public string GetAllNineChars(int length)
		{
			return new string('9', length);
		}
		
		public string GetRandomChars()
		{
			Random random = new Random();
			int length = random.Next(RandomStartLength, RandomEndLength);
			StringBuilder builder = new StringBuilder(length);
			
			builder.Append((char)random.Next('1', '9'));
			--length;
			
			while (length-- != 0) {
				builder.Append((char)random.Next('0', '9'));
			}
			return builder.ToString();
		}
		
		
		[Test]
		public void CompareWithClassic()
		{
			TestHelper.Repeat(
				RepeatCount,
				delegate
				{
					string str = GetAllNineChars(_length);
					IntX classic = IntX.Parse(str, ParseMode.Classic);
					IntX fast = IntX.Parse(str, ParseMode.Fast);

					Assert.IsTrue(classic == fast);

					_length += LengthIncrement;
				});
		}
		
		[Test]
		public void CompareWithClassicRandom()
		{
			TestHelper.Repeat(
				RandomRepeatCount,
				delegate
				{
					string str = GetRandomChars();
					IntX classic = IntX.Parse(str, ParseMode.Classic);
					IntX fast = IntX.Parse(str, ParseMode.Fast);

					Assert.IsTrue(classic == fast);
				});
		}
	}
}
