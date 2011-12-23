using System;
using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class DivOpNewtonTest
	{
		const int StartLength     = 1024;
		const int LengthIncrement = 101;
		const int RepeatCount     = 10;
		
		const int RandomStartLength = 1024;
		const int RandomEndLength   = 2048;
		const int RandomRepeatCount = 25;
		
		int _length = StartLength;
		
		public uint[] GetAllOneDigits(int length)
		{
			uint[] digits = new uint[length];
			for (int i = 0; i < digits.Length; ++i) {
				digits[i] = 0xFFFFFFFF;
			}
			return digits;
		}
		
		public uint[] GetRandomDigits(out uint[] digits2)
		{
			Random random = new Random();
			uint[] digits = new uint[random.Next(RandomStartLength, RandomEndLength)];
			digits2 = new uint[digits.Length / 2];
			byte[] bytes = new byte[4];
			for (int i = 0; i < digits.Length; ++i) {
				random.NextBytes(bytes);
				digits[i] = BitConverter.ToUInt32(bytes, 0);
				if (i < digits2.Length) {
					random.NextBytes(bytes);
					digits2[i] = BitConverter.ToUInt32(bytes, 0);
				}
			}
			return digits;
		}
		
		
		[Test]
		public void CompareWithClassic()
		{
			TestHelper.Repeat(RepeatCount,
				delegate
				{
					IntX x = new IntX(GetAllOneDigits(_length), true);
					IntX x2 = new IntX(GetAllOneDigits(_length / 2), true);

					IntX classicMod, fastMod;
					IntX classic = IntX.DivideModulo(x, x2, out classicMod, DivideMode.Classic);
					IntX fast = IntX.DivideModulo(x, x2, out fastMod, DivideMode.AutoNewton);

					Assert.IsTrue(classic == fast);
					Assert.IsTrue(classicMod == fastMod);

					_length += LengthIncrement;
				});
		}

		[Test]
		public void CompareWithClassicRandom()
		{
			TestHelper.Repeat(RandomRepeatCount,
				delegate
				{
					uint[] digits2;
					IntX x = new IntX(GetRandomDigits(out digits2), false);
					IntX x2 = new IntX(digits2, false);

					IntX classicMod, fastMod;
					IntX classic = IntX.DivideModulo(x, x2, out classicMod, DivideMode.Classic);
					IntX fast = IntX.DivideModulo(x, x2, out fastMod, DivideMode.AutoNewton);

					Assert.IsTrue(classic == fast);
					Assert.IsTrue(classicMod == fastMod);
				});
		}
	}
}
