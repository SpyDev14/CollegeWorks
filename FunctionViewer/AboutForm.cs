using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FunctionViewer;

public partial class AboutForm : Form
{
	public AboutForm()
	{
		InitializeComponent();

		richTextBox1.Text = """
		FunctionViewer v1.0.0
		Расчитывает значение функции на основе переданного аргумента.

		Разработана Букловским Владиславом Витальевичем из ИСиП-33 в 2026 году.
		""".Trim();
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}
}
