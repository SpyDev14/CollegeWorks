namespace SecondaryCourseWorks;

internal static class GlobalStaticMethods
{
	public static T[] GetRandomArray<T>(int length, T min, T max)
	{
# error TODO
		var rnd = new Random();
		var array = new T[length];

		for (int i = 0; i < length; i++)
			array[i] = rnd.Next(min, max);

		return array;
	}

	public static string ToInformativeString<T>(this T[] array) => $"[{string.Join(", ", array)}]";
}
