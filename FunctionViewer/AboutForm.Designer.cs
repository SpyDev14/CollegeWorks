namespace FunctionViewer
{
	partial class AboutForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			Panel panel1;
			richTextBox1 = new RichTextBox();
			btnClose = new Button();
			pictureBox1 = new PictureBox();
			panel1 = new Panel();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// richTextBox1
			// 
			richTextBox1.BackColor = SystemColors.Control;
			richTextBox1.BorderStyle = BorderStyle.None;
			richTextBox1.Dock = DockStyle.Left;
			richTextBox1.Enabled = false;
			richTextBox1.ForeColor = SystemColors.InfoText;
			richTextBox1.HideSelection = false;
			richTextBox1.Location = new Point(0, 0);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.ReadOnly = true;
			richTextBox1.Size = new Size(240, 153);
			richTextBox1.TabIndex = 0;
			richTextBox1.Text = "";
			// 
			// btnClose
			// 
			btnClose.Dock = DockStyle.Bottom;
			btnClose.Location = new Point(8, 170);
			btnClose.Name = "btnClose";
			btnClose.Size = new Size(399, 34);
			btnClose.TabIndex = 1;
			btnClose.Text = "Закрыть";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += btnClose_Click;
			// 
			// pictureBox1
			// 
			pictureBox1.BorderStyle = BorderStyle.Fixed3D;
			pictureBox1.Dock = DockStyle.Right;
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new Point(246, 0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(153, 153);
			pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 2;
			pictureBox1.TabStop = false;
			// 
			// panel1
			// 
			panel1.Controls.Add(richTextBox1);
			panel1.Controls.Add(pictureBox1);
			panel1.Dock = DockStyle.Top;
			panel1.Location = new Point(8, 8);
			panel1.Name = "panel1";
			panel1.Size = new Size(399, 153);
			panel1.TabIndex = 3;
			// 
			// AboutForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ControlLight;
			ClientSize = new Size(415, 212);
			Controls.Add(panel1);
			Controls.Add(btnClose);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "AboutForm";
			Padding = new Padding(8);
			Text = "О программе";
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private RichTextBox richTextBox1;
		private Button btnClose;
		private PictureBox pictureBox1;
	}
}