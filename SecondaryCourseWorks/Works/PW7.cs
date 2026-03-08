using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SecondaryCourseWorks.Works;

internal class PW7p1 : BasePracticalWork
{
	public override string Number => "7p1";

	protected override string RawDescription => @"
		Разработать программу, которая для заданной
		строки s: меняет местами первую букву со второй,
		третью с четвертой и т.д.
	";

	public override void Execute()
	{
		string str = Input("Введите строку");
		var sb = new StringBuilder();

		for (int i = 0; i < str.Length; i += 2)
		{
			if (i + 1 < str.Length)
				sb.Append(str[i + 1]);
			sb.Append(str[i]);
		}

		Console.WriteLine($"Out: {sb}");
	}
}

internal class PW7p2 : BasePracticalWork
{
	public override string Number => "7p2";

	protected override string RawDescription => @"
		Вывести только те слова сообщения, которые
		содержат не более чем n букв.
	";

	public override void Execute()
	{
		var message = Input("Введите сообщение");
		var charsLimit = Input<int>(
			"Введите лимитв букв в слове (должно быть больше 1)",
			validation: ((n) => n > 0, "Должно быть больше 1го")
		);

		var words = Regex.Matches(message, @"\p{L}+").Select(m => m.Value);
		List<string> filteredWords = new();
		foreach (string word in words)
			if (word.Length <= charsLimit)
				filteredWords.Add(word);

		Console.WriteLine($"Слова меньше {charsLimit} букв:");
		Console.WriteLine(filteredWords.ToArray().Repr());
	}
}