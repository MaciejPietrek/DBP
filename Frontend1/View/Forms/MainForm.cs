using Frontend.View.Controls;
using Frontend.View.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frontend
{
	public partial class MainForm : Form
	{
		public event EventHandler LogoutEvent;

		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Zwraca wybrany obiekt z listy w otwartej zakładce
		/// </summary>
		public object SelectedEntity
		{
			get
			{
				TabContents tabContents = tabControl.SelectedTab.Controls[0] as TabContents;
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

		public Button AccountButton { get { return accountButton; } }
		public Button ChangePasswordButton { get { return changePasswordButton; } }

		#region Event handlers

		/// <summary>
		/// Naciśnięcie przycisku wylogowywania
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LogoutButtonClicked(object sender, EventArgs e)
		{
			LogoutEvent?.Invoke(sender, e);
		}

		/// <summary>
		/// Obsługa zdarzenia otwarcia zakładki
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		private void OpenTab(object sender, EventArgs eventArgs)
		{
			TabPage newTabPage = new TabPage();
			newTabPage.Controls.Add(new TabContents());
			tabControl.TabPages.Add(newTabPage);
			tabControl.TabPages[tabControl.TabCount - 1] = tabControl.TabPages[tabControl.TabCount - 2];
			tabControl.TabPages[tabControl.TabCount - 2] = newTabPage;
			newTabPage.Text = (sender as Button).Text;
		}

		#endregion

		#region Methods
		
		/// <summary>
		/// Wypełnia ostatnią zakładkę (zawierającą przyciski do otwierania pozostałych zakładek) przyciskami
		/// </summary>
		/// <param name="buttonData"></param>
		public void CreateTabOpeningButtonSet(Dictionary<string, EventHandler> buttonData)
		{
			foreach(var data in buttonData)
			{
				var newButton = new Button { Text = data.Key };
				newButton.AutoSize = true;
				newButton.Click += OpenTab;
				newButton.Click += data.Value;
				flowLayoutPanelConstant.Controls.Add(newButton);
			}
		}

		/// <summary>
		/// Zwraca aktualnie otwartą zakładkę
		/// </summary>
		/// <returns></returns>
		public TabPage GetCurrentlySelectedTab()
		{
			return tabControl.SelectedTab;
		}

		/// <summary>
		/// Zwraca ostatnio otwartą zakładkę (przedostatnia)
		/// </summary>
		/// <returns></returns>
		public TabPage GetRecentlyOpenedTab()
		{
			return tabControl.TabPages[tabControl.TabCount - 2];
		}

		/// <summary>
		/// Zamknięcie wskazanej zakłądki
		/// </summary>
		/// <param name="tabPage"></param>
		public void CloseTab(TabPage tabPage)
		{
			tabControl.TabPages.Remove(tabPage);
		}

		/// <summary>
		/// Otwarcie formularza dla dodawania obiektu
		/// </summary>
		/// <param name="formDataSource"></param>
		/// <returns></returns>
		public object OpenAddForm(object formDataSource)
		{
			AddEditForm addEditForm = new AddEditForm();
			addEditForm.DataSource = formDataSource;
			addEditForm.ShowDialog();
			return null;
		}

		/// <summary>
		/// Coś robi, boję się usunąć
		/// </summary>
		new public void Refresh()
		{
			TabContents tabContents = GetCurrentlySelectedTab().Controls[0] as TabContents;
			tabContents.DataGrid.Refresh();
		}

		/// <summary>
		/// Odświeżenie datagridów we wszystkich zakładkach z tą samą zawartością 
		/// </summary>
		/// <param name="dataSource"></param>
		/// <param name="tabTitle"></param>
		public void RefreshPages(object dataSource, string tabTitle)
		{
			foreach(TabPage tab in tabControl.TabPages)
			{
				if(tab.Text == tabTitle)
				{
					TabContents tabContents = tab.Controls[0] as TabContents;
					tabContents.DataGrid.DataSource = null;
					tabContents.DataGrid.DataSource = dataSource;
				}
			}
		}

		#endregion
	}
}
