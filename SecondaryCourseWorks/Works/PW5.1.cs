namespace SecondaryCourseWorks.Works;

internal class PW51 : BasePracticalWork
{
	public override string Number => "5.1";
	protected override string RawDescription => "";

	public override void Execute()
	{
		var arr = CreateRandomArray(100, -5d, 5d);
		Console.WriteLine($"Array: {arr.Select(x => $"{x:F2}").ToArray().Repr()}");

		int count = 0;
		double summ = 0;
		foreach (var num in arr) if (num > 0 && num < 1)
		{
			summ += num;
			count++;
		}

		Console.WriteLine($"Expression: 0 < num < 1");
		Console.WriteLine($"Total summ: {summ}");
		Console.WriteLine($"Count: {count}");
	}
}
