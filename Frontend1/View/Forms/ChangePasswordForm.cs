using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frontend.View.Forms
{
	public partial class ChangePasswordForm : Form
	{
		bool _closeWithoutSaving = true;

		public ChangePasswordForm()
		{
			InitializeComponent();
			FormClosing += CheckPassword;
		}

		public bool CloseWithoutSaving { get { return _closeWithoutSaving; } }

		public string GetPassword()
		{
			return passwordEdit.Password;
		}

		private void CheckPassword(object sender, FormClosingEventArgs e)
		{
			if(!_closeWithoutSaving && !passwordEdit.Validate())
			{
				MessageBox.Show("Pola nie mogą być puste oraz hasła muszą być takie same");
				e.Cancel = true;
			}
		}

		private void OkCLick(object sender, EventArgs eventArgs)
		{
			_closeWithoutSaving = false;
			this.Close();
			Reset();
		}

		public void Reset()
		{
			passwordEdit.Clear();
			_closeWithoutSaving = true;
		}
	}
}
