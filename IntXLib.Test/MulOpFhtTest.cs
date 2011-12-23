using System;
using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class MulOpFhtTest
	{
		const int StartLength     = 256;
		const int LengthIncrement = 101;
		const int RepeatCount     = 10;
		
		const int RandomStartLength = 256;
		const int RandomEndLength   = 1000;
		const int RandomRepeatCount = 50;
		
		int _length = StartLength;
		
		public uint[] GetAllOneDigits(int length)
		{
			uint[] digits = new uint[length];
			for (int i = 0; i < digits.Length; ++i) {
				digits[i] = 0x7F7F7F7F;
			}
			return digits;
		}
		
		public uint[] GetRandomDigits(int length)
		{
			Random random = new Random();
			uint[] digits = new uint[length];
			for (int i = 0; i < digits.Length; ++i) {
				digits[i] = (uint)random.Next() * 2U;
			}
			return digits;
		}

		public uint[] GetRandomDigits()
		{
			return GetRandomDigits(new Random().Next(RandomStartLength, RandomEndLength));
		}
		
		
		[Test]
		public void CompareWithClassic()
		{
			TestHelper.Repeat(
				RepeatCount,
				delegate
				{
					IntX x = new IntX(GetAllOneDigits(_length), true);
					IntX classic = IntX.Multiply(x, x, MultiplyMode.Classic);
					IntX fht = IntX.Multiply(x, x, MultiplyMode.AutoFht);

					Assert.IsTrue(classic == fht);

					_length += LengthIncrement;
				});
		}

		[Test]
		public void SmallLargeCompareWithClassic()
		{
			IntX x = new IntX(GetAllOneDigits(50000), false);
			IntX y = new IntX(GetAllOneDigits(512), false);
			IntX classic = IntX.Multiply(x, y, MultiplyMode.Classic);
			IntX fht = IntX.Multiply(x, y, MultiplyMode.AutoFht);

			Assert.IsTrue(classic == fht);
		}

		[Test]
		public void CompareWithClassicRandom()
		{
			TestHelper.Repeat(
				RandomRepeatCount,
				delegate
				{
					IntX x = new IntX(GetRandomDigits(), false);
					IntX classic = IntX.Multiply(x, x, MultiplyMode.Classic);
					IntX fht = IntX.Multiply(x, x, MultiplyMode.AutoFht);

					Assert.IsTrue(classic == fht);
				});
		}
	}
}
