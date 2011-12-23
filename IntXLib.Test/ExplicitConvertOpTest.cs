using System;
using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class ExplicitConvertOpTest
	{
		[Test]
		public void ConvertToInt()
		{
			int n = 1234567890;
			IntX intX = n;
			Assert.AreEqual(n, (int)intX);

			n = -n;
			intX = n;
			Assert.AreEqual(n, (int)intX);

			n = 0;
			intX = n;
			Assert.AreEqual(n, (int)intX);

			n = 1234567890;
			uint un = (uint)n;
			intX = new IntX(new uint[] { un, un, un }, false);
			Assert.AreEqual(n, (int)intX);
			intX = new IntX(new uint[] { un, un, un }, true);
			Assert.AreEqual(-n, (int)intX);
		}

		[Test]
		public void ConvertToUint()
		{
			uint n = 1234567890;
			IntX intX = n;
			Assert.AreEqual(n, (uint)intX);

			n = 0;
			intX = n;
			Assert.AreEqual(n, (uint)intX);

			n = 1234567890;
			intX = new IntX(new uint[] { n, n, n }, false);
			Assert.AreEqual(n, (uint)intX);
		}

		[Test]
		public void ConvertToLong()
		{
			long n = 1234567890123456789;
			IntX intX = n;
			Assert.AreEqual(n, (long)intX);

			n = -n;
			intX = n;
			Assert.AreEqual(n, (long)intX);

			n = 0;
			intX = n;
			Assert.AreEqual(n, (long)intX);

			uint un = 1234567890;
			n = (long)(un | (ulong)un << 32);
			intX = new IntX(new uint[] { un, un, un, un, un }, false);
			Assert.AreEqual(n, (long)intX);
			intX = new IntX(new uint[] { un, un, un, un, un }, true);
			Assert.AreEqual(-n, (long)intX);

			int ni = 1234567890;
			n = ni;
			intX = ni;
			Assert.AreEqual(n, (long)intX);
		}

		[Test]
		public void ConvertToUlong()
		{
			ulong n = 1234567890123456789;
			IntX intX = n;
			Assert.AreEqual(n, (ulong)intX);

			n = 0;
			intX = n;
			Assert.AreEqual(n, (ulong)intX);

			uint un = 1234567890;
			n = un | (ulong)un << 32;
			intX = new IntX(new uint[] { un, un, un, un, un }, false);
			Assert.AreEqual(n, (ulong)intX);

			n = un;
			intX = un;
			Assert.AreEqual(n, (ulong)intX);
		}

		[Test]
		public void ConvertToUshort()
		{
			ushort n = 12345;
			IntX intX = n;
			Assert.AreEqual(n, (ushort)intX);

			n = 0;
			intX = n;
			Assert.AreEqual(n, (ushort)intX);
		}


		[Test, ExpectedException(typeof(ArgumentNullException))]
		public void ConvertNullToInt()
		{
			int n = (int)(IntX)null;
		}

		[Test, ExpectedException(typeof(ArgumentNullException))]
		public void ConvertNullToUint()
		{
			uint n = (uint)(IntX)null;
		}

		[Test, ExpectedException(typeof(ArgumentNullException))]
		public void ConvertNullToLong()
		{
			long n = (long)(IntX)null;
		}

		[Test, ExpectedException(typeof(ArgumentNullException))]
		public void ConvertNullToUlong()
		{
			ulong n = (ulong)(IntX)null;
		}

		[Test, ExpectedException(typeof(ArgumentNullException))]
		public void ConvertNullToUshort()
		{
			ushort n = (ushort)(IntX)null;
		}
	}
}
