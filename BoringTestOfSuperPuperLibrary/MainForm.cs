using SuperPuperLibrary;

namespace BoringTestOfSuperPuperDuperUsefulLibrary;

public partial class MainForm : Form
{
	public MainForm()
	{
		InitializeComponent();
	}

	private void btnTest_Click(object sender, EventArgs e)
	{
		MessageBox.Show($"5 + 3 = {5.Add(3)}", $"Test {nameof(SuperCalculator.Add)}");
		MessageBox.Show($"5.1f + 3.9f = {5.1f.Add(3.9f)}", $"Test {nameof(SuperCalculator.Add)}");
		MessageBox.Show($"3L + (-5L) = {3L.Add(-5L)}", $"Test {nameof(SuperCalculator.Add)}");
		MessageBox.Show($"0.1f + 0.2f = {0.1f.Add(0.2f)}", $"Test {nameof(SuperCalculator.Add)} ;)");

		MessageBox.Show($"(1 - 2) * 5 - 8 / 4 + 3 = {
			1.Sub(2).Mul(5).Sub(
				8.Div(4)
			).Add(3)
		}", $"Test {
			nameof(SuperCalculator.Sub)}, {
			nameof(SuperCalculator.Mul)}, {
			nameof(SuperCalculator.Div)}, {
			nameof(SuperCalculator.Add)}"
		);

		try { 10.Div(0); }
		catch (DivideByZeroException)
		{
			MessageBox.Show(
				"10 / 0 = ОШИБКА: на 0 делить нельзя",
				$"Test {nameof(SuperCalculator.Div)}",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error
			);
		}

		MessageBox.Show($"Квадратный корень 15.34 = {15.35.Sqrt()}", $"Test {nameof(SuperCalculator.Sqrt)}");
	}
}
