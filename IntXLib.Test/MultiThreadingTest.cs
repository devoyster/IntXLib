using System.Threading.Tasks;
using NUnit.Framework;

namespace IntXLib.Test
{
	[TestFixture]
	public class MultiThreadingTest
	{
		[Test]
		public void ShiftMemoryCorruptionTasks()
		{
			Task.WaitAll(StartNewShiftMemoryCorruptionTask(),
						 StartNewShiftMemoryCorruptionTask());
		}

		private Task StartNewShiftMemoryCorruptionTask()
		{
			return Task.Factory.StartNew(
				() =>
					{
						IntX x = 1;
						for (int i = 0; i < 1000000; i++)
						{
							x <<= 63;
							x >>= 63;
							Assert.That(x == 1);
						}
					});
		}
	}
}
