namespace FunctionViewer
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			Application.Run(new EntranceForm());
		}

		internal static string FunctionStr { get; } = "ln|x+1|+√(3|x|)";
		internal static double Function(double x)
		{
			if (x == -1.0)
				return double.NaN;

			double logPart = Math.Log(Math.Abs(x + 1));
			double sqrtPart = Math.Sqrt(3.0 * Math.Abs(x));

			return logPart + sqrtPart;
		}

		internal static string GetName(uint version)
			=> $"Function Drawler №{version} by _b.VV(); // ISaP-33";
	}
}