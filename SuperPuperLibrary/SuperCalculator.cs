using System.Numerics;

namespace SuperPuperLibrary;

/// <summary>
/// Предоставляет набор расширяющих методов для выполнения базовых арифметических операций
/// над любыми типами, поддерживающими соответствующие операторы через интерфейсы из
/// пространства имён <see cref="System.Numerics"/>.
/// </summary>
public static class SuperCalculator
{
	/// <summary>
	/// Выполняет сложение двух значений одного типа.
	/// </summary>
	public static T Add<T>(this T a, T b) where T : IAdditionOperators<T, T, T>
		=> a + b;

	/// <summary>
	/// Выполняет вычитание двух значений одного типа.
	/// </summary>
	public static T Sub<T>(this T a, T b) where T : ISubtractionOperators<T, T, T>
		=> a - b;

	/// <summary>
	/// Выполняет умножение двух значений одного типа.
	/// </summary>
	public static T Mul<T>(this T a, T b) where T : IMultiplyOperators<T, T, T>
		=> a * b;

	/// <summary>
	/// Выполняет деление двух значений одного типа.
	/// </summary>
	public static T Div<T>(this T a, T b) where T : IDivisionOperators<T, T, T>
		=> a / b;

	/// <summary>
	/// Возвращает квадратный корень этого числа.
	/// </summary>
	public static double Sqrt(this double a) => Math.Sqrt(a);
}