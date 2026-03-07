namespace SecondaryCourseWorks;

internal static class GlobalStaticMethods
{
	public static int[] GetRandomArray(int length, int min, int max)
	{
		var rnd = new Random();
		var array = new int[length];

		for (int i = 0; i < length; i++)
			array[i] = rnd.Next(min, max);

		return array;
	}
}
