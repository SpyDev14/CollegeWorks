using System.Collections.Immutable;
using System.Reflection;
using System.Text;

using SecondaryCourseWorks.Works;

namespace SecondaryCourseWorks;

internal class Program
{
	static void Main(string[] args)
	{
		ImmutableDictionary<string, Action> workNumToExecute = Assembly
			.GetExecutingAssembly()
			.GetTypes()
			.Where(t => t.BaseType == typeof(BasePracticalWork))
			.Select(Activator.CreateInstance)
			.OfType<BasePracticalWork>() // Только для типизации и отсечения null
			.ToImmutableDictionary<BasePracticalWork, string, Action>
				(work => work.Number, work => work.Execute);

		Console.WriteLine("Список работ: ");
		Console.WriteLine(string.Join('\n', workNumToExecute.Select(x => $" - {x.Key}")));
		Console.WriteLine("\nВведите номер практической для запуска, или exit, чтобы выйти.");
		while (true)
		{
			Console.Write(">>> ");
			string? answer = Console.ReadLine()?.Trim().ToLower();
			if (string.IsNullOrEmpty(answer))
			{
				Console.CursorTop -= 1;
				continue;
			}
			if (answer == "exit") break;

			if (!workNumToExecute.TryGetValue(answer, out var execute))
				Console.WriteLine("Такой работы нет.");
			else
			{
				try { execute(); }
				catch (Exception ex)
				{
					Console.WriteLine(
						$"Выполнение завершилось с ошибкой: {ex.Message}\n" +
						$"Код ошибки: {ex.HResult}"
					);
				}
			}
			Console.WriteLine();
		}
	}
}
