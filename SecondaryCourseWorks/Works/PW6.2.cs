using System;
using System.Collections.Generic;
using System.Text;

namespace SecondaryCourseWorks.Works;

internal class PW62 : BasePracticalWork
{
	public override string Number => "6.2";

	protected override string RawDescription => @"
		Вставить первую строку после строк, в которых
		находится максимальный элемент. 

		Удалите столбцы, в которых есть заданный элемент.
		Если такого столбца нет, то вывести сообщение об этом.
	";

	int width = Random.Shared.Next(5, 10);
	int height = Random.Shared.Next(3, 6);

	public override void Execute()
	{
		int[,] matrix = CreateRandom2DMatrix(height, width, -15, 15);

		Console.WriteLine("Матрица:");
		matrix.PrintMatrix();
		Part1(ref matrix);

		Console.WriteLine("Матрица после 1 части:");
		matrix.PrintMatrix();
		Part2(ref matrix);

		Console.WriteLine("Итоговая матрица:");
		matrix.PrintMatrix();
	}

	void Part1(ref int[,] matrix)
	{
		int rows = matrix.GetLength(0);
		int cols = matrix.GetLength(1);
		int max = int.MinValue;

		for (int i = 0; i < rows; i++)
			for (int j = 0; j < cols; j++)
			{
				int el = matrix[i, j];
				if (max < el) max = el;
			}

		Console.WriteLine($"Максимальный элемент: {max}\n");

		bool[] rowsWithMax = new bool[rows];

		for (int i = 0; i < rows; i++)
			for (int j = 0; j < cols; j++)
				if (matrix[i, j] == max)
				{
					rowsWithMax[i] = true;
					break;
				}

		int[] firstRow = new int[cols];
		for (int j = 0; j < cols; j++) firstRow[j] = matrix[0, j];

		var newRows = new List<int[]>();
		for (int i = 0; i < rows; i++)
		{
			int[] currentRow = new int[cols];
			for (int j = 0; j < cols; j++) currentRow[j] = matrix[i, j];
			newRows.Add(currentRow);
			if (rowsWithMax[i])
				newRows.Add(firstRow.ToArray());
		}

		int newRowsCount = newRows.Count;
		int[,] newMatrix = new int[newRowsCount, cols];
		for (int i = 0; i < newRowsCount; i++)
			for (int j = 0; j < cols; j++)
				newMatrix[i, j] = newRows[i][j];

		matrix = newMatrix;
	}

	void Part2(ref int[,] matrix)
	{
		int targetElement = Input<int>("Элемент для поиска");

		int rows = matrix.GetLength(0);
		int cols = matrix.GetLength(1);
		bool[] removeCol = new bool[cols];
		bool found = false;

		for (int j = 0; j < cols; j++)
			for (int i = 0; i < rows; i++)
				if (matrix[i, j] == targetElement)
				{
					removeCol[j] = true;
					found = true;
					break;
				}

		if (!found)
		{
			Console.WriteLine("Столбцов с заданным элементом не найдено.");
			return;
		}

		var keptCols = new List<int>();
		for (int j = 0; j < cols; j++)
			if (!removeCol[j]) keptCols.Add(j);

		int newCols = keptCols.Count;
		int[,] newMatrix = new int[rows, newCols];
		for (int i = 0; i < rows; i++)
			for (int newJ = 0; newJ < newCols; newJ++)
				newMatrix[i, newJ] = matrix[i, keptCols[newJ]];

		matrix = newMatrix;
	}
}
