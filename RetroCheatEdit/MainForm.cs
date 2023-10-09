namespace RetroCheatEdit
{
	public partial class MainForm : BaseForm
	{
		public List<CalcForm> m_forms = new List<CalcForm>();
		public List<ScriptEditor> m_Sforms = new List<ScriptEditor>();
		// ********************************************************************
		private F_Pipe m_Server = new F_Pipe();
		public void StartServer(string pipename)
		{
			m_Server.Server(pipename);
			m_Server.Reception += (sender, e) =>
			{
				this.Invoke((Action)(() =>
				{
					PipeData pd = new PipeData(e.Text);
					Command(pd.Args, PIPECALL.PipeExec);
					this.Activate();
				}));
			};
		}
		// ********************************************************************
		public void StopServer()
		{
			m_Server.StopServer();
		}
		public MainForm()
		{
			this.AllowDrop = true;
			InitializeComponent();
			this.FormClosed += (sender, e) => { LastSettings(); };
			StartSettings();

			quitMenu.Click += (sender, e) => { Application.Exit(); };
			calcFormMenu.Click += (sender, e) => { NewCalcForm(); };
			fileMenu.Click += (sender, e) =>
			{
				saveMenu.Enabled = (ccList1.CfType != CheatFileType.None);
			};
			loadMenu.Click += (sender, e) => { LoadChtFile(); };
			saveMenu.Click += (sender, e) => { SaveChtFile(); };
			saveJohnMenu.Click += (sender, e) => { SaveJohnFile(); };
			saveRetroArchMenu.Click += (sender, e) => { SaveRetroArchFile(); };
			savePpssppMenu.Click += (sender, e) => { SavePpssppFile(); };
			saveDraSticMenu.Click += (sender, e) => { SaveDraSticFile(); };
			saveSnes9xMenu.Click += (sender, e) => { SaveSnes9xFile(); };
			pspIdTitleFormMenu.Click += (sender, e) =>
			{
				ccList1.EditPspIsTitle();
				this.Text = ccList1.Title;
			};
			scriptEditorMenu.Click += (sender, e) => { NewScriptEditor(); };
			Command(Environment.GetCommandLineArgs().Skip(1).ToArray(), PIPECALL.StartupExec);
		}
		// **********************************************************
		private void StartSettings()
		{
			PrefFile pf = new PrefFile(this);
			pf.Load();
			Rectangle? rect = pf.GetBounds();
		}
		// **********************************************************
		private void LastSettings()
		{
			PrefFile pf = new PrefFile(this);
			pf.SetBounds();
			pf.Save();
		}
		// **********************************************************
		/// <summary>
		/// コマンド解析
		/// </summary>
		/// <param name="args">コマンド配列</param>
		/// <param name="IsPipe">起動時かダブルクリック時か判別</param>
		public void Command(string[] args, PIPECALL IsPipe = PIPECALL.StartupExec)
		{
			if (args.Length > 0)
			{
				foreach (string arg in args)
				{
					if (ccList1.Load(arg))
					{
						this.Text = ccList1.Title;
						return;
					}
					else
					{
						this.Text = "PetroCheatEdit";
					}
				}
			}
			//textBox1.Text = ret;
		}
		protected override void OnDragEnter(DragEventArgs drgevent)
		{
			if ((drgevent != null) && (drgevent.Data != null))
			{
				if (drgevent.Data.GetDataPresent(DataFormats.FileDrop))
				{
					drgevent.Effect = DragDropEffects.Copy;
				}
			}
			else
			{
				base.OnDragEnter(drgevent);
			}
		}
		protected override void OnDragDrop(DragEventArgs drgevent)
		{
			if ((drgevent != null) && (drgevent.Data != null))
			{
				if (drgevent.Data.GetDataPresent(DataFormats.FileDrop))
				{

					// ドラッグ中のファイルやディレクトリの取得
					string[] drags = (string[])drgevent.Data.GetData(DataFormats.FileDrop);
					Command(drags);
				}
			}
			else
			{
				base.OnDragDrop(drgevent);
			}
		}
		// **********************************************************
		protected override void OnResize(EventArgs e)
		{
			int w = this.Width - (10 + 5 + 10);
			int h = this.Height - (95 + 10);
			int w2 = (int)w / 2;
			if (ccList1 != null)
			{
				btnDell.Location = new Point(10, 65);
				btnUp.Location = new Point(btnDell.Right + 10, btnDell.Top);
				btnDown.Location = new Point(btnUp.Right + 5, btnDell.Top);
				ccList1.Location = new Point(10, 95);
				ccList1.Size = new Size(w2, h);

				tbDesc.Location = new Point(this.Width - 10 - w2, 95);
				tbDesc.Size = new Size(w2, 29);
				tbCode.Location = new Point(tbDesc.Left, tbDesc.Bottom + 5);
				tbCode.Size = new Size(w2, this.Height - 10 - tbCode.Top);

				btnAdd.Location = new Point(tbDesc.Left, 65);
				btnUpdate.Location = new Point(btnAdd.Right + 5, 65);
				cbEnabled.Location = new Point(btnUpdate.Right + 5, 65);

			}
			this.Refresh();

			base.OnResize(e);
		}
		// **********************************************************
		public void NewCalcForm()
		{
			CalcForm cf = new CalcForm();
			cf.Owner = this;
			m_forms.Add(cf);
			cf.Show();
		}
		// **********************************************************
		public void NewScriptEditor()
		{
			ScriptEditor cf = new ScriptEditor();
			cf.Owner = this;
			m_Sforms.Add(cf);
			cf.Show();
		}
		public bool LoadChtFile()
		{
			bool ret = false;
			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				if (ccList1.FileName != "")
				{
					dlg.InitialDirectory = Path.GetDirectoryName(ccList1.FileName);
					dlg.FileName = Path.GetFileName(ccList1.FileName);
				}
				dlg.Filter = "*.cht|*.cht|*.ini|*.ini|*.*|*.*";

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = ccList1.Load(dlg.FileName);
					if (ret)
					{
						this.Text = ccList1.Title;
					}
					else
					{
						this.Text = "RetroCheatEdit";
					}
				}
			}
			return ret;
		}
		public bool SaveChtFile()
		{
			bool ret = false;
			if (ccList1.CfType == CheatFileType.None) return ret;
			using (SaveFileDialog dlg = new SaveFileDialog())
			{
				if (ccList1.CfType == CheatFileType.John)
				{
					dlg.Title = "Export John Emulator cheat File";
					dlg.DefaultExt = ".cht";
				}
				else if (ccList1.CfType == CheatFileType.RetroArch)
				{
					dlg.Title = "Export Retroarch cheat File";
					dlg.DefaultExt = ".cht";
				}
				else if (ccList1.CfType == CheatFileType.ppsspp)
				{
					dlg.Title = "Export ppsspp cheat File";
					dlg.DefaultExt = ".ini";
				}
				else if (ccList1.CfType == CheatFileType.DraStic)
				{
					dlg.Title = "Export DraStic cheat File";
					dlg.DefaultExt = ".cht";
				}

				if (ccList1.FileName != "")
				{
					dlg.InitialDirectory = Path.GetDirectoryName(ccList1.FileName);
					if (ccList1.CfType == CheatFileType.ppsspp)
					{
						dlg.FileName = Path.ChangeExtension(
							Path.GetFileName(ccList1.FileName),
							".ini");
					}
					else
					{
						dlg.FileName = Path.ChangeExtension(
							Path.GetFileName(ccList1.FileName),
							".cht");
					}
				}
				dlg.Filter = "*.cht|*.cht|*.ini|*.ini|*.*|*.*";

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = ccList1.Save(dlg.FileName);
					if (ret)
					{
						this.Text = ccList1.Title;
					}
					else
					{
						this.Text = "RetroCheatEdit";
					}
				}
			}
			return ret;
		}
		public bool SaveJohnFile()
		{
			bool ret = false;
			using (SaveFileDialog dlg = new SaveFileDialog())
			{
				if (ccList1.FileName != "")
				{
					dlg.InitialDirectory = Path.GetDirectoryName(ccList1.FileName);
					dlg.FileName = Path.ChangeExtension(
						Path.GetFileName(ccList1.FileName),
						".cht");
				}
				dlg.Title = "Export John Emulator cheat File";
				dlg.Filter = "*.cht|*.cht|*.*|*.*";
				dlg.DefaultExt = ".cht";

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = ccList1.SaveJohn(dlg.FileName);
					if (ret)
					{
						this.Text = ccList1.Title;
					}
					else
					{
						this.Text = "RetroCheatEdit";
					}
				}
			}
			return ret;
		}
		public bool SaveRetroArchFile()
		{
			bool ret = false;
			using (SaveFileDialog dlg = new SaveFileDialog())
			{
				if (ccList1.FileName != "")
				{
					dlg.InitialDirectory = Path.GetDirectoryName(ccList1.FileName);
					dlg.FileName = Path.ChangeExtension(
						Path.GetFileName(ccList1.FileName),
						".cht");
				}
				dlg.Title = "Export Retroarch cheat File";
				dlg.DefaultExt = ".cht";
				dlg.Filter = "*.cht|*.cht|*.*|*.*";

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = ccList1.SaveRetroArch(dlg.FileName);
					if (ret)
					{
						this.Text = ccList1.Title;
					}
					else
					{
						this.Text = "RetroCheatEdit";
					}
				}
			}
			return ret;
		}
		public bool SavePpssppFile()
		{
			bool ret = false;
			using (SaveFileDialog dlg = new SaveFileDialog())
			{
				if (ccList1.FileName != "")
				{
					dlg.InitialDirectory = Path.GetDirectoryName(ccList1.FileName);
					dlg.FileName = Path.ChangeExtension(
						Path.GetFileName(ccList1.FileName),
						".ini");
				}
				dlg.Title = "Export Retroarch cheat File";
				dlg.DefaultExt = ".ini";
				dlg.Filter = "*.ini|*.ini|*.*|*.*";

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = ccList1.SavePpsspp(dlg.FileName);
					if (ret)
					{
						this.Text = ccList1.Title;
					}
					else
					{
						this.Text = "RetroCheatEdit";
					}
				}
			}
			return ret;
		}
		public bool SaveDraSticFile()
		{
			bool ret = false;
			using (SaveFileDialog dlg = new SaveFileDialog())
			{
				if (ccList1.FileName != "")
				{
					dlg.InitialDirectory = Path.GetDirectoryName(ccList1.FileName);
					dlg.FileName = Path.ChangeExtension(
						Path.GetFileName(ccList1.FileName),
						".cht");
				}
				dlg.Title = "Export DraStic cheat File";
				dlg.DefaultExt = ".cht";
				dlg.Filter = "*.cht|*.cht|*.*|*.*";

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = ccList1.SaveDraStic(dlg.FileName);
					if (ret)
					{
						this.Text = ccList1.Title;
					}
					else
					{
						this.Text = "RetroCheatEdit";
					}
				}
			}
			return ret;
		}
		public bool SaveSnes9xFile()
		{
			bool ret = false;
			using (SaveFileDialog dlg = new SaveFileDialog())
			{
				if (ccList1.FileName != "")
				{
					dlg.InitialDirectory = Path.GetDirectoryName(ccList1.FileName);
					dlg.FileName = Path.ChangeExtension(
						Path.GetFileName(ccList1.FileName),
						".cht");
				}
				dlg.Title = "Export Snes9x cheat File";
				dlg.DefaultExt = ".cht";
				dlg.Filter = "*.cht|*.cht|*.*|*.*";

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = ccList1.SaveSnes9x(dlg.FileName);
					if (ret)
					{
						this.Text = ccList1.Title;
					}
					else
					{
						this.Text = "RetroCheatEdit";
					}
				}
			}
			return ret;
		}
	}
}