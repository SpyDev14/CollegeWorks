namespace FunctionViewer
{
	partial class MainFormVer1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Panel panel1;
			Label label1;
			Panel panel2;
			Label label2;
			Label label3;
			Panel panel3;
			btnExit = new Button();
			btnAbout = new Button();
			btnCalc = new Button();
			inputX = new TextBox();
			calculatedYTextBox = new TextBox();
			lblFunction = new Label();
			panel1 = new Panel();
			label1 = new Label();
			panel2 = new Panel();
			label2 = new Label();
			label3 = new Label();
			panel3 = new Panel();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Controls.Add(btnExit);
			panel1.Controls.Add(btnAbout);
			panel1.Controls.Add(btnCalc);
			panel1.Dock = DockStyle.Top;
			panel1.Location = new Point(6, 6);
			panel1.Name = "panel1";
			panel1.Padding = new Padding(0, 0, 0, 6);
			panel1.Size = new Size(365, 36);
			panel1.TabIndex = 0;
			// 
			// btnExit
			// 
			btnExit.AutoSize = true;
			btnExit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnExit.BackColor = SystemColors.ControlLight;
			btnExit.Dock = DockStyle.Right;
			btnExit.Location = new Point(335, 0);
			btnExit.Name = "btnExit";
			btnExit.Padding = new Padding(3);
			btnExit.Size = new Size(30, 30);
			btnExit.TabIndex = 4;
			btnExit.Text = "X";
			btnExit.UseVisualStyleBackColor = false;
			btnExit.Click += btnExit_Click;
			// 
			// btnAbout
			// 
			btnAbout.AutoSize = true;
			btnAbout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnAbout.Dock = DockStyle.Left;
			btnAbout.Location = new Point(72, 0);
			btnAbout.Name = "btnAbout";
			btnAbout.Size = new Size(92, 30);
			btnAbout.TabIndex = 3;
			btnAbout.Text = "О программе";
			btnAbout.UseVisualStyleBackColor = true;
			btnAbout.Click += btnAbout_Click;
			// 
			// btnCalc
			// 
			btnCalc.AutoSize = true;
			btnCalc.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnCalc.Dock = DockStyle.Left;
			btnCalc.Location = new Point(0, 0);
			btnCalc.Name = "btnCalc";
			btnCalc.Size = new Size(72, 30);
			btnCalc.TabIndex = 2;
			btnCalc.Text = "Расчитать";
			btnCalc.UseVisualStyleBackColor = true;
			btnCalc.Click += btnCalc_Click;
			// 
			// label1
			// 
			label1.Dock = DockStyle.Top;
			label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
			label1.ImageAlign = ContentAlignment.BottomCenter;
			label1.Location = new Point(6, 42);
			label1.Name = "label1";
			label1.Size = new Size(365, 27);
			label1.TabIndex = 1;
			label1.Text = "Вычисление значения функции";
			label1.TextAlign = ContentAlignment.BottomCenter;
			// 
			// panel2
			// 
			panel2.Controls.Add(label2);
			panel2.Controls.Add(inputX);
			panel2.Dock = DockStyle.Top;
			panel2.Location = new Point(6, 97);
			panel2.Name = "panel2";
			panel2.Padding = new Padding(0, 12, 0, 0);
			panel2.Size = new Size(365, 35);
			panel2.TabIndex = 4;
			// 
			// label2
			// 
			label2.Dock = DockStyle.Left;
			label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
			label2.Location = new Point(0, 12);
			label2.Name = "label2";
			label2.Padding = new Padding(0, 0, 0, 4);
			label2.Size = new Size(72, 23);
			label2.TabIndex = 3;
			label2.Text = "Значение X";
			label2.TextAlign = ContentAlignment.BottomLeft;
			// 
			// inputX
			// 
			inputX.Dock = DockStyle.Right;
			inputX.Location = new Point(161, 12);
			inputX.Name = "inputX";
			inputX.Size = new Size(204, 23);
			inputX.TabIndex = 1;
			inputX.TextChanged += inputX_TextChanged;
			// 
			// label3
			// 
			label3.Dock = DockStyle.Left;
			label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
			label3.Location = new Point(0, 12);
			label3.Name = "label3";
			label3.Padding = new Padding(0, 0, 0, 4);
			label3.Size = new Size(70, 23);
			label3.TabIndex = 4;
			label3.Text = "Значение Y";
			label3.TextAlign = ContentAlignment.BottomLeft;
			// 
			// panel3
			// 
			panel3.Controls.Add(label3);
			panel3.Controls.Add(calculatedYTextBox);
			panel3.Dock = DockStyle.Top;
			panel3.Location = new Point(6, 132);
			panel3.Name = "panel3";
			panel3.Padding = new Padding(0, 12, 0, 0);
			panel3.Size = new Size(365, 35);
			panel3.TabIndex = 5;
			// 
			// calculatedYTextBox
			// 
			calculatedYTextBox.Dock = DockStyle.Right;
			calculatedYTextBox.Location = new Point(161, 12);
			calculatedYTextBox.Name = "calculatedYTextBox";
			calculatedYTextBox.ReadOnly = true;
			calculatedYTextBox.Size = new Size(204, 23);
			calculatedYTextBox.TabIndex = 3;
			// 
			// lblFunction
			// 
			lblFunction.Dock = DockStyle.Top;
			lblFunction.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
			lblFunction.ForeColor = SystemColors.GrayText;
			lblFunction.Location = new Point(6, 69);
			lblFunction.Name = "lblFunction";
			lblFunction.Size = new Size(365, 28);
			lblFunction.TabIndex = 6;
			lblFunction.Text = "sin(x + 3) / e^(2x) + cos(x + 1)";
			lblFunction.TextAlign = ContentAlignment.TopCenter;
			// 
			// MainFormVer1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(377, 184);
			Controls.Add(panel3);
			Controls.Add(panel2);
			Controls.Add(lblFunction);
			Controls.Add(label1);
			Controls.Add(panel1);
			Name = "MainFormVer1";
			Padding = new Padding(6);
			Text = "Function Drawler №1 by _b.VV(); // ISaP-33";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Button btnExit;
		private Button btnAbout;
		private Button btnCalc;
		private TextBox inputX;
		private TextBox calculatedYTextBox;
		private Label lblFunction;
	}
}
