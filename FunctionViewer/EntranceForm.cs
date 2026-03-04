namespace FunctionViewer
{
	public partial class EntranceForm : Form
	{
		public EntranceForm()
		{
			InitializeComponent();
		}

		void EnterToForm(Form form)
		{
			form.StartPosition = FormStartPosition.CenterScreen;
			form.Show();
			Hide();
			form.FormClosed += (s, e) => Close();
		}

		private void btnVer1_Click(object sender, EventArgs e)
			=> EnterToForm(new MainFormVer1());

		private void btnVer2_Click(object sender, EventArgs e)
			=> EnterToForm(new MainFormVer2());
	}
}
