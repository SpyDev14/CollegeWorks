namespace SecondaryCourseWorks.Works;

internal class PW51 : BasePracticalWork
{
	public override string Number => "5.1";

	public override void Execute()
	{
		var arr = GetRandomArray(100, -100, 100);
		Console.WriteLine($"Array: {arr.ToInformativeString()}");

		double summ = 0;
		foreach (var num in arr)
			if (num > 0 && num < 1)
			{

			}
		
	}
}
