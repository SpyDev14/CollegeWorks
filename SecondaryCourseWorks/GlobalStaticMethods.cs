using System.Collections;
using System.Numerics;
namespace SecondaryCourseWorks;

internal static class GlobalStaticMethods
{
	/// <summary>
	/// Генерирует массив указанной длины со случайными значениями в заданном диапазоне.
	/// Точность для больших чисел <b>не идеальная</b>.
	/// </summary>
	/// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> < 0</exception>
	/// <exception cref="ArgumentException"><paramref name="min"/> > <paramref name="max"/></exception>
	public static T[] CreateRandomArray<T>(int length, T min, T max) where T : INumber<T>
	{
		if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
		if (min > max) throw new ArgumentException("min must be <= max");

		double dMin = double.CreateTruncating(min);
		double dMax = double.CreateTruncating(max);
		double range = dMax - dMin;

		var rnd = Random.Shared;
		var array = new T[length];

		for (int i = 0; i < length; i++)
			array[i] = T.CreateTruncating(dMin + rnd.NextDouble() * range);

		return array;
	}

	public static string ToPythonListLikeString<T>(this T[] array) => $"[{string.Join(", ", array)}]";
}
