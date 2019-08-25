using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Frontend.View.Forms
{
	public partial class LoginForm : Form
	{
		#region Events

		public event EventHandler<SignInEventArgs> SignInEvent;

		#endregion Events

		#region Ctor

		public LoginForm()
		{
			InitializeComponent();
		}

		#endregion Ctor

		#region Methods

		protected virtual void RaiseSignInEvent(SignInEventArgs eventArgs)
		{
			SignInEvent?.Invoke(this, eventArgs);
		}

		public virtual void Clear()
		{
			loginTextBox.Clear();
			passwordTextBox.Clear();
		}

		#endregion Methods

		#region Event handlers

		private void SignInButtonClicked(object sender, EventArgs eventArgs)
		{
			string login = loginTextBox.Text;
			string password = passwordTextBox.Text;

			bool credentialsPresent = true;

			if (login == null || login == "")
			{
				MessageBox.Show("Proszę podać login");
				credentialsPresent = false;
			}

			if (password == null || password == "")
			{
				MessageBox.Show("Proszę podać hasło");
				credentialsPresent = false;
			}

			if(credentialsPresent)
			{
				SignInEventArgs signInEventArgs = new SignInEventArgs { Login = login, Password = password };
				RaiseSignInEvent(signInEventArgs);
			}
		}

		#endregion Event handlers

		public class SignInEventArgs : EventArgs 
		{
			virtual public string Login { get; set; }
			virtual public string Password { get; set; }
		}

	}
}
