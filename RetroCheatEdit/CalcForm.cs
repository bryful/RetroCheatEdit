using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroCheatEdit
{
	public partial class CalcForm : BaseForm
	{
		public CalcForm()
		{
			InitializeComponent();

			btnAdd.Click += (sender, e) => { Calc(); };
		}
		private string ChkStr(string s)
		{
			string ret = "";
			if (s.Length > 0)
			{
				for (int i = 0; i < s.Length; i++)
				{
					char c = s[i];
					if (
						((c >= '0') && (c <= '9'))
						|| ((c >= 'A') && (c <= 'Z'))
						|| ((c >= 'a') && (c <= 'z'))
						|| (c == '+')
						|| (c == '-')
					)
					{
						ret += c;
					}
				}
			}
			return ret;
		}
		public void Paste()
		{
			string s = Clipboard.GetText().Trim();
			if (s == "") return;
			string[] sa = s.Split('\n');
			if (sa.Length <= 0) return;
			List<string> ret = new List<string>();
			foreach (string s2 in sa)
			{
				string s3 = ChkStr(s2);
				if (s3 != "")
				{
					ret.Add(s3);
				}
			}
			textBox1.Lines = ret.ToArray();
		}

		// **************************************************************
		private int? ToInt(string s)
		{
			int? ret = null;
			try
			{
				ret = Convert.ToInt32(s, 16);
			}
			catch
			{
				ret = null;
			}
			return ret;
		}
		// **************************************************************

		public void Calc()
		{
			if (textBox1.Text == "") return;
			int? addV = ToInt(tbAdd.Text);
			if (addV == null) return;
			string[] lines = textBox1.Lines;
			int cnt = lines.Length;
			for (int i = 0; i < cnt; i++)
			{
				int? v = ToInt(lines[i]);
				if (v != null)
				{
					v = v + addV;
					lines[i] = Convert.ToString((int)v, 16).ToUpper();
				}
			}
			textBox2.Lines = lines;
		}
		protected override void OnResize(EventArgs e)
		{
			if (textBox1 != null)
			{
				int w = this.Width - 20;
				int h = (this.Height - textBox1.Top - 10 - 5) / 2;
				textBox1.Location = new Point(10, 60);
				textBox1.Size = new Size(w, h); ;
				textBox2.Location = new Point(10, textBox1.Bottom + 5);
				textBox2.Size = new Size(w, h); ;
				this.Refresh();
			}
			base.OnResize(e);

		}
	}
}
