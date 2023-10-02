namespace RetroCheatEdit
{
	partial class PpssppForm
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
			tbID = new TextBox();
			label1 = new Label();
			tbTitle = new TextBox();
			label2 = new Label();
			btnOK = new Button();
			btnCancel = new Button();
			SuspendLayout();
			// 
			// tbID
			// 
			tbID.BackColor = Color.FromArgb(64, 64, 64);
			tbID.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			tbID.ForeColor = Color.FromArgb(230, 230, 230);
			tbID.Location = new Point(95, 38);
			tbID.Name = "tbID";
			tbID.Size = new Size(220, 29);
			tbID.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(19, 41);
			label1.Name = "label1";
			label1.Size = new Size(56, 21);
			label1.TabIndex = 1;
			label1.Text = "PSP ID";
			// 
			// tbTitle
			// 
			tbTitle.BackColor = Color.FromArgb(64, 64, 64);
			tbTitle.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			tbTitle.ForeColor = Color.FromArgb(230, 230, 230);
			tbTitle.Location = new Point(95, 73);
			tbTitle.Name = "tbTitle";
			tbTitle.Size = new Size(220, 29);
			tbTitle.TabIndex = 2;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(19, 76);
			label2.Name = "label2";
			label2.Size = new Size(70, 21);
			label2.TabIndex = 3;
			label2.Text = "PSP Title";
			// 
			// btnOK
			// 
			btnOK.DialogResult = DialogResult.OK;
			btnOK.FlatStyle = FlatStyle.Flat;
			btnOK.Location = new Point(240, 125);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(75, 23);
			btnOK.TabIndex = 4;
			btnOK.Text = "OK";
			btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.FlatStyle = FlatStyle.Flat;
			btnCancel.Location = new Point(159, 125);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 5;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// PpssppForm
			// 
			AcceptButton = btnOK;
			AutoScaleMode = AutoScaleMode.None;
			CancelButton = btnCancel;
			ClientSize = new Size(334, 170);
			CloseAction = CloseAction.DRCancel;
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			Controls.Add(label2);
			Controls.Add(tbTitle);
			Controls.Add(label1);
			Controls.Add(tbID);
			Name = "PpssppForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "PSP ID and Title";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox tbID;
		private Label label1;
		private TextBox tbTitle;
		private Label label2;
		private Button btnOK;
		private Button btnCancel;
	}
}