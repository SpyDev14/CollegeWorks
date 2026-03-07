using System.Numerics;
namespace SecondaryCourseWorks;

internal static class GlobalStaticMethods
{
	/// <summary>
	/// Генерирует массив указанной длины со случайными значениями в заданном диапазоне.
	/// Точность для больших чисел <b>не идеальная</b>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="length"></param>
	/// <param name="min"></param>
	/// <param name="max"></param>
	/// <returns>Новый заполненный <see cref="Array"/> переданного размера.</returns>
	/// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> < 0</exception>
	/// <exception cref="ArgumentException"><paramref name="min"/> > <paramref name="max"/></exception>
	public static T[] GetRandomArray<T>(int length, T min, T max) where T : INumber<T>
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

	public static string ToInformativeString<T>(this T[] array) => $"[{string.Join(", ", array)}]";
}
