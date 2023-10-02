using Microsoft.CodeAnalysis.CSharp.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RetroCheatEdit
{
	public class Root
	{
		public TextBox? Textbox = null;
		public Root()
		{
		}
		public void Append(string text)
		{
			if (Textbox !=null)
			{
				Textbox.AppendText(text);
			}
		}
		public void writeln(object? obj)
		{
			if (Textbox != null)
			{
				string s = ObjToString(obj);
				Textbox.AppendText(s +"\r\n");
			}
		}
		public void write(object? obj)
		{
			if (Textbox != null)
			{
				string s = ObjToString(obj);
				Textbox.AppendText(s);
			}
		}
		public void cls()
		{
			if (Textbox != null)
			{
				Textbox.Text = "";
			}
		}
		static public string ObjToString(object? obj)
		{
			string ret = "";
			if (obj == null)
			{
				ret = "null";
			}
			else if (obj is string)
			{
				ret = (string)obj;
			}
			else
			{
				ret = CSharpObjectFormatter.Instance.FormatObject(obj);
			}

			if (ret == null) { ret = "null"; }
			return ret;
		}
		public string IntToHex(int v)
		{
			return $"{v:x8}";
		}
		public int HexToInt(string s)
		{
			return Convert.ToInt32(s,16);
		}
	}
}

