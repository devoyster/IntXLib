using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class ImplicitConvertOpTest
	{
		[Test]
		public void ConvertAllExceptLong()
		{
			IntX int1 = new int();
			Assert.IsTrue(int1 == 0);
			int1 = new uint();
			Assert.IsTrue(int1 == 0);
			int1 = new byte();
			Assert.IsTrue(int1 == 0);
			int1 = new sbyte();
			Assert.IsTrue(int1 == 0);
			int1 = new char();
			Assert.IsTrue(int1 == 0);
			int1 = new short();
			Assert.IsTrue(int1 == 0);
			int1 = new ushort();
			Assert.IsTrue(int1 == 0);
		}
		
		[Test]
		public void ConvertLong()
		{
			IntX int1 = new long();
			Assert.IsTrue(int1 == 0);
			int1 = new ulong();
			Assert.IsTrue(int1 == 0);
			int1 = -123123123123;
			Assert.IsTrue(int1 == -123123123123);
		}
	}
}
