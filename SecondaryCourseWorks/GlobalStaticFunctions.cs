using System.Numerics;
using SecondaryCourseWorks.GotoException;

namespace SecondaryCourseWorks;

// TODO: Rename to global staff or builtins
internal static class GlobalStaticFunctions
{
	internal static class Comma
	{
		// Уже вырисовыватеся какая-то обработка комманд
		// Но реализовывать я её, конечно же, не буду)))
		public const string BREAK = "/break";
		public const string EXIT = "/exit";
	}
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

	private static T[,] To2DMatrix<T>(this T[] flatMatrix, int width, int height) where T : INumber<T>
	{
		if (flatMatrix.Length != width * height)
			throw new ArgumentException("Given flatMatrix length should be == given width * height.");

		T[,] matrix = new T[height, width];
		for (int i = 0; i < height; i++)
			for (int j = 0; j < width; j++)
				matrix[i, j] = flatMatrix[i * width + j];

		return matrix;
	}

	public static T[,] CreateRandom2DMatrix<T>(int width, int height, T min, T max) where T : INumber<T>
		=> CreateRandomArray(width * height, min, max).To2DMatrix(width, height);

	public static string Repr<T>(this T[] arr) => $"[{string.Join(", ", arr)}]";
	public static void PrintMatrix<T>(this T[,] arr)
	{
		int rows = arr.GetLength(0);
		int cols = arr.GetLength(1);
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < cols; j++)
				Console.Write($"{arr[i, j], 4}");

			Console.WriteLine();
		}
		Console.WriteLine($"Width: {cols}, Height: {rows}");
		Console.WriteLine();
	}
	public static string Input(
		string? name = null,
		(Predicate<string> validate, string msgIsInvalid)? validation = null,
		bool allowBreak = true,
		bool goNextLineOnSuccess = true,
		string prefix = ">>> "
	)
	{
		if (name != null)
			Console.WriteLine(name);

		while (true)
		{
			Console.Write(prefix);
			string? answer = Console.ReadLine()?.Trim();
			if (string.IsNullOrEmpty(answer))
			{
				Console.CursorTop -= 1;
				continue;
			}
			if (answer == Comma.BREAK)
				if (allowBreak) throw new BreakWorkProcessing();
				else {
					Console.WriteLine($"{Comma.BREAK} не доступен в текущем контексте.\n");
					continue;
				}
			if (answer == Comma.EXIT)
				throw new ProgrammExit();
			if (!validation.HasValue || validation.Value.validate(answer))
			{
				if (goNextLineOnSuccess)
					Console.WriteLine();
				return answer;
			}

			if (answer.StartsWith('/'))
				Console.WriteLine($"Команды \"{answer}\" не существует.");
			else
				Console.WriteLine(validation.Value.msgIsInvalid);

			Console.WriteLine();
		}
	}

	public static T Input<T>(
		string? name = null,
		(Predicate<T> validate, string msgIsInvalid)? validation = null,
		string? wrongInputMsg = null,
		bool allowBreak = true,
		string prefix = ">>> "
	) where T : INumber<T>
	{
		if (name != null)
			Console.WriteLine(name);

		wrongInputMsg ??= $"Введите корректный {typeof(T).Name}";

		while (true)
		{
			string input = Input(
				allowBreak: allowBreak,
				goNextLineOnSuccess: false,
				prefix: prefix
			);
			if (!T.TryParse(input, null, out T? value))
			{
				Console.WriteLine(wrongInputMsg);
				Console.WriteLine();
				continue;
			}

			if (!validation.HasValue || validation.Value.validate(value))
				return value;

			Console.WriteLine(validation.Value.msgIsInvalid);
			Console.WriteLine();
		}
	}
}
