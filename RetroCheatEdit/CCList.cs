using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace RetroCheatEdit
{
	public partial class CCList : ListBox
	{
		private string m_FileName = "";
		public string FileName { get { return m_FileName; } }
		private bool RefFlag = false;
		private string m_psp_id = "";
		public string psp_id { get { return m_psp_id; } } 
		private string m_psp_title = "";
		public string psp_title { get { return m_psp_title; } }
		public string psp_cap
		{
			get
			{
				if (m_CfType==CheatFileType.ppsspp)
				{
					return m_psp_id + " / " + m_psp_title;
				}
				else
				{
					return "";
				}
			}
		}
		private CheatFileType m_CfType = CheatFileType.None;
		public CheatFileType CfType { get { return m_CfType; } }

		private TextBox? m_TextBoxDesc = null;
		public TextBox? TextBoxDesc
		{
			get { return m_TextBoxDesc; }
			set
			{
				m_TextBoxDesc = value;
				DispTextBox();
			}
		}
		private TextBox? m_TextBoxCodes = null;
		public TextBox? TextBoxCodes
		{
			get { return m_TextBoxCodes; }
			set
			{
				m_TextBoxCodes = value;
				if (m_TextBoxCodes!=null)
				{
					m_TextBoxCodes.Multiline = true;
				}
				DispTextBox();
			}
		}
		private CheckBox? m_cbEnabled = null;
		public CheckBox? cbEnabled
		{
			get { return m_cbEnabled; }
			set
			{
				m_cbEnabled = value;
				DispTextBox();
			}
		}

		private Button? m_btnDell = null;
		
		private Button? m_btnUp = null;
		private Button? m_btnDown = null;
		private Button? m_btnAdd = null;
		private Button? m_btnUpdate = null;
		public Button? btnDell
		{
			get { return (Button?)m_btnDell; }
			set
			{
				m_btnDell = value;
				ChkEnable();
				if (m_btnDell!=null)
				{
					m_btnDell.Click += (sender, e) => { DeleteItem(); };
				}
			}
		}
		public Button? btnUp
		{
			get { return (Button?)m_btnUp; }
			set
			{
				m_btnUp = value;
				ChkEnable();
				if ( m_btnUp!=null)
				{
					m_btnUp.Click += (sender, e) => { UpItem(); };
				}
			}
		}
		public Button? btnDown
		{
			get { return (Button?)m_btnDown; }
			set
			{
				m_btnDown = value;
				ChkEnable();
				if (m_btnDown != null)
				{
					m_btnDown.Click += (sender, e) => { DownItem(); };
				}
			}
		}
		public Button? btnAdd
		{
			get { return (Button?)m_btnAdd; }
			set
			{
				m_btnAdd = value;
				ChkEnable();
				if (btnAdd != null)
				{
					btnAdd.Click += (sender, e) => { AddItem(); };
				}
			}
		}
		public Button? btnUpdate
		{
			get { return (Button?)m_btnUpdate; }
			set
			{
				m_btnUpdate = value;
				ChkEnable();
				if (m_btnUpdate != null)
				{
					m_btnUpdate.Click += (sender, e) => { UpdateItem(); };
				}
			}
		}

		public string Title
		{
			get
			{
				string ret = "";
				switch(m_CfType)
				{
					case CheatFileType.John:
						ret += "[John Emu] ";
						break;
					case CheatFileType.RetroArch:
						ret += "[RetroArch] ";
						break;
					case CheatFileType.ppsspp:
						ret += "[ppsspp] ";
						break;
					case CheatFileType.DraStic:
						ret += "[DraStic] ";
						break;
				}
				ret += $"{Path.GetFileName(m_FileName)} : {m_psp_id}/{m_psp_title}";
				return ret;
			}
		}
		private List<CheatCode> m_Items = new List<CheatCode>();
		public CCList()
		{
			InitializeComponent();
		}
		public void Clear()
		{
			this.Items.Clear();
			m_Items.Clear();
			m_psp_id = "";
			m_psp_title = "";
		}
		public void Remove(int idx)
		{
			int si = this.SelectedIndex;
			m_Items.RemoveAt(idx);
			this.Items.RemoveAt(idx);
			if (si>=this.Items.Count)
			{
				this.SelectedIndex = this.Items.Count-1;
			}
			else
			{
				this.SelectedIndex = si;
			}
		}
		public int Add(CheatCode cc)
		{
			int si = this.SelectedIndex;
			RefFlag = true;
			if ((si < 0)||(si==this.Items.Count-1))
			{
				this.Items.Add(cc.Desc);
				m_Items.Add(cc);
				si =  this.Items.Count - 1;
			}
			else
			{
				this.Items.Insert(si + 1, cc.Desc);
				m_Items.Insert(si + 1,cc);
				si += 1;
			}
			RefFlag = false;
			this.SelectedIndex=si;
			return si;
		}
		public void Append(CheatCode cc)
		{
			this.Items.Add(cc.Desc);
			m_Items.Add(cc);
		}
		public void AddRange(CheatCode[] cc)
		{
			string[] desc = new string[cc.Length];
			CheatCode[] ccs = new CheatCode[cc.Length];

			for (int i = 0;i<cc.Length;i++)
			{
				desc[i] = cc[i].Desc;
			}
			this.Items.AddRange(desc);
			m_Items.AddRange(cc);
		}
		public void Swap(int i0,int i1)
		{
			if (i0 == i1) return;
			if((i0>=0)&&(i0< m_Items.Count)&& (i1 >= 0) && (i1 < m_Items.Count))
			{
				CheatCode tmp = new CheatCode(m_Items[i0]);
				m_Items[i0].Copy(m_Items[i1]);
				m_Items[i1].Copy(tmp);
				string s = (string)this.Items[i0];
				this.Items[i0] = this.Items[i1];
				this.Items[i1] = s;
			}
		}

		public void ChkEnable()
		{
			int si = this.SelectedIndex;
			if (m_btnDell!=null)
			{
				m_btnDell.Enabled = ( si >= 0);
			}
			if (m_btnDown != null)
			{
				m_btnDown.Enabled = ((si >= 0)&&(si<this.Items.Count-1));
			}
			if (m_btnUp != null)
			{
				m_btnUp.Enabled = (si >= 1);
			}
			if (m_btnAdd != null)
			{
				m_btnAdd.Enabled = true;
			}
			if (m_btnUpdate != null)
			{
				m_btnUpdate.Enabled = (si >= 0);
			}
		}
		public void DispTextBox()
		{
			if (RefFlag) return;
			if ( (SelectedIndex<0)||(SelectedIndex>=this.Items.Count))
			{
				if (m_TextBoxDesc != null) m_TextBoxDesc.Text = "";
				if (m_TextBoxCodes != null) m_TextBoxCodes.Text = "";
				if (m_cbEnabled != null) m_cbEnabled.Checked = false;
				return;
			}
			if(m_TextBoxDesc != null)
			{
				m_TextBoxDesc.Text = m_Items[SelectedIndex].Desc;
			}
			if (m_TextBoxCodes != null)
			{
				m_TextBoxCodes.Text = m_Items[SelectedIndex].Code;
			}
			if (m_cbEnabled != null)
			{
				m_cbEnabled.Checked = m_Items[SelectedIndex].Enabled;
			}
		}
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			if (RefFlag) return;
			ChkEnable();
			if (SelectedIndex < 0)
			{
				return;
			}
			DispTextBox();
		}

		public CheatFileType TypeOfCFT(string s)
		{
			s = s.Trim();
			if( s=="") return CheatFileType.None;
			//john
			int idx = s.IndexOf("<?xml version='1.0' encoding='UTF-8' ?>");
			if (idx== 0) 
			{
				return CheatFileType.John;
			}
			// RetroArch
			idx = s.IndexOf("cheat");
			if(idx== 0)
			{
				return CheatFileType.RetroArch;
			}
			idx = s.IndexOf("_S ");
			if (idx == 0)
			{
				return CheatFileType.ppsspp;
			}
			idx = s.IndexOf("_S "); // spaceわすれずに
			if (idx == 0)
			{
				return CheatFileType.ppsspp;
			}
			idx = s.IndexOf("\n");
			if (idx >= 0)
			{
				string ss = s.Substring(0, idx).Trim();
				string sss = "";
				bool b = false;
				if (IsDraSticH(ss,out sss,out b))
				{
					return CheatFileType.DraStic;
				}
			}
			return CheatFileType.None;	
		}
		// *****************************************************************
		public bool Load(string p)
		{
			bool ret = false;
			if (File.Exists(p) == false) return ret;

			try
			{
				string s = File.ReadAllText(p);
				Clear();
				CheatFileType cf = TypeOfCFT(s);

				switch(cf)
				{
					case CheatFileType.John:
						ret = FromJoneCht(s);
						break;
					case CheatFileType.RetroArch:
						ret = FromRetroArch(s);
						break;
					case CheatFileType.ppsspp:
						ret = FromPpsspp(s);
						break;
					case CheatFileType.DraStic:
						ret = FromDraStic(s);
						break;
				}
			}
			catch
			{
				ret = false;

			}
			if(ret)
			{
				m_FileName = p;
			}
			return ret;

		}
		// *****************************************************************
		public bool FromJoneCht(string s)
		{
			bool ret = false;
			try
			{
				if (s !="")
				{
					int idx0 = -1;
					int idx1 = -1;

					idx0 = s.IndexOf("<cheats>");
					if (idx0 >= 0)
					{
						idx0 += 8;
						idx1 = s.IndexOf("</cheats>",idx0);
					}
					if((idx0>0) && (idx1 > 0))
					{
						s = s.Substring(idx0, idx1 - idx0);
						string[] sa = s.Split("/>");
						if(sa.Length>0)
						{
							foreach (string s2 in sa)
							{
								CheatCode cc = new CheatCode("a");
								if (cc.SetJohnItemStr(s2))
								{
									Append(cc);
								}
							}
						}
						m_CfType = CheatFileType.John;
						ret = true;
					}
				}
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		private string[] SplitRetroA(string s)
		{
			string[] ret = new string[3];
			ret[0] = ret[1] = ret[2] = "";
			string[] sa = s.Split('=');
			if (sa.Length>=2)
			{
				ret[2] = sa[1].Trim();
				if ((ret[2].Length >= 2) && (ret[2][0]=='\"') && (ret[2][ret[2].Length-1] == '\"'))
				{
					ret[2] = ret[2].Substring(1, ret[2].Length-2);
				}

				string[] sa2 = sa[0].Trim().Split('_');
				if (sa2.Length>=2)
				{
					ret[0] = sa2[0].Replace("cheat", "").Trim();
					ret[1] = sa2[1].Trim();
				}else if (sa2.Length==1)
				{
					ret[0] = sa2[0].Trim();
				}
			}
			return ret;
		}
		public bool FromRetroArch(string s)
		{
			bool ret = false;
			if (s == "") return ret;

			string[] sa = s.Split("\n");

			int cnt = 0;
			int idx0 = -1;
			int idx1 = -1;

			List<string[]> itms = new List<string[]>();
			foreach (string s2 in sa)
			{
				if (s2.IndexOf("cheat")>=0)
				{
					string[] line = SplitRetroA(s2);
					if ((line[1]=="code")|| (line[1] == "desc") || (line[1] == "enable"))
					{
						itms.Add(line);
					}else if (line[0]== "cheats")
					{
						int v = 0;
						if (int.TryParse(line[2], out v))
						{
							cnt = v;
						}
					}
				}
			}
			if (cnt > 0)
			{
				CheatCode[] ccs = new CheatCode[cnt];
				for (int i = 0; i < cnt; i++) ccs[i] = new CheatCode("");
				if (itms.Count > 0)
				{
					int idx = -1;
					foreach (string[] line in itms)
					{
						if (int.TryParse(line[0],out idx))
						{
							if ((idx>=0)&&(idx<cnt))
							{
								if (line[1]=="desc")
								{
									ccs[idx].SetDesc(line[2]);
								}else if (line[1] == "enable")
								{
									ccs[idx].SetEnabled(line[2] == "true");
								}
								else if (line[1] == "code")
								{
									ccs[idx].SetCodes(line[2].Split("+"));
								}
							}

						}
					}
					AddRange(ccs);
					ret = true;
					m_CfType = CheatFileType.RetroArch;
				}
			}
			return ret;
		}
		public bool FromPpsspp(string s)
		{
			bool ret = false;
			try
			{
				string[] sa = s.Split('\n');
				List<CheatCode> ccs = new List<CheatCode>();
				string Head_S = "";
				string Head_G = "";
				if (sa.Length > 0)
				{
					CheatCode? cc = null;
					foreach (string line in sa )
					{
						string line2 = line.Trim();
						if (line2 == "") continue;
						int idx = line2.IndexOf(" ");
						string tag = line2.Substring(0, idx).Trim();
						string Node = line2.Substring(idx+1).Trim();

						if ((tag=="_S")&&(Head_S==""))
						{
							Head_S = Node;
						}else if ((tag == "_G") && (Head_G == ""))
						{
							Head_G = Node;
						}else if (tag == "_C0")
						{
							if (cc!= null) ccs.Add(cc);
							cc = new CheatCode(Node);
						}else if (tag == "_L")
						{
							if (cc != null)
							{
								cc.AddCode(Node);
							}
						}
					}
					if (cc != null) ccs.Add(cc);
				}
				string[] descs = new string[ccs.Count];
				for(int i=0; i<ccs.Count; i++) { descs[i] = ccs[i].Desc;}
				this.Items.AddRange(descs);
				m_Items.AddRange(ccs);
				m_psp_id = Head_S;
				m_psp_title = Head_G;
				m_CfType = CheatFileType.ppsspp;
				ret = true;
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		private bool IsDraSticH(string s,out string d,out bool enable)
		{
			bool ret = false;
			s = s.Trim();
			d = "";
			enable = false;
			if (s.Length<2) return ret;

			if (s[s.Length-1]=='+')
			{
				enable = true;
				s = s.Substring(0,s.Length-1).Trim();
			}
			if (s.Length < 2) return ret;
			if ((s[0] == '[') && (s[s.Length - 1] == ']'))
			{
				d = s.Substring(1,s.Length-2);
				ret = true;
			}
			return ret;
		}
		public bool FromDraStic(string s)
		{
			bool ret = false;
			try
			{
				string[] sa = s.Split('\n');
				List<CheatCode> ccs = new List<CheatCode>();
				if (sa.Length > 0)
				{
					CheatCode? cc = null;
					foreach (string line in sa)
					{
						string line2 = line.Trim();
						string h = "";
						bool enable = false;
						if (IsDraSticH(line2,out h,out enable))
						{
							if (cc!=null) ccs.Add(cc);
							cc = new CheatCode(h);
							cc.SetEnabled(enable);
						}
						else if (line2 !="")
						{
							if(cc!=null)
								cc.AddCode(line2);
						}
					}
					if (cc != null) ccs.Add(cc);
				}
				string[] descs = new string[ccs.Count];
				for (int i = 0; i < ccs.Count; i++) { descs[i] = ccs[i].Desc; }
				this.Items.AddRange(descs);
				m_Items.AddRange(ccs);
				m_CfType = CheatFileType.DraStic;
				ret = true;
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		// *****************************************************************
		public bool Save(string p)
		{
			switch (m_CfType)
			{
				case CheatFileType.RetroArch:
					return SaveRetroArch(p);
				case CheatFileType.John:
					return SaveJohn(p);
				default:
					return false;
			}
		}
		// *****************************************************************
		public bool SaveJohn(string p)
		{
			bool ret = false;

			string data = "";
			if (m_Items.Count > 0)
			{
				foreach (CheatCode item in m_Items) 
				{
					data += item.JonItemStr;
				}

			}
			data = "<?xml version='1.0' encoding='UTF-8' ?><cheats>" + data + "</cheats>";
			try
			{
				if (File.Exists(p)) { File.Delete(p); }
				File.WriteAllText(p, data);
				ret = File.Exists(p);
				m_CfType = CheatFileType.John;
			}
			catch
			{
				m_CfType = CheatFileType.None;
				ret = false;
			}
			if (ret) { m_FileName = p; }
			return ret;
		}
		// *****************************************************************
		public bool SaveRetroArch(string p)
		{
			bool ret = false;

			string data = "";
			int idx = 0;
			if (m_Items.Count > 0)
			{
				foreach (CheatCode item in m_Items)
				{
					data += item.RetroACode(idx)+"\n";
					idx++;
				}

			}
			data += $"cheats = \"{idx}\"\n";
			try
			{
				if (File.Exists(p)) { File.Delete(p); }
				File.WriteAllText(p, data);
				ret = File.Exists(p);
				m_CfType = CheatFileType.RetroArch;
			}
			catch
			{
				m_CfType = CheatFileType.None;
				ret = false;
			}
			if (ret) { m_FileName = p; }
			return ret;
		}
		// *****************************************************************
		public bool SavePpsspp(string p)
		{
			bool ret = false;
			if ((m_psp_id == "") || (m_psp_title == "")) return ret;
			string data = "";
			data += $"_S {m_psp_id}\r\n";
			data += $"_G {m_psp_title}\r\n";
			if (m_Items.Count>0)
			{
				foreach(CheatCode item in m_Items)
				{
					data += item.PpssppCode();
				}
			}
			try
			{
				if (File.Exists(p)) { File.Delete(p); }
				File.WriteAllText(p, data);
				ret = File.Exists(p);
				m_CfType = CheatFileType.ppsspp;
			}
			catch
			{
				m_CfType = CheatFileType.None;
				ret = false;
			}
			if (ret) 
			{ 
				m_FileName = p; 
			}
			return ret;
		}
		// *****************************************************************
		public bool SaveDrasTic(string p)
		{
			bool ret = false;
			string data = "";
			if (m_Items.Count > 0)
			{
				foreach (CheatCode item in m_Items)
				{
					data += item.DraSticCode();
				}
			}
			try
			{
				if (File.Exists(p)) { File.Delete(p); }
				File.WriteAllText(p, data);
				ret = File.Exists(p);
				m_CfType = CheatFileType.DraStic;
			}
			catch
			{
				m_CfType = CheatFileType.None;
				ret = false;
			}
			if (ret)
			{
				m_FileName = p;
			}
			return ret;
		}
		// *****************************************************************
		public void DeleteItem()
		{
			if (this.SelectedIndex < 0) return;
			DialogResult result = MessageBox.Show($"Remove /{this.Items[this.SelectedIndex].ToString()}", "", MessageBoxButtons.YesNo);
			if (result == DialogResult.Yes)
			{
				Remove(this.SelectedIndex);
			}
		}
		public void UpItem()
		{
			if ((this.SelectedIndex >= 1)&&(this.SelectedIndex<this.Items.Count))
			{
				RefFlag = true;
				Swap(this.SelectedIndex, this.SelectedIndex - 1);
				RefFlag = false;
				this.SelectedIndex -= 1;
			}
		}
		public void DownItem()
		{
			if ((this.SelectedIndex >= 0) && (this.SelectedIndex < this.Items.Count-1))
			{
				RefFlag = true;
				Swap(this.SelectedIndex, this.SelectedIndex + 1);
				RefFlag = false;
				this.SelectedIndex += 1;
			}
		}
		public void AddItem()
		{
			string desc = "";
			string [] code = new string[0];
			bool enable = false;
			if (m_TextBoxDesc == null) return;
			if (m_TextBoxCodes == null) return;
			if (m_cbEnabled == null) return;
			desc = m_TextBoxDesc.Text;
			code = m_TextBoxCodes.Lines;
			enable = m_cbEnabled.Checked;

			CheatCode cc = new CheatCode(desc);
			cc.SetDesc(desc);
			cc.SetCodes(code);
			cc.SetEnabled(enable);
			Add(cc);
		}
		public void UpdateItem()
		{
			string desc = "";
			string[] code = new string[0];
			bool enable = false;
			if (m_TextBoxDesc == null) return;
			if (m_TextBoxCodes == null) return;
			if (m_cbEnabled == null) return;
			int si = this.SelectedIndex;
			if (si < 0) return;

			RefFlag = true;
			desc = m_TextBoxDesc.Text;
			code = m_TextBoxCodes.Lines;
			enable = m_cbEnabled.Checked;

			m_Items[si].SetDesc(desc);
			m_Items[si].SetCodes(code);
			m_Items[si].SetEnabled(enable);
			this.Items[si] = desc;
			RefFlag = false;
		}
		// *****************************************************************
		public void EditPspIsTitle()
		{
			using (PpssppForm dlg = new PpssppForm())
			{
				dlg.PSP_ID = m_psp_id;
				dlg.PSP_Title = m_psp_title;
				if (dlg.ShowDialog()== DialogResult.OK)
				{
					m_psp_id = dlg.PSP_ID;
					m_psp_title = dlg.PSP_Title;
				}
			}
		}
		// *****************************************************************

	}
	public enum CheatFileType
	{
		None =0,
		John,
		RetroArch,
		ppsspp,
		DraStic
	}
}
