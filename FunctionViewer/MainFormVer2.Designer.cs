namespace FunctionViewer
{
	partial class MainFormVer2
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			PictureBox pictureBox1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormVer2));
			Label label1;
			Label label2;
			Label label3;
			Label label5;
			Label label6;
			dataGridView1 = new DataGridView();
			X = new DataGridViewTextBoxColumn();
			Y = new DataGridViewTextBoxColumn();
			inputFrom = new TextBox();
			inputTo = new TextBox();
			inputStep = new TextBox();
			btnRecalculate = new Button();
			maxFuncValueTextBox = new TextBox();
			minFuncValueTextBox = new TextBox();
			pictureBox1 = new PictureBox();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label5 = new Label();
			label6 = new Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// pictureBox1
			// 
			pictureBox1.BorderStyle = BorderStyle.FixedSingle;
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
			pictureBox1.Location = new Point(12, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(193, 65);
			pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			label1.Location = new Point(12, 86);
			label1.Name = "label1";
			label1.Size = new Size(35, 15);
			label1.TabIndex = 2;
			label1.Text = "From";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			label2.Location = new Point(12, 115);
			label2.Name = "label2";
			label2.Size = new Size(20, 15);
			label2.TabIndex = 4;
			label2.Text = "To";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			label3.Location = new Point(12, 144);
			label3.Name = "label3";
			label3.Size = new Size(31, 15);
			label3.TabIndex = 7;
			label3.Text = "Step";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(12, 176);
			label5.Name = "label5";
			label5.Size = new Size(141, 15);
			label5.TabIndex = 13;
			label5.Text = "Минимальное значение";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(12, 224);
			label6.Name = "label6";
			label6.Size = new Size(145, 15);
			label6.TabIndex = 14;
			label6.Text = "Максимальное значение";
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.AllowUserToResizeRows = false;
			dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { X, Y });
			dataGridView1.Location = new Point(211, 12);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.Size = new Size(248, 309);
			dataGridView1.TabIndex = 1;
			// 
			// X
			// 
			X.HeaderText = "X";
			X.Name = "X";
			X.ReadOnly = true;
			X.Width = 39;
			// 
			// Y
			// 
			Y.HeaderText = "Y";
			Y.Name = "Y";
			Y.ReadOnly = true;
			Y.Width = 39;
			// 
			// inputFrom
			// 
			inputFrom.Location = new Point(49, 83);
			inputFrom.Name = "inputFrom";
			inputFrom.Size = new Size(156, 23);
			inputFrom.TabIndex = 3;
			inputFrom.Text = "-10";
			// 
			// inputTo
			// 
			inputTo.Location = new Point(49, 112);
			inputTo.Name = "inputTo";
			inputTo.Size = new Size(156, 23);
			inputTo.TabIndex = 5;
			inputTo.Text = "10";
			// 
			// inputStep
			// 
			inputStep.Location = new Point(49, 141);
			inputStep.Name = "inputStep";
			inputStep.Size = new Size(156, 23);
			inputStep.TabIndex = 6;
			inputStep.Text = "0.5";
			// 
			// btnRecalculate
			// 
			btnRecalculate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btnRecalculate.Location = new Point(12, 291);
			btnRecalculate.Name = "btnReCalc";
			btnRecalculate.Size = new Size(193, 30);
			btnRecalculate.TabIndex = 10;
			btnRecalculate.Text = "Расчитать";
			btnRecalculate.UseVisualStyleBackColor = true;
			// 
			// maxFuncValueTextBox
			// 
			maxFuncValueTextBox.Location = new Point(12, 245);
			maxFuncValueTextBox.Name = "maxFuncValueTextBox";
			maxFuncValueTextBox.ReadOnly = true;
			maxFuncValueTextBox.Size = new Size(193, 23);
			maxFuncValueTextBox.TabIndex = 11;
			// 
			// minFuncValueTextBox
			// 
			minFuncValueTextBox.Location = new Point(12, 194);
			minFuncValueTextBox.Name = "minFuncValueTextBox";
			minFuncValueTextBox.ReadOnly = true;
			minFuncValueTextBox.Size = new Size(193, 23);
			minFuncValueTextBox.TabIndex = 12;
			// 
			// MainFormVer2
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(469, 333);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(minFuncValueTextBox);
			Controls.Add(maxFuncValueTextBox);
			Controls.Add(btnRecalculate);
			Controls.Add(label3);
			Controls.Add(inputStep);
			Controls.Add(inputTo);
			Controls.Add(label2);
			Controls.Add(inputFrom);
			Controls.Add(label1);
			Controls.Add(dataGridView1);
			Controls.Add(pictureBox1);
			Name = "MainFormVer2";
			Text = "MainFormVer2";
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dataGridView1;
		private TextBox inputFrom;
		private TextBox inputTo;
		private TextBox inputStep;
		private DataGridViewTextBoxColumn X;
		private DataGridViewTextBoxColumn Y;
		private Button btnRecalculate;
		private TextBox maxFuncValueTextBox;
		private TextBox minFuncValueTextBox;
	}
}