using System.Numerics;
using System.Text;
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

	// Лень выносить в отдельный файл, ранее было private
	public class IndentedTextWriter(TextWriter original, int level) : TextWriter
	{
		const int LEVEL_SIZE = 4;

		private int _paddingSize = level * LEVEL_SIZE;
		private TextWriter _original = original;

		public override Encoding Encoding => Encoding.UTF8;
		public override void Write(char[]? buffer)
		{
			if (buffer == null)
				return;

			var sb = new StringBuilder();
			var paddingStr = new string(' ', _paddingSize);

			sb.Append(paddingStr);
			for (int i = 0; i < buffer.Length; i++)
			{
				char c = buffer[i];

				sb.Append(c);
				if (c == '\n' && i < buffer.Length - 1)
					sb.Append(paddingStr);
			}

			var newBuffer = sb.ToString().ToCharArray();

			_original.Write(newBuffer);
		}
	}

	public static string Input(
		string? name = null,
		(Predicate<string> validate, string msgIsInvalid)? validation = null,
		//int nestedLevel = 0,
		string prefix = ">>> "
	)
	{
		// На память (никто не будет смотреть git log) //

		//var oldOut = Console.Out;
		//if (nestedLevel != 0 && oldOut is not IndentedTextWriter)
		//	Console.SetOut(new IndentedTextWriter(oldOut, nestedLevel));

		if (name != null)
			Console.WriteLine(name);

		//try {
		while (true)
		{
			Console.Write(prefix);
			string? answer = Console.ReadLine()?.Trim();
			if (string.IsNullOrEmpty(answer))
			{
				Console.CursorTop -= 1;
				continue;
			}
			if (!validation.HasValue || validation.Value.validate(answer))
			{
				Console.WriteLine();
				return answer;
			}

			Console.WriteLine(validation.Value.msgIsInvalid);
			Console.WriteLine();
		}
		//}
		//finally { Console.SetOut(oldOut); }
	}

	public static T Input<T>(
		string? name = null,
		(Predicate<T> validate, string msgIsInvalid)? validation = null,
		string? wrongInputMsg = null,
		string prefix = ">>> "
	) where T : INumber<T>
	{
		// Работа с Nested также была и тут
		if (name != null)
			Console.WriteLine(name);

		wrongInputMsg ??= $"Введите корректный {typeof(T).Name}";

		while (true)
		{
			if (!T.TryParse(Input(prefix: prefix), null, out T? value))
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
