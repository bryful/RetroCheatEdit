using System;
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
	public partial class PpssppForm : BaseForm
	{
		public string PSP_ID
		{
			get { return tbID.Text; }
			set { tbID.Text = value; }
		}
		public string PSP_Title
		{
			get { return tbTitle.Text; }
			set { tbTitle.Text = value; }
		}

		public PpssppForm()
		{
			InitializeComponent();
		}
	}
}
