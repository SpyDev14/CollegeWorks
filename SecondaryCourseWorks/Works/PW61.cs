namespace SecondaryCourseWorks.Works;

internal class PW61p1 : BasePracticalWork
{
	public override string Number => "6.1p1";
	protected override string RawDescription => @"
		Дано число k (0 < k < m) и матрица размера n x m.
		Найти сумму элементов k-го столбца данной матрицы.
	";

	int width  = Random.Shared.Next(5, 10);
	int height = Random.Shared.Next(5, 10);
	public override void Execute()
	{
		int[] matrix = CreateRandomArray(height * width, -10, 10);

		int column = Input<int>(
			$"Введите номер столбца (от 1 до {height})",
			validation: ((num) => num >= 1 && num <= height, $"От 1 до {height}!")
		) - 1;

		Console.WriteLine($"Column {column + 1}: {Enumerable
			.Range(0, height)
			.Select(row => matrix[row * width + column])
			.ToArray()
			.Repr()}");

		int summ = 0;
		for (int row = 0; row < height; row++)
			summ += matrix[row * width + column];

		Console.WriteLine($"Summ of column items: {summ}");
	}
}

internal class PW61p2 : BasePracticalWork
{
	public override string Number => "6.1p2";

	protected override string RawDescription => @"
		В двумерном массиве хранится информация о количестве
		учеников в каждом классе каждой параллели школы с первой по
		одиннадцатую (в первой строке – информация о классах первой
		параллели, во второй – второй параллели и т.д.) В каждой
		параллели школы имеются четыре класса. Определить общее
		чисто учеников в параллели 5-х классов. 
	";

	int width = 11;
	int height = 4;

	public override void Execute()
	{
		int[] matrix = CreateRandomArray(height * width, 18, 34);
		int column = 5;

		Console.WriteLine($"{column}x classes guys count: {Enumerable
			.Range(0, height)
			.Select(row => matrix[row * width + column])
			.ToArray()
			.Repr()}");

		int summ = 0;
		for (int row = 0; row < height; row++)
			summ += matrix[row * width + column];

		Console.WriteLine($"Summ of guys in {column}x classes: {summ}");
	}
}

internal class PW61p3 : BasePracticalWork
{
	public override string Number => "6.1p3";


	int width = Random.Shared.Next(5, 10);
	int height = Random.Shared.Next(3, 6) * 2;
	protected override string RawDescription => @"
		Дан двумерный массив из четного числа строк. Строки верхней
		половины массива поменять местами со строками нижней половины.
	";

	public override void Execute()
	{
		int[,] matrix = CreateRandom2DMatrix(width, height, -15, 15);

		matrix.PrintMatrix();

		int half = height / 2;
		for (int i = 0; i < half; i++)
			for (int j = 0; j < width; j++)
			{
				int temp = matrix[i, j];
				matrix[i, j] = matrix[i + half, j];
				matrix[i + half, j] = temp;
			}

		Console.WriteLine($"\nProcessed matrix:");
		matrix.PrintMatrix();
	}
}