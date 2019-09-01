using DB.Model.Interfaces;
using Frontend.View.Controls;
using Frontend.View.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frontend.Controllers
{
	class EntityChoiceFormController
	{
		EntityChoiceForm _entityChoiceForm = new EntityChoiceForm();

		public object DataSource
		{
			set
			{
				TabContents tabContents = _entityChoiceForm.Controls[0] as TabContents;
				tabContents.DataGrid.DataSource = value;
			}
		}

		public int? Start()
		{
			TabContents tabContents = _entityChoiceForm.Controls[0] as TabContents;
			Dictionary<string, EventHandler> actions = GetActions();
			tabContents.FillActionArea(actions);
			if (_entityChoiceForm.ShowDialog() == DialogResult.OK)
			{
				return (tabContents.DataGrid.CurrentRow.DataBoundItem as IDBModel).Id;
			}
			else
			{
				return null;
			}
		}

		private Dictionary<string, EventHandler> GetActions()
		{
			Dictionary<string, EventHandler> actions = new Dictionary<string, EventHandler>
			{
				{ "Wybierz", ChooseHandler },
				{ "Anuluj", CloseHandler }
			};
			return actions;
		}

		private void ChooseHandler(object sender, EventArgs eventArgs)
		{
			_entityChoiceForm.DialogResult = DialogResult.OK;
			_entityChoiceForm.Close();
		}

		private void CloseHandler(object sender, EventArgs eventArgs)
		{
			_entityChoiceForm.DialogResult = DialogResult.Cancel;
			_entityChoiceForm.Close();
		}

	}
}
