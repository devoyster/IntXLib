namespace IntXLib.Test
{
	internal delegate void Action();

	static internal class TestHelper
	{
		static public void Repeat(int count, Action body)
		{
			while (count-- > 0)
			{
				body();
			}
		}
	}
}
