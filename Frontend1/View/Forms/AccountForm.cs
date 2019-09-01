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
	public partial class AccountForm : Form
	{
		Button addUserButton = new Button { Name = "addUserButton", AutoSize = true, Text = "Dodaj konto", Visible = false };
		Button updateUserButton = new Button { Name = "updateUserButton", AutoSize = true, Text = "Zmień konto", Visible = false };
		Button deleteUserButton = new Button { Name = "deleteUserButton", AutoSize = true, Text = "Usuń konto", Visible = false };
		Button changePasswordButton = new Button { Name = "changePasswordButton", AutoSize = true, Text = "Zmień hasło" };

		public AccountForm()
		{
			InitializeComponent();			
			tabContents.FillActionArea(new List<Button> { addUserButton, updateUserButton, deleteUserButton, changePasswordButton } );
			tabContents.DataGrid.Visible = false;
		}

		public List<string> Roles
		{
			set
			{

			}
		}

		public object DataSource {
			set
			{
				tabContents.DataGrid.DataSource = value;
			}
		}

		public bool EnableUserView
		{
			set
			{
				tabContents.DataGrid.Visible = true;
				addUserButton.Visible = true;
				updateUserButton.Visible = true;
				deleteUserButton.Visible = true;
			}
		}

		public void SetActions(EventHandler changePassword, EventHandler addUser, EventHandler updateUser, EventHandler deleteUser)
		{
			changePasswordButton.Click += changePassword;
			addUserButton.Click += addUser;
			updateUserButton.Click += updateUser;
			deleteUserButton.Click += deleteUser;
		}
	}
}
