﻿namespace RetroCheatEdit
{
	partial class ScriptEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptEditor));
			roslynEdit1 = new RoslynEdit();
			toolStrip1 = new ToolStrip();
			btnV8Execute = new ToolStripButton();
			toolStripDropDownButton1 = new ToolStripDropDownButton();
			sampleSnes1Menu = new ToolStripMenuItem();
			wizCharMenu = new ToolStripMenuItem();
			bcMenu = new ToolStripDropDownButton();
			textBox1 = new TextBox();
			splitContainer1 = new SplitContainer();
			toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			SuspendLayout();
			// 
			// roslynEdit1
			// 
			roslynEdit1.BackColor = Color.Gray;
			roslynEdit1.Dock = DockStyle.Fill;
			roslynEdit1.Font = new Font("ＭＳ ゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point);
			roslynEdit1.Location = new Point(0, 0);
			roslynEdit1.Name = "roslynEdit1";
			roslynEdit1.Size = new Size(742, 342);
			roslynEdit1.TabIndex = 1;
			// 
			// toolStrip1
			// 
			toolStrip1.Anchor = AnchorStyles.None;
			toolStrip1.AutoSize = false;
			toolStrip1.Dock = DockStyle.None;
			toolStrip1.Items.AddRange(new ToolStripItem[] { btnV8Execute, toolStripDropDownButton1, bcMenu });
			toolStrip1.Location = new Point(0, 22);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new Size(766, 25);
			toolStrip1.TabIndex = 2;
			toolStrip1.Text = "toolStrip1";
			// 
			// btnV8Execute
			// 
			btnV8Execute.AutoSize = false;
			btnV8Execute.BackColor = SystemColors.ControlLight;
			btnV8Execute.DisplayStyle = ToolStripItemDisplayStyle.Text;
			btnV8Execute.ForeColor = Color.Black;
			btnV8Execute.Image = (Image)resources.GetObject("btnV8Execute.Image");
			btnV8Execute.ImageTransparentColor = Color.Magenta;
			btnV8Execute.Margin = new Padding(5, 1, 5, 2);
			btnV8Execute.Name = "btnV8Execute";
			btnV8Execute.Padding = new Padding(5, 0, 5, 0);
			btnV8Execute.RightToLeft = RightToLeft.No;
			btnV8Execute.Size = new Size(100, 22);
			btnV8Execute.Text = "Execute";
			btnV8Execute.Click += btnV8Execute_Click;
			// 
			// toolStripDropDownButton1
			// 
			toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
			toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { sampleSnes1Menu, wizCharMenu });
			toolStripDropDownButton1.ForeColor = Color.FromArgb(10, 10, 10);
			toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
			toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
			toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			toolStripDropDownButton1.ShowDropDownArrow = false;
			toolStripDropDownButton1.Size = new Size(76, 22);
			toolStripDropDownButton1.Text = "SampleCode";
			// 
			// sampleSnes1Menu
			// 
			sampleSnes1Menu.Name = "sampleSnes1Menu";
			sampleSnes1Menu.Size = new Size(117, 22);
			sampleSnes1Menu.Text = "SNES1";
			// 
			// wizCharMenu
			// 
			wizCharMenu.Name = "wizCharMenu";
			wizCharMenu.Size = new Size(117, 22);
			wizCharMenu.Text = "WizChar";
			// 
			// bcMenu
			// 
			bcMenu.DisplayStyle = ToolStripItemDisplayStyle.Text;
			bcMenu.ForeColor = Color.FromArgb(23, 23, 23);
			bcMenu.Image = (Image)resources.GetObject("bcMenu.Image");
			bcMenu.ImageTransparentColor = Color.Magenta;
			bcMenu.Name = "bcMenu";
			bcMenu.Size = new Size(86, 22);
			bcMenu.Text = "BackupCode";
			// 
			// textBox1
			// 
			textBox1.BackColor = Color.FromArgb(230, 230, 230);
			textBox1.BorderStyle = BorderStyle.FixedSingle;
			textBox1.Dock = DockStyle.Fill;
			textBox1.Font = new Font("ＭＳ ゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			textBox1.ForeColor = Color.FromArgb(60, 60, 60);
			textBox1.Location = new Point(0, 0);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.ScrollBars = ScrollBars.Both;
			textBox1.Size = new Size(742, 182);
			textBox1.TabIndex = 3;
			// 
			// splitContainer1
			// 
			splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer1.Location = new Point(12, 50);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Orientation = Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(roslynEdit1);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(textBox1);
			splitContainer1.Size = new Size(742, 528);
			splitContainer1.SplitterDistance = 342;
			splitContainer1.TabIndex = 4;
			// 
			// ScriptEditor
			// 
			ClientSize = new Size(766, 590);
			ControlBox = false;
			Controls.Add(splitContainer1);
			Controls.Add(toolStrip1);
			MaximizeBox = false;
			MdiChildrenMinimizedAnchorBottom = false;
			MinimizeBox = false;
			Name = "ScriptEditor";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "ScriptEditor";
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private RoslynEdit roslynEdit1;
		private ToolStrip toolStrip1;
		private ToolStripButton btnV8Execute;
		private TextBox textBox1;
		private SplitContainer splitContainer1;
		private ToolStripDropDownButton toolStripDropDownButton1;
		private ToolStripMenuItem sampleSnes1Menu;
		private ToolStripMenuItem wizCharMenu;
		private ToolStripDropDownButton bcMenu;
	}
}