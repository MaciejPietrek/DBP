using Frontend.Managers;
using Frontend.View.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frontend.Controllers
{
	class AppController
	{
		LoginForm _loginForm = new LoginForm();

		/// <summary>
		/// Assign handler to signing in event
		/// </summary>
		public AppController()
		{
			_loginForm.SignInEvent += SignIn;
		}

		/// <summary>
		/// Opens login form
		/// </summary>
		public void StartApp()
		{
			Application.Run(_loginForm);
		}

		/// <summary>
		/// Handler for signing in event. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		public void SignIn(object sender, LoginForm.SignInEventArgs eventArgs)
		{
			var authManager = AuthManager.GetInstance();
			string message = authManager.SignIn(eventArgs.Login, eventArgs.Password);
			if(message == null) //null means ok
			{
				_loginForm.Clear();
				_loginForm.Visible = false;
				MainFormController mainFormController = new MainFormController();
				mainFormController.Start();
				if(mainFormController.ExitRequested)
				{
					_loginForm.Close();
				}else
				{
					_loginForm.Visible = true;
				}
			}else
			{
				MessageBox.Show(message);
			}
		}
	}
}
