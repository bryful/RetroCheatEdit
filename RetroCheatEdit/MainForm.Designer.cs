namespace RetroCheatEdit
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			menuStrip1 = new MenuStrip();
			fileMenu = new ToolStripMenuItem();
			loadMenu = new ToolStripMenuItem();
			saveMenu = new ToolStripMenuItem();
			saveJohnMenu = new ToolStripMenuItem();
			saveRetroArchMenu = new ToolStripMenuItem();
			savePpssppMenu = new ToolStripMenuItem();
			saveDraSticMenu = new ToolStripMenuItem();
			quitMenu = new ToolStripMenuItem();
			toolMenu = new ToolStripMenuItem();
			calcFormMenu = new ToolStripMenuItem();
			pspIdTitleFormMenu = new ToolStripMenuItem();
			ccList1 = new CCList();
			btnAdd = new Button();
			btnDell = new Button();
			btnDown = new Button();
			btnUp = new Button();
			btnUpdate = new Button();
			cbEnabled = new CheckBox();
			tbCode = new TextBox();
			tbDesc = new TextBox();
			scriptEditorMenu = new ToolStripMenuItem();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Anchor = AnchorStyles.None;
			menuStrip1.AutoSize = false;
			menuStrip1.BackColor = SystemColors.Control;
			menuStrip1.Dock = DockStyle.None;
			menuStrip1.Font = new Font("ＭＳ ゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileMenu, toolMenu });
			menuStrip1.Location = new Point(0, 22);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(510, 24);
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileMenu
			// 
			fileMenu.BackColor = SystemColors.Control;
			fileMenu.DropDownItems.AddRange(new ToolStripItem[] { loadMenu, saveMenu, saveJohnMenu, saveRetroArchMenu, savePpssppMenu, saveDraSticMenu, quitMenu });
			fileMenu.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			fileMenu.ForeColor = SystemColors.ControlText;
			fileMenu.Name = "fileMenu";
			fileMenu.Size = new Size(39, 20);
			fileMenu.Text = "File";
			// 
			// loadMenu
			// 
			loadMenu.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			loadMenu.Name = "loadMenu";
			loadMenu.ShortcutKeys = Keys.Control | Keys.O;
			loadMenu.Size = new Size(206, 22);
			loadMenu.Text = "Load";
			// 
			// saveMenu
			// 
			saveMenu.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			saveMenu.Name = "saveMenu";
			saveMenu.ShortcutKeys = Keys.Control | Keys.S;
			saveMenu.Size = new Size(206, 22);
			saveMenu.Text = "Save";
			// 
			// saveJohnMenu
			// 
			saveJohnMenu.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			saveJohnMenu.Name = "saveJohnMenu";
			saveJohnMenu.ShortcutKeys = Keys.Control | Keys.J;
			saveJohnMenu.Size = new Size(206, 22);
			saveJohnMenu.Text = "SaveJohn";
			// 
			// saveRetroArchMenu
			// 
			saveRetroArchMenu.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			saveRetroArchMenu.Name = "saveRetroArchMenu";
			saveRetroArchMenu.ShortcutKeys = Keys.Control | Keys.R;
			saveRetroArchMenu.Size = new Size(206, 22);
			saveRetroArchMenu.Text = "SaveRetroArch";
			// 
			// savePpssppMenu
			// 
			savePpssppMenu.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			savePpssppMenu.Name = "savePpssppMenu";
			savePpssppMenu.Size = new Size(206, 22);
			savePpssppMenu.Text = "SavePpsspp";
			// 
			// saveDraSticMenu
			// 
			saveDraSticMenu.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			saveDraSticMenu.Name = "saveDraSticMenu";
			saveDraSticMenu.Size = new Size(206, 22);
			saveDraSticMenu.Text = "SaveDraStic";
			// 
			// quitMenu
			// 
			quitMenu.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			quitMenu.Name = "quitMenu";
			quitMenu.Size = new Size(206, 22);
			quitMenu.Text = "Quit";
			// 
			// toolMenu
			// 
			toolMenu.DropDownItems.AddRange(new ToolStripItem[] { calcFormMenu, pspIdTitleFormMenu, scriptEditorMenu });
			toolMenu.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			toolMenu.Name = "toolMenu";
			toolMenu.Size = new Size(41, 20);
			toolMenu.Text = "Tool";
			// 
			// calcFormMenu
			// 
			calcFormMenu.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			calcFormMenu.Name = "calcFormMenu";
			calcFormMenu.Size = new Size(180, 22);
			calcFormMenu.Text = "CalcForm";
			// 
			// pspIdTitleFormMenu
			// 
			pspIdTitleFormMenu.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			pspIdTitleFormMenu.Name = "pspIdTitleFormMenu";
			pspIdTitleFormMenu.Size = new Size(180, 22);
			pspIdTitleFormMenu.Text = "PspIdTitleForm";
			// 
			// ccList1
			// 
			ccList1.BackColor = Color.FromArgb(64, 64, 64);
			ccList1.BorderStyle = BorderStyle.FixedSingle;
			ccList1.btnAdd = btnAdd;
			ccList1.btnDell = btnDell;
			ccList1.btnDown = btnDown;
			ccList1.btnUp = btnUp;
			ccList1.btnUpdate = btnUpdate;
			ccList1.cbEnabled = cbEnabled;
			ccList1.Font = new Font("ＭＳ ゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			ccList1.ForeColor = Color.FromArgb(230, 230, 230);
			ccList1.FormattingEnabled = true;
			ccList1.IntegralHeight = false;
			ccList1.ItemHeight = 19;
			ccList1.Location = new Point(12, 95);
			ccList1.Name = "ccList1";
			ccList1.Size = new Size(249, 122);
			ccList1.TabIndex = 2;
			ccList1.TextBoxCodes = tbCode;
			ccList1.TextBoxDesc = tbDesc;
			// 
			// btnAdd
			// 
			btnAdd.FlatStyle = FlatStyle.Flat;
			btnAdd.Font = new Font("ＭＳ ゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			btnAdd.Location = new Point(267, 67);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(70, 23);
			btnAdd.TabIndex = 6;
			btnAdd.Text = "Add";
			btnAdd.UseVisualStyleBackColor = true;
			// 
			// btnDell
			// 
			btnDell.FlatStyle = FlatStyle.Flat;
			btnDell.Font = new Font("ＭＳ ゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			btnDell.Location = new Point(12, 65);
			btnDell.Name = "btnDell";
			btnDell.Size = new Size(70, 23);
			btnDell.TabIndex = 8;
			btnDell.Text = "Dell";
			btnDell.UseVisualStyleBackColor = true;
			// 
			// btnDown
			// 
			btnDown.FlatStyle = FlatStyle.Flat;
			btnDown.Font = new Font("ＭＳ ゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			btnDown.Location = new Point(164, 66);
			btnDown.Name = "btnDown";
			btnDown.Size = new Size(70, 23);
			btnDown.TabIndex = 10;
			btnDown.Text = "Down";
			btnDown.UseVisualStyleBackColor = true;
			// 
			// btnUp
			// 
			btnUp.FlatStyle = FlatStyle.Flat;
			btnUp.Font = new Font("ＭＳ ゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			btnUp.Location = new Point(88, 67);
			btnUp.Name = "btnUp";
			btnUp.Size = new Size(70, 23);
			btnUp.TabIndex = 9;
			btnUp.Text = "Up";
			btnUp.UseVisualStyleBackColor = true;
			// 
			// btnUpdate
			// 
			btnUpdate.FlatStyle = FlatStyle.Flat;
			btnUpdate.Font = new Font("ＭＳ ゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			btnUpdate.Location = new Point(343, 67);
			btnUpdate.Name = "btnUpdate";
			btnUpdate.Size = new Size(70, 23);
			btnUpdate.TabIndex = 7;
			btnUpdate.Text = "Update";
			btnUpdate.UseVisualStyleBackColor = true;
			// 
			// cbEnabled
			// 
			cbEnabled.AutoSize = true;
			cbEnabled.Font = new Font("ＭＳ ゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			cbEnabled.Location = new Point(429, 70);
			cbEnabled.Name = "cbEnabled";
			cbEnabled.Size = new Size(75, 17);
			cbEnabled.TabIndex = 5;
			cbEnabled.Text = "Enabled";
			cbEnabled.UseVisualStyleBackColor = true;
			// 
			// tbCode
			// 
			tbCode.BackColor = Color.FromArgb(64, 64, 64);
			tbCode.BorderStyle = BorderStyle.FixedSingle;
			tbCode.Font = new Font("ＭＳ ゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			tbCode.ForeColor = Color.FromArgb(230, 230, 230);
			tbCode.Location = new Point(267, 130);
			tbCode.Multiline = true;
			tbCode.Name = "tbCode";
			tbCode.ScrollBars = ScrollBars.Both;
			tbCode.Size = new Size(230, 86);
			tbCode.TabIndex = 4;
			// 
			// tbDesc
			// 
			tbDesc.BackColor = Color.FromArgb(64, 64, 64);
			tbDesc.BorderStyle = BorderStyle.FixedSingle;
			tbDesc.Font = new Font("ＭＳ ゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			tbDesc.ForeColor = Color.FromArgb(230, 230, 230);
			tbDesc.Location = new Point(267, 95);
			tbDesc.Name = "tbDesc";
			tbDesc.Size = new Size(230, 26);
			tbDesc.TabIndex = 3;
			// 
			// scriptEditorToolStripMenuItem
			// 
			scriptEditorMenu.Name = "scriptEditorToolStripMenuItem";
			scriptEditorMenu.Size = new Size(180, 22);
			scriptEditorMenu.Text = "ScriptEditor";
			// 
			// MainForm
			// 
			AllowDrop = true;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(64, 64, 64);
			ClientSize = new Size(510, 227);
			Controls.Add(btnDown);
			Controls.Add(btnUp);
			Controls.Add(btnDell);
			Controls.Add(btnUpdate);
			Controls.Add(btnAdd);
			Controls.Add(cbEnabled);
			Controls.Add(tbCode);
			Controls.Add(tbDesc);
			Controls.Add(ccList1);
			Controls.Add(menuStrip1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = menuStrip1;
			MinimumSize = new Size(510, 220);
			Name = "MainForm";
			Text = "RetroCheatEdit";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileMenu;
		private ToolStripMenuItem quitMenu;
		private CCList ccList1;
		private TextBox tbDesc;
		private TextBox tbCode;
		private CheckBox cbEnabled;
		private Button btnAdd;
		private Button btnUpdate;
		private Button btnDell;
		private Button btnUp;
		private Button btnDown;
		private ToolStripMenuItem toolMenu;
		private ToolStripMenuItem calcFormMenu;
		private ToolStripMenuItem loadMenu;
		private ToolStripMenuItem saveMenu;
		private ToolStripMenuItem saveJohnMenu;
		private ToolStripMenuItem saveRetroArchMenu;
		private ToolStripMenuItem savePpssppMenu;
		private ToolStripMenuItem pspIdTitleFormMenu;
		private ToolStripMenuItem saveDraSticMenu;
		private ToolStripMenuItem scriptEditorMenu;
	}
}