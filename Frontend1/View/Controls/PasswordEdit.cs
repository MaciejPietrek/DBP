using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frontend.View.Controls
{
	public partial class PasswordEdit : UserControl
	{
		public PasswordEdit()
		{
			InitializeComponent();
		}

		public string Password
		{
			get
			{
				return newPasswordTextBox.Text;
			}
		}

		public new bool Validate()
		{
			if(newPasswordTextBox.Text != "" && newPasswordTextBox.Text == confirmPasswordTextBox.Text)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Clear()
		{
			newPasswordTextBox.Text = "";
			confirmPasswordTextBox.Text = "";
		}
	}
}
