using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCheatEdit
{
	public class HexValue
	{
		private bool m_Enabled = false;
		public bool Enabled { get { return m_Enabled; } }
		private int m_value = 0;
		public int Value
		{
			get { return m_value; }
		}
		private string m_str = "";
		private bool m_ishead = false;

		public string Str
		{
			get
			{
				if (m_Enabled == true)
				{
					if (m_ishead)
					{
						return "0x" + HexZero(m_str);
					}
					else
					{
						return HexZero(m_str);
					}
				}
				else
				{
					return "";
				}
			}
			set
			{
				SetStr(value);
			}
		}
		public HexValue(string s)
		{
			SetStr(s);
		}
		public bool SetStr(string s)
		{
			m_str = "00000000";
			m_ishead = false;
			m_value = 0;
			m_Enabled = false;
			if (s == "") return false;
            s = s.Trim();
			bool b = false;
			int? v = null;
			if (s.Length > 2)
			{
				b = ( s[0]=='0' && ( s[1] == 'x' || s[1] == 'X'));
			}
			if (b) s = s.Substring(2);
			try
			{
				v = Convert.ToInt32(s, 16);
			}
			catch
			{
				v = null;
				return false;
			}
			if (v!= null)
			{
				m_str = HexZero(s);
				m_ishead = b;
				m_value = (int)v;
				m_Enabled=true;
			}
			return true;
		}
		private string HexZero(string s)
		{
			int sl = 8 - s.Length;
			if (sl > 0)
			{
				for (int i = 0; i < sl; i++)
				{
					s = "0" + s;
				}
			}
			return s;
		}
		public void Add(int v)
		{
			if (m_Enabled==false) return;
			m_value += v;
			m_str = HexZero(Convert.ToString(m_value, 16).ToUpper());
		}
	}
}
