using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class ToStringTest
	{
		[Test]
		public void VerySimple()
		{
			IntX intX = new IntX(11);
			Assert.AreEqual(intX.ToString(), "11");
		}
		
		[Test]
		public void Simple()
		{
			IntX intX = new IntX(12345670);
			Assert.AreEqual(intX.ToString(), "12345670");
		}
		
		[Test]
		public void Zero()
		{
			IntX intX = new IntX();
			Assert.AreEqual(intX.ToString(), "0");
		}
		
		[Test]
		public void Neg()
		{
			IntX intX = new IntX(int.MinValue);
			Assert.AreEqual(intX.ToString(), int.MinValue.ToString());
		}
		
		[Test]
		public void Big()
		{
			IntX intX = new IntX(int.MaxValue);
			intX += intX += intX += intX;
			long longX = int.MaxValue;
			longX += longX += longX += longX;
			Assert.AreEqual(intX.ToString(), longX.ToString());
		}
		
		[Test]
		public void Binary()
		{
			IntX intX = new IntX(19);
			Assert.AreEqual(intX.ToString(2), "10011");
		}
		
		[Test]
		public void Octal()
		{
			IntX intX = new IntX(100);
			Assert.AreEqual(intX.ToString(8), "144");
		}
		
		[Test]
		public void Octal2()
		{
			IntX intX = new IntX(901);
			Assert.AreEqual(intX.ToString(8), "1605");
		}
		
		[Test]
		public void Octal3()
		{
			IntX intX = 0x80000000;
			Assert.AreEqual(intX.ToString(8), "20000000000");
			intX = 0x100000000;
			Assert.AreEqual(intX.ToString(8), "40000000000");
		}
		
		[Test]
		public void Hex()
		{
			IntX intX = new IntX(0xABCDEF);
			Assert.AreEqual(intX.ToString(16), "ABCDEF");
		}
		
		[Test]
		public void HexLower()
		{
			IntX intX = new IntX(0xFF00FF00FF00FF);
			Assert.AreEqual(intX.ToString(16, false), "ff00ff00ff00ff");
		}
		
		[Test]
		public void OtherBase()
		{
			IntX intX = new IntX(-144);
			Assert.AreEqual(intX.ToString(140), "-{1}{4}");
		}
	}
}
