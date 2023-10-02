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
			this.Size = new Size(400, 360);

		}
		/*
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
		*/
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
		private string[] SplitSpace(string s)
		{
			string[] ret = new string[2];
			ret[0] = ret[1] = "";
			int idx = s.IndexOf(' ');
			if (idx < 0)
			{
				ret[0] = s.Trim();
			}
			else
			{
				ret[0] = s.Substring(0, idx).Trim();
				ret[1] = s.Substring(idx + 1).Trim();
			}
			return ret;
		}
		// **************************************************************
		private bool isHexStr(string s)
		{
			bool ret = false;
			if (s.Length > 2)
			{
				ret = (s[1] == 'X' || s[1] == 'x');
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
				string[] lineA = SplitSpace(lines[i]);
				HexValue hv = new HexValue(lineA[0]);
				if (hv.Enabled)
				{
					hv.Add((int)addV);
					lineA[0] = hv.Str;
				}

				lines[i] = lineA[0] + " " + lineA[1];
			}
			textBox2.Lines = lines;
		}
		public void ResizeChk()
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
		}
		protected override void OnResize(EventArgs e)
		{
			ResizeChk();
			base.OnResize(e);

		}

	}
}
