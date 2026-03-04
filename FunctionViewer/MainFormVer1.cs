namespace FunctionViewer;

public partial class MainFormVer1 : Form
{
	public MainFormVer1()
	{
		InitializeComponent();
		Text = Program.GetName(version: 1);
		lblFunction.Text = Program.FunctionStr;

	}

	void UpdateCalculations()
	{
		if (!inputX.Text.TryParseToDouble(out double x))
		{
			calculatedYTextBox.Text = "Неправильный ввод";
			return;
		}

		var y = Program.Function(x);
		calculatedYTextBox.Text = double.IsNaN(y) ? "Не число" : y.ToString();
	}

	private void btnAbout_Click(object sender, EventArgs e)
		=> new AboutForm().Show();

	private void btnExit_Click(object sender, EventArgs e)
		=> Close();

	private void inputX_TextChanged(object sender, EventArgs e)
		=> UpdateCalculations();

	private void btnCalc_Click(object sender, EventArgs e)
		=> UpdateCalculations();
}
