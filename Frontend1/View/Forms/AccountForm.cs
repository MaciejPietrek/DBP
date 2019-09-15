using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Frontend.Model;

namespace Frontend.View.Forms
{
	public partial class AccountForm : Form
	{
		Button addUserButton = new Button { Name = "addUserButton", AutoSize = true, Text = "Dodaj konto"};
		Button updateUserButton = new Button { Name = "updateUserButton", AutoSize = true, Text = "Zmień konto"};
		Button deleteUserButton = new Button { Name = "deleteUserButton", AutoSize = true, Text = "Usuń konto"};

		public AccountForm()
		{
			InitializeComponent();			
			tabContents.FillActionArea(new List<Button> { addUserButton, updateUserButton, deleteUserButton } );
		}

		/// <summary>
		/// Lista użytkowników systemu
		/// </summary>
		public object DataSource {
			set
			{
				tabContents.DataGrid.DataSource = value;
			}
		}

		/// <summary>
		/// Ustawia obsługę zdzarzeń dla przycisków akcji(dla admina)
		/// </summary>
		/// <param name="changePassword"></param>
		/// <param name="addUser"></param>
		/// <param name="updateUser"></param>
		/// <param name="deleteUser"></param>
		public void SetActions(EventHandler addUser, EventHandler updateUser, EventHandler deleteUser)
		{
			addUserButton.Click += addUser;
			updateUserButton.Click += updateUser;
			deleteUserButton.Click += deleteUser;
		}

		/// <summary>
		/// Zwraca użytkownika wybranego z listy
		/// </summary>
		/// <returns></returns>
		public object GetSelectedUser()
		{
			if(tabContents.DataGrid.CurrentRow != null)
			{
				return tabContents.DataGrid.CurrentRow.DataBoundItem;
			}
			else
			{
				return null;
			}
		}
	}
}
