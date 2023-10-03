using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using RoslynPad.Editor;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using RoslynPad.Roslyn;
using System.Collections.Immutable;
using System.Windows.Forms.Integration;
using System.IO;
using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;
using Microsoft.CodeAnalysis.CSharp.Scripting.Hosting;

namespace RetroCheatEdit
{
	public partial class ScriptEditor : BaseForm
	{
		public CustomRoslynHost? Host
		{
			get { return roslynEdit1.Host; }
		}
		public ScriptEditor()
		{
			InitializeComponent();

			sampleSnes1Menu.Click += (sender, e) =>
			{
				roslynEdit1.Text = Properties.Resources.sampleCode1;

			};
			wizCharMenu.Click += (sender, e) =>
			{
				roslynEdit1.Text = Properties.Resources.SampleCode2;

			};
		}
		public CustomRoslynHost? ScriptHost = null;
		public void ScriptExecute(string code)
		{
			try
			{
				if (ScriptHost == null) CreateScriptHost();
				if (ScriptHost == null) return;
				ScriptOptions options = ScriptOptions.Default
					.WithReferences(ScriptHost.DefaultReferences)
					.WithImports(ScriptHost.DefaultImports);

				var script = CSharpScript.Create(code, options, typeof(Root));
				Root rt = new Root();
				rt.Textbox = textBox1;
				script.RunAsync(rt);
			}
			catch (CompilationErrorException ex)
			{
				textBox1.AppendText("コンパイルエラー\r\n" + ex.Message + "\r\n");
			}
			catch (Exception ex)
			{
				textBox1.AppendText("エラー\r\n" + ex.Message + "\r\n");

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
		public void CreateScriptHost()
		{
			var roslynPadAssemblies = new[]
			{
				Assembly.Load("RoslynPad.Roslyn.Windows"),
				Assembly.Load("RoslynPad.Editor.Windows"),
				Assembly.Load("System"),
				Assembly.Load("System.IO"),
				Assembly.Load("System.Windows.Forms"),
				typeof(System.Dynamic.DynamicObject).Assembly,  // System.Code
				//typeof(Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo).Assembly,  // Microsoft.CSharp
				typeof(System.Dynamic.ExpandoObject).Assembly,
				typeof(System.Data.DataTable).Assembly,
				typeof(System.Object).Assembly,
				typeof(Root).Assembly,
				Assembly.GetExecutingAssembly(),
			};
			var assemblies = new[]
			{
				Assembly.Load("System.Private.CoreLib"),
				typeof(System.Dynamic.DynamicObject).Assembly,
				typeof(System.Dynamic.ExpandoObject).Assembly,
				typeof(System.Text.RegularExpressions.Regex).Assembly,
				typeof(System.Object).Assembly,
				typeof(System.Runtime.DependentHandle).Assembly,
				typeof(System.Windows.Forms.MessageBox).Assembly,
				typeof(Root).Assembly,
				Assembly.GetExecutingAssembly(),


			};
			ScriptHost = new CustomRoslynHost(
				typeof(Root),
				roslynPadAssemblies,
				RoslynHostReferences.NamespaceDefault.With(assemblyReferences: assemblies));

		}

		private void btnV8Execute_Click(object sender, EventArgs e)
		{
			ScriptExecute(roslynEdit1.Text);
		}
	}
}
