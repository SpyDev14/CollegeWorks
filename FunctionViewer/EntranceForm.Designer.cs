namespace FunctionViewer
{
	partial class EntranceForm
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
			Label label1;
			btnVer1 = new Button();
			btnVer2 = new Button();
			btnVer3 = new Button();
			btnVer4 = new Button();
			label1 = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.Dock = DockStyle.Top;
			label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label1.Location = new Point(10, 10);
			label1.Name = "label1";
			label1.Size = new Size(119, 28);
			label1.TabIndex = 1;
			label1.Text = "Выберите версию";
			label1.TextAlign = ContentAlignment.TopCenter;
			// 
			// btnVer1
			// 
			btnVer1.Dock = DockStyle.Top;
			btnVer1.Location = new Point(10, 38);
			btnVer1.Name = "btnVer1";
			btnVer1.Size = new Size(119, 30);
			btnVer1.TabIndex = 0;
			btnVer1.Text = "Version 1";
			btnVer1.UseVisualStyleBackColor = true;
			btnVer1.Click += btnVer1_Click;
			// 
			// btnVer2
			// 
			btnVer2.Dock = DockStyle.Top;
			btnVer2.Location = new Point(10, 68);
			btnVer2.Name = "btnVer2";
			btnVer2.Size = new Size(119, 30);
			btnVer2.TabIndex = 2;
			btnVer2.Text = "Version 2";
			btnVer2.UseVisualStyleBackColor = true;
			btnVer2.Click += btnVer2_Click;
			// 
			// btnVer3
			// 
			btnVer3.Dock = DockStyle.Top;
			btnVer3.Enabled = false;
			btnVer3.Location = new Point(10, 98);
			btnVer3.Name = "btnVer3";
			btnVer3.Size = new Size(119, 30);
			btnVer3.TabIndex = 3;
			btnVer3.Text = "Version 3";
			btnVer3.UseVisualStyleBackColor = true;
			// 
			// btnVer4
			// 
			btnVer4.Dock = DockStyle.Top;
			btnVer4.Enabled = false;
			btnVer4.Location = new Point(10, 128);
			btnVer4.Name = "btnVer4";
			btnVer4.Size = new Size(119, 30);
			btnVer4.TabIndex = 4;
			btnVer4.Text = "Version 4";
			btnVer4.UseVisualStyleBackColor = true;
			// 
			// EntranceForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(139, 167);
			Controls.Add(btnVer4);
			Controls.Add(btnVer3);
			Controls.Add(btnVer2);
			Controls.Add(btnVer1);
			Controls.Add(label1);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "EntranceForm";
			Padding = new Padding(10);
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Entrance";
			ResumeLayout(false);
		}

		#endregion

		private Button btnVer1;
		private Button btnVer2;
		private Button btnVer3;
		private Button btnVer4;
	}
}