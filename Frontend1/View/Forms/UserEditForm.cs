using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Frontend.DataRecievers;
using Frontend.Model;

namespace Frontend.View.Forms
{
	public partial class UserEditForm : Form
	{
		FrontendUserModel _user;
		List<CheckBox> _roleCheckBoxes = new List<CheckBox>();
		bool _checkUserData = false;
		bool _openedForEdit;

		/// <summary>
		/// Dodaje checkboxy dla obsługi wyboru ról
		/// </summary>
		public UserEditForm()
		{
			InitializeComponent();
			foreach (string roleName in HttpConnector.GetInstance().GetRoles())
			{
				CheckBox checkBox = new CheckBox { Name = roleName, Text = GetRoleName(roleName), AutoSize = true };
				_roleCheckBoxes.Add(checkBox);
				flowLayoutPanel.Controls.Add(checkBox);
			}
		}

		/// <summary>
		/// Otwiera czysty formularz do dodawania użytkownika. 
		/// </summary>
		/// <param name="user"></param>
		public void OpenForAddition(FrontendUserModel user)
		{
			_openedForEdit = false;
			_user = user;
			usernameTextBox.Text = user.Username ?? "";
			passwordEdit.Clear();
			foreach(CheckBox roleCheckBox in _roleCheckBoxes)
			{
				roleCheckBox.Checked = user.Roles != null && user.Roles.Exists((string roleName) => { return roleName == roleCheckBox.Name; });
			}
		}

		/// <summary>
		/// Otwiera fomularz i wypełnia aktualnymi danymi użytkownika
		/// </summary>
		/// <param name="user"></param>
		public void OpenForEdit(FrontendUserModel user)
		{
			_openedForEdit = true;
			_user = user;
			usernameTextBox.Text = user.Username ?? "";
			passwordEdit.Clear();
			foreach (CheckBox roleCheckBox in _roleCheckBoxes)
			{
				roleCheckBox.Checked = user.Roles != null && user.Roles.Exists((string roleName) => { return roleName == roleCheckBox.Name; });
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		void OnFormClosing(object sender, FormClosingEventArgs eventArgs)
		{
			if (_checkUserData)
			{
				_checkUserData = false;
				if (passwordEdit.Validate() || (passwordEdit.Password == "" && _openedForEdit))
				{
					if(usernameTextBox.Text != "")
					{
						_user.Username = usernameTextBox.Text;
						_user.Password = passwordEdit.Password;
						_user.Roles = new List<string>();
						foreach(CheckBox roleCheckBox in _roleCheckBoxes)
						{
							if (roleCheckBox.Checked)
							{
								_user.Roles.Add(roleCheckBox.Name);
							}
						}
						DialogResult = DialogResult.OK;
						return;
					}
					else
					{
						MessageBox.Show("Pole z nazwą konta musi być wypełnione");
					}
				}
				else
				{
					MessageBox.Show("Oba pola hasła muszą być wypełnione i hasła muszą być takie same");
				}
				eventArgs.Cancel = true;
			}
		}

		void OnOkCLick(object sender, EventArgs eventArgs)
		{
			_checkUserData = true;
			this.Close();
		}

		void OnCancelCLick(object sender, EventArgs eventArgs)
		{
			_checkUserData = false;
			DialogResult = DialogResult.Cancel;
		}

		private string GetRoleName(string roleName)
		{
			if (roleName == "admin")
			{
				return "Administrator";
			}
			else if (roleName == "overseer")
			{
				return "Nadzorca";
			}
			else if (roleName == "janitor")
			{
				return "Dozorca";
			}
			else if (roleName == "treasurer")
			{
				return "Skarbnik";
			}
			else return roleName;
		}
	}
}
