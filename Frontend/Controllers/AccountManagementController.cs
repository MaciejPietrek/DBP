using Frontend.DataRecievers;
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
	class AccountManagementController
	{
		HttpConnector _httpConnector = HttpConnector.GetInstance();
		AccountForm _accountForm = new AccountForm();
		ChangePasswordForm _passwordForm = new ChangePasswordForm();
		List<string> _roles;

		public void Start()
		{
			if (AuthManager.GetInstance().UserRoles.Exists((string el) => { return el == "admin"; }))
			{
				_roles = _httpConnector.GetRoles();
				string errorMessage = _httpConnector.LastErrorMessage;
				if (errorMessage == null)
				{
					_accountForm.Roles = _roles;
					_accountForm.DataSource = _httpConnector.GetUsers();
					errorMessage = _httpConnector.LastErrorMessage;
					if (errorMessage == null)
					{
						_accountForm.EnableUserView = true;
					}
				}
				if (errorMessage != null)
				{
					MessageBox.Show(errorMessage);
				}
			}
			_accountForm.SetActions(ChangePassword, AddUser, UpdateUser, DeleteUser);
			_passwordForm.FormClosing += SavePassword;
			_accountForm.ShowDialog();
		}

		private void AddUser(object sender, EventArgs eventArgs)
		{

		}

		private void UpdateUser(object sender, EventArgs eventArgs)
		{

		}

		private void DeleteUser(object sender, EventArgs eventArgs)
		{

		}

		private void ChangePassword(object sender, EventArgs eventArgs)
		{
			_passwordForm.ShowDialog();
		}

		private void SavePassword(object sender, FormClosingEventArgs e)
		{
			if(!_passwordForm.CloseWithoutSaving && !e.Cancel)
			{
				string password = _passwordForm.GetPassword();
				_httpConnector.ChangePassword(password);
				string errorMessage = _httpConnector.LastErrorMessage;
				if (errorMessage != null)
				{
					MessageBox.Show("Zmiana hasła się nie powiodła. Hasło musi mieć co najmniej 6 liter, zawierać jedną cyfrę, jeden znak specjalny i jedną wielką literę.", "Niepowodzenie zmiany hasła");
					e.Cancel = true;
				}
			}
		}
	}
}
