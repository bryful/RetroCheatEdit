namespace RetroCheatEdit
{
	partial class CalcForm
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
			textBox1 = new TextBox();
			btnAdd = new Button();
			tbAdd = new TextBox();
			textBox2 = new TextBox();
			SuspendLayout();
			// 
			// textBox1
			// 
			textBox1.BackColor = Color.FromArgb(64, 64, 64);
			textBox1.BorderStyle = BorderStyle.FixedSingle;
			textBox1.Font = new Font("ＭＳ ゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			textBox1.ForeColor = Color.FromArgb(230, 230, 230);
			textBox1.Location = new Point(14, 61);
			textBox1.MaxLength = 65536;
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ScrollBars = ScrollBars.Both;
			textBox1.Size = new Size(392, 118);
			textBox1.TabIndex = 0;
			// 
			// btnAdd
			// 
			btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnAdd.FlatStyle = FlatStyle.Flat;
			btnAdd.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnAdd.Location = new Point(285, 25);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(103, 29);
			btnAdd.TabIndex = 2;
			btnAdd.Text = "Add";
			btnAdd.UseVisualStyleBackColor = true;
			// 
			// tbAdd
			// 
			tbAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbAdd.BackColor = Color.FromArgb(64, 64, 64);
			tbAdd.BorderStyle = BorderStyle.FixedSingle;
			tbAdd.Font = new Font("ＭＳ ゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			tbAdd.ForeColor = Color.FromArgb(230, 230, 230);
			tbAdd.Location = new Point(14, 30);
			tbAdd.Name = "tbAdd";
			tbAdd.Size = new Size(267, 26);
			tbAdd.TabIndex = 3;
			tbAdd.Text = "8000";
			tbAdd.TextAlign = HorizontalAlignment.Right;
			// 
			// textBox2
			// 
			textBox2.BackColor = Color.FromArgb(64, 64, 64);
			textBox2.BorderStyle = BorderStyle.FixedSingle;
			textBox2.Font = new Font("ＭＳ ゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			textBox2.ForeColor = Color.FromArgb(230, 230, 230);
			textBox2.Location = new Point(14, 190);
			textBox2.MaxLength = 65536;
			textBox2.Multiline = true;
			textBox2.Name = "textBox2";
			textBox2.ScrollBars = ScrollBars.Both;
			textBox2.Size = new Size(392, 159);
			textBox2.TabIndex = 4;
			// 
			// CalcForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(400, 360);
			Controls.Add(textBox2);
			Controls.Add(tbAdd);
			Controls.Add(btnAdd);
			Controls.Add(textBox1);
			IsAnti = true;
			MinimumSize = new Size(240, 240);
			Name = "CalcForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "CalcForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox1;
		private Button btnAdd;
		private TextBox tbAdd;
		private TextBox textBox2;
	}
}