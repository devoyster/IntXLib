using System.IO;
using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class PowTest
	{
		[TestFixtureSetUp]
		public void SetUp()
		{
			IntX.GlobalSettings.MultiplyMode = MultiplyMode.Classic;
		}
		
		
		[Test]
		public void Simple()
		{
			IntX intX = new IntX(-1);
			Assert.IsTrue(IntX.Pow(intX, 17) == -1);
			Assert.IsTrue(IntX.Pow(intX, 18) == 1);
		}
		
		[Test]
		public void Zero()
		{
			IntX intX = new IntX();
			Assert.IsTrue(IntX.Pow(intX, 77) == 0);
		}

		[Test]
		public void PowZero()
		{
			Assert.IsTrue(IntX.Pow(0, 0) == 1);
		}

		[Test]
		public void PowOne()
		{
			Assert.IsTrue(IntX.Pow(7, 1) == 7);
		}

		[Test]
		public void Big()
		{
			Assert.AreEqual(IntX.Pow(2, 65).ToString(), "36893488147419103232");
		}
		
		// Simple output (2^65536). Uncomment to see
		//[Test]
		//public void TwoNOut()
		//{
		//  using (StreamWriter file = File.CreateText(@"C:\2n65536.txt"))
		//  {
		//    file.WriteLine(IntX.Pow(2, 65536));
		//  }
		//}
	}
}
