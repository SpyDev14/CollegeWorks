using System.Collections.Immutable;
using System.Reflection;
using SecondaryCourseWorks.Works;


namespace SecondaryCourseWorks;
internal class Program
{
	static void Main(string[] args)
	{
		Console.ForegroundColor = ConsoleColor.Green;

		ImmutableDictionary<string, BasePracticalWork> works = Assembly
			.GetExecutingAssembly()
			.GetTypes()
			.Where(t => t.BaseType == typeof(BasePracticalWork))
			.Select(Activator.CreateInstance)
			.OfType<BasePracticalWork>() // Только для типизации и отсечения null
			.ToImmutableDictionary(work => work.Number, work => work);

		string worksListStr = $"Список работ: \n{
			string.Join('\n', works
				.OrderBy(x => x.Key)
				.Select(x => $" - {x.Key}"))
		}";
		Console.WriteLine(worksListStr);

		Console.WriteLine("\nВведите номер практической для запуска, или exit, чтобы выйти.");
		while (true)
		{
			string answer = Input(validation: ((a) => works.ContainsKey(a) || a == "exit", $"Такой работы нет.\n{worksListStr}"));
			if (answer == "exit") break;

			var oldOut = Console.Out;
			Console.SetOut(new IndentedTextWriter(oldOut, 1));

			var work = works[answer];
			if (work.Description != "")
			{
				Console.WriteLine("Описание задания");
				Console.WriteLine("----------------");
				Console.WriteLine(work.Description + "\n");
			}
#if DEBUG
			work.Execute();
#else
			try { work.Execute(); }
			catch (Exception ex)
			{
				Console.WriteLine(
					$"Выполнение завершилось с ошибкой: {ex.Message}\n" +
					$"Код ошибки: {ex.HResult}"
				);
			}
#endif
			Console.SetOut(oldOut);
			Console.WriteLine();
		}
	}
}
