namespace BoringTestOfSuperPuperDuperUsefulLibrary
{
	partial class MainForm
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
			btnTest = new Button();
			SuspendLayout();
			// 
			// btnTest
			// 
			btnTest.Dock = DockStyle.Fill;
			btnTest.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnTest.Location = new Point(20, 20);
			btnTest.Name = "btnTest";
			btnTest.Size = new Size(203, 61);
			btnTest.TabIndex = 0;
			btnTest.Text = "Тест";
			btnTest.UseVisualStyleBackColor = true;
			btnTest.Click += btnTest_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(243, 101);
			Controls.Add(btnTest);
			Name = "MainForm";
			Padding = new Padding(20);
			Text = "Тест";
			ResumeLayout(false);
		}

		#endregion

		private Button btnTest;
	}
}
