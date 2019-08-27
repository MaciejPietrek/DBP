using Frontend.Model.DAO;
using Frontend.View.Controls;
using Frontend.View.Forms;
using Frontend.ViewModel;
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

		public object SelectedEntity
		{
			get
			{
				TabContents tabContents = tabControl.SelectedTab.Controls[0] as TabContents;
				return tabContents.DataGrid.CurrentRow.DataBoundItem;
			}
		}

		#region Event handlers

		private void LogoutButtonClicked(object sender, EventArgs e)
		{
			LogoutEvent?.Invoke(sender, e);
		}

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

		public TabPage GetCurrentlySelectedTab()
		{
			return tabControl.SelectedTab;
		}

		public TabPage GetRecentlyOpenedTab()
		{
			return tabControl.TabPages[tabControl.TabCount - 2];
		}

		public void CloseTab(TabPage tabPage)
		{
			tabControl.TabPages.Remove(tabPage);
		}

		public object OpenAddForm(object formDataSource)
		{
			AddEditForm addEditForm = new AddEditForm();
			addEditForm.DataSource = formDataSource;
			addEditForm.ShowDialog();
			return null;
		}

		new public void Refresh()
		{
			TabContents tabContents = GetCurrentlySelectedTab().Controls[0] as TabContents;
			tabContents.DataGrid.Refresh();
		}

		#endregion
	}
}
