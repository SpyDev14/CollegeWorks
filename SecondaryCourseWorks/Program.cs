using System.Collections.Immutable;
using System.Reflection;
using SecondaryCourseWorks.Works;
using SecondaryCourseWorks.TextWriters;
using SecondaryCourseWorks.GotoException;


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

		Console.WriteLine($"\nВведите номер практической для запуска, или {Comma.EXIT}, чтобы выйти.");
		Console.WriteLine($"Также вы можете ввести {Comma.BREAK} во время любого ввода, чтобы сразу вернуться в главный цикл.");
		try
		{
			while (true)
			{
				string answer = Input(
					validation: (works.ContainsKey, $"Такой работы нет.\n{worksListStr}"),
					allowBreak: false // Главный цикл, тут есть exit
				);

				var oldOut = Console.Out;
				Console.SetOut(new IndentedTextWriter(oldOut, 1));

				var work = works[answer];
				if (work.Description != "")
				{
					Console.WriteLine("Описание задания");
					Console.WriteLine("----------------");
					Console.WriteLine(work.Description + "\n");
				}

				try { work.Execute(); }
#if DEBUG
				catch (BreakWorkProcessing) { }
				// Обычно использование исключений в качестве
				// goto является плохой практикой, но это
				// тот редкий случай, когда он действительно оправдан.
#else
				catch (Exception ex)
				{
					if (ex is not BreakWorkProcessing)
					{
						Console.WriteLine(
							$"Выполнение завершилось с ошибкой: {ex.Message}\n" +
							$"Код ошибки: {ex.HResult}"
						);
					}
				}
#endif
				Console.SetOut(oldOut);
				Console.WriteLine();
			}
		}
		catch (ProgrammExit) { }
	}
}
