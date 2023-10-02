using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCheatEdit
{
	public class CheatCode
	{
		public void Clear()
		{
			m_desc = "";
			m_Codes.Clear();
		}
		private string m_desc = "";
		public string Desc { get { return m_desc; } }
		public void SetDesc (string s) {  m_desc = s; }
		private bool m_enabled = false;
		public bool Enabled { get { return m_enabled; } }
		public void SetEnabled(bool b) { m_enabled = b; }
		private List<string> m_Codes = new List<string>();
		public void SetCodes(string[] sa)
		{
			m_Codes.Clear();
			foreach (string s in sa)
			{
				if (s != "")
				{
					m_Codes.Add(s);
				}
			}
		}
		public void AddCode(string s)
		{
			m_Codes.Add (s);
		}
		public int CodeCount
		{
			get
			{
				return m_Codes.Count;
			}
		}
		public string Code
		{
			get { return string.Join("\r\n", m_Codes); }
			set
			{
				m_Codes.Clear();
				value = value.Trim();
				if(value!="")
				{
					string[] sa = value.Split("\r\n");
					foreach(string s in sa)
					{
						m_Codes.Add(s);
					}
				}
			}
		}
		public CheatCode(string s) 
		{
			m_desc = s;
		}
		public CheatCode(CheatCode cc)
		{
			Copy(cc);
		}
		public void Copy(CheatCode cc)
		{
			m_Codes.Clear();
			foreach(string s in cc.m_Codes)
			{
				m_Codes.Add(s);
			}
			m_desc = cc.m_desc;
			m_enabled = cc.m_enabled;
		}
		public bool SetJohnItemStr(string s)
		{
			bool ret = false;
			m_desc = "";
			m_Codes.Clear ();
			m_enabled = false;
			string KeyV(string ss, string s)
			{
				string r = "";
				int idx = ss.IndexOf(s);
				if (idx >= 0)
				{
					int idx0 = -1;
					int idx1 = -1;
					idx0 = ss.IndexOf("\"", idx + s.Length);
					if (idx0 >= 0)
					{
						idx0 += 1;
						idx1 = ss.IndexOf("\"", idx0);
						if(idx1>0)
						{
							r = ss.Substring(idx0, idx1-idx0);
						}
					}
				}
				return r;
			}
			string nm = KeyV(s, "name");
			if (nm !="")
			{
				m_desc = nm;
				ret = true;
			}
			string cd = KeyV(s, "code");
			if (cd != "")
			{
				string[] sa = cd.Split("&#10;");
				if (sa.Length > 0)
				{
					for(int i=0; i< sa.Length;i++)
					{
						sa[i] = sa[i].Trim();
						if (sa[i]!="")
						{
							m_Codes.Add(sa[i]);
						}
					}
				}
			}

			string dis = KeyV(s, "disabled");
			if(dis != "true")
			{
				m_enabled = true;
			}

			return ret;
		}
		public string JonItemStr
		{
			get
			{
				string ret = "";
				if (m_enabled==false)
				{
					ret += "disabled=\"true\" ";
				}
				ret += "code=\"";
				ret += string.Join("&#10;", m_Codes);
				ret += "\" name=\"" + m_desc + "\"";

				ret = "<item " + ret + " />";
				return ret;
			}

		}

		public string RetroACode(int idx)
		{
			string ret = "";
			string e = "false";
			if (m_enabled == true) e = "true";
			ret += $"cheat{idx}_desc = \"{m_desc}\"\n";
			ret += $"cheat{idx}_code = \"{string.Join("+",m_Codes)}\"\n";
			ret += $"cheat{idx}_enable = \"{e}\"\n";
			return ret;
		}

		public string PpssppCode()
		{
			string ret = "";

			ret += "_C0 " + m_desc + "\r\n";
			if (m_Codes.Count > 0)
			{
				foreach (string s in m_Codes)
				{
					ret += "_L " + s + "\r\n";
				}
			}
			return ret;
		}
		public string DraSticCode()
		{
			string ret = "";
			string pluss = "";
			if (m_enabled == true) pluss = "+";
			ret += $"[{m_desc}]{pluss}\r\n";
			if (m_Codes.Count>0)
			{
                foreach (string c in m_Codes)
                {
					ret += $"{c}\r\n";
                }
				ret += "\r\n";
            }
			return ret;
		}
		public string Snes9xCode()
		{
			string ret = "cheat";
			ret += $"  name:{m_desc}\r\n";
			if (m_Codes.Count > 0)
			{
				ret += $"  code:{m_Codes[0]}\r\n";
			}
			if (m_enabled)
			{
				ret += $"  enable\r\n";
			}
			ret += "\r\n";

			return ret;
		}
	}

}
