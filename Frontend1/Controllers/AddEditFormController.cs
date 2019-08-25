using DB.Model.Implementation;
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
	class AddEditFormController
	{

		AddEditForm _addEditForm = new AddEditForm();

		public object OpenForm(object dataObject)
		{
			_addEditForm.ChooseEntityEvent = ChooseEntity;
			_addEditForm.DataSource = dataObject;
			if(_addEditForm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
			{
				return null;
			}
			else
			{
				return _addEditForm.DataSource;
			}
		}

		private void ChooseEntity(object sender, EventArgs eventArgs)
		{
			Button senderButton = sender as Button;
			var types = _addEditForm.ForeignKeyTypes;
			Type requestedType = types[(int)senderButton.Tag];
			int? entityId = GetChosenEntityId(requestedType);
			if(entityId != null)
			{
				_addEditForm.SetForeignKeyId((int)senderButton.Tag, (int)entityId);
			}
		}

		private int? GetChosenEntityId(Type requestedType)
		{
			DataSourceManager dataSourceManager = DataSourceManager.GetInstance();
			EntityChoiceFormController entityChoiceFormController = new EntityChoiceFormController();
			if (requestedType == typeof(BuildingModel))
			{
				entityChoiceFormController.DataSource = dataSourceManager.Get<BuildingModel>();
			}
			else if (requestedType == typeof(FlatModel))
			{
				entityChoiceFormController.DataSource = dataSourceManager.Get<FlatModel>();
			}
			else if (requestedType == typeof(RentalModel))
			{
				entityChoiceFormController.DataSource = dataSourceManager.Get<RentalModel>();
			}
			else if (requestedType == typeof(TenantModel))
			{
				entityChoiceFormController.DataSource = dataSourceManager.Get<TenantModel>();
			}
			else if (requestedType == typeof(RepairModel))
			{
				entityChoiceFormController.DataSource = dataSourceManager.Get<RepairModel>();
			}
			else if (requestedType == typeof(FaultModel))
			{
				entityChoiceFormController.DataSource = dataSourceManager.Get<FaultModel>();
			}
			else if (requestedType == typeof(CompanyModel))
			{
				entityChoiceFormController.DataSource = dataSourceManager.Get<CompanyModel>();
							}
			else if (requestedType == typeof(SupervisorModel))
			{
				entityChoiceFormController.DataSource = dataSourceManager.Get<SupervisorModel>();
			}
			return entityChoiceFormController.Start();
		}

	}
}
