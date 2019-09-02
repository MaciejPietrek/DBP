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

		public void OpenForAddition(FrontendUserModel user)
		{
			_user = user;
			usernameTextBox.Text = "";
			passwordEdit.Clear();
			foreach(CheckBox roleCheckBox in _roleCheckBoxes)
			{
				roleCheckBox.Checked = user.Roles.Exists((string roleName) => { return roleName == roleCheckBox.Name; });
			}
		}

		void OnFormClosing(object sender, FormClosingEventArgs eventArgs)
		{
			if (_checkUserData)
			{
				_checkUserData = false;
				if (passwordEdit.Validate())
				{
					if(usernameTextBox.Text != "")
					{
						return;
					}
					else
					{
						MessageBox.Show("Pole z nazwą konta musi być wypełnione");
					}
				}
				else
				{
					MessageBox.Show("Oba pola hasła muszą być wypełnione");
				}
				eventArgs.Cancel = true;
			}
		}

		void OnOkCLick(object sender, EventArgs eventArgs)
		{
			_checkUserData = true;
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
			else if (roleName == "supervisor")
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
