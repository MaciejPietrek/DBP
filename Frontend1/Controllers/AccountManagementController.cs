using Frontend.DataRecievers;
using Frontend.Managers;
using Frontend.Model;
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
		UserEditForm _userForm = new UserEditForm();
		List<string> _roles;


		/// <summary>
		/// Start kontrolera. Przygotowuje dostępne akcje w formularzu w zależności od roli użytkownika
		/// </summary>
		public void Start()
		{
			if (AuthManager.GetInstance().UserRoles.Exists((string el) => { return el == "admin"; }))
			{
				_roles = _httpConnector.GetRoles();
				string errorMessage = _httpConnector.LastErrorMessage;
				if (errorMessage == null)
				{
					_accountForm.DataSource = _httpConnector.GetUsers();
					errorMessage = _httpConnector.LastErrorMessage;
					if (errorMessage == null)
					{
						_accountForm.SetActions(AddUser, UpdateUser, DeleteUser);
						_accountForm.ShowDialog();
					}
				}
				if (errorMessage != null)
				{
					MessageBox.Show(errorMessage);
				}
			}
			else
			{
				MessageBox.Show("Brak uprawnień");
			}
		}

		/// <summary>
		/// Obsługa zdarzenia dodania użytkonwika. Otwiera formularz dodawania.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		private void AddUser(object sender, EventArgs eventArgs)
		{
			FrontendUserModel user = new FrontendUserModel();
			while (true)
			{
				_userForm.OpenForAddition(user);
				if (_userForm.ShowDialog() == DialogResult.OK)
				{
					_httpConnector.AddUser(user);
					string errorMessage = _httpConnector.LastErrorMessage;
					if (errorMessage != null)
					{
						MessageBox.Show("Niepowodzenie dodawania użytkownika. Sprawdź czy hasło ma co najmniej 6 liter, zawiera jedną cyfrę, jeden znak specjalny i jedną wielką literę.");
					}
					else
					{
						_accountForm.DataSource = null;
						_accountForm.DataSource = _httpConnector.GetUsers();
						errorMessage = _httpConnector.LastErrorMessage;
						if(errorMessage != null)
						{
							MessageBox.Show(errorMessage);
						}
						break;
					}
				}
				break;
			}
		}

		/// <summary>
		/// Obsługa zdarzenia edycji użytkownika.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		private void UpdateUser(object sender, EventArgs eventArgs)
		{
			FrontendUserModel user = _accountForm.GetSelectedUser() as FrontendUserModel;
			if (user != null)
			{
				user = user.Clone();
				while(true)
				{
					_userForm.OpenForEdit(user);
					if (_userForm.ShowDialog() == DialogResult.OK)
					{
						_httpConnector.UpdateUser(user);
						string errorMessage = _httpConnector.LastErrorMessage;
						if (errorMessage != null)
						{
							MessageBox.Show("Niepowodzenie edycji użytkownika. Sprawdź czy hasło ma co najmniej 6 liter, zawiera jedną cyfrę, jeden znak specjalny i jedną wielką literę.");
						}
						else
						{
							_accountForm.DataSource = null;
							_accountForm.DataSource = _httpConnector.GetUsers();
							errorMessage = _httpConnector.LastErrorMessage;
							if (errorMessage != null)
							{
								MessageBox.Show(errorMessage);
							}
							break;
						}
					}
					else
					{
						break;
					}
				}
			}
			else
			{
				MessageBox.Show("Nie wybrano użytkownika");
			}
		}

		private void DeleteUser(object sender, EventArgs eventArgs)
		{
			FrontendUserModel user = _accountForm.GetSelectedUser() as FrontendUserModel;
			if(user != null)
			{
				if(MessageBox.Show("Czy na pewno chcesz usunąć użytkownika " + user.Username + "?", "Potwierdzenie usunięcia", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					_httpConnector.DeleteUser(user);
					string errorMessage = _httpConnector.LastErrorMessage;
					if (errorMessage != null)
					{
						MessageBox.Show(errorMessage);
					}
					else
					{
						_accountForm.DataSource = null;
						_accountForm.DataSource = _httpConnector.GetUsers();
						errorMessage = _httpConnector.LastErrorMessage;
						if (errorMessage != null)
						{
							MessageBox.Show(errorMessage);
						}
					}
				}
			}
			else
			{
				MessageBox.Show("Nie wybrano użytkownika");
			}
		}

	}
}
