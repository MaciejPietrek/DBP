using DB.Model.Implementation;
using DB.Model.Interfaces;
using Frontend.Managers;
using Frontend.View.Controls;
using Frontend.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frontend.Controllers
{
	class MainFormController
	{
		#region Private members

		MainForm _mainForm = new MainForm();
		DataSourceManager _dataSourceManager = DataSourceManager.GetInstance();
		Dictionary<Type, Dictionary<string, EventHandler>> _actionsForType = new Dictionary<Type, Dictionary<string, EventHandler>>();
		#endregion Private members

		#region Ctors

		public MainFormController()
		{
			_mainForm.FormClosing += CloseFormHandler;
			_mainForm.LogoutEvent += LogoutHandler;
			PrepareTabSet();
		}

		#endregion Ctors

		#region Properties

		public bool ExitRequested { get; private set; }

		#endregion Properties

		#region Methods

		public void Start()
		{
			_mainForm.ShowDialog();
			Cleanup();
		}

		private Dictionary<string, EventHandler> GetActionsFor<T>() where T : class, IDBModel, new()
		{
			foreach (var data in _actionsForType)
			{
				if (data.Key.Equals(typeof(T)))
				{
					return data.Value;
				}
			}

			Dictionary<string, EventHandler> newActions = GenerateActionsFor<T>();
			_actionsForType.Add(typeof(T), newActions);
			return newActions;
		}

		private void PrepareTabSet()
		{
			var buttonData = new Dictionary<string, EventHandler>();
			buttonData.Add("Budynki", OpenTabHandler<BuildingModel>);
			buttonData.Add("Mieszkania", OpenTabHandler<FlatModel>);
			buttonData.Add("Usterki", OpenTabHandler<FaultModel>);
			buttonData.Add("Naprawy", OpenTabHandler<RepairModel>);
			buttonData.Add("Firmy", OpenTabHandler<CompanyModel>);
			buttonData.Add("Wynajmy", OpenTabHandler<RentalModel>);
			buttonData.Add("Faktury napraw", OpenTabHandler<RepairBillModel>);
			buttonData.Add("Faktury wynajmów", OpenTabHandler<RentalBillModel>);
			buttonData.Add("Dozorcy", OpenTabHandler<SupervisorModel>);
			buttonData.Add("Najemcy", OpenTabHandler<TenantModel>);
			buttonData.Add("Dozorowania", OpenTabHandler<SupervisingModel>);
            buttonData.Add("Platnosci", OpenTabHandler<PaymentModel>);
            buttonData.Add("Bieżące naprawy", OpenTabHandler<CurrentRepairModel>);
            buttonData.Add("Zaległe płatności", OpenTabHandler<LatePaymentModel>);
            buttonData.Add("Zyski", OpenTabHandler<IncomeModel>);
            _mainForm.CreateTabOpeningButtonSet(buttonData);
		}

		private Dictionary<string, EventHandler> GenerateActionsFor<T>() where T : class, IDBModel, new()
		{
			Dictionary<string, EventHandler> newActionSet = new Dictionary<string, EventHandler>();
			string buttonText = "Dodaj";
			EventHandler action = AddEntity<T>;
			newActionSet.Add(buttonText, action);
			buttonText = "Edytuj";
			action = UpdateEntity<T>;
			newActionSet.Add(buttonText, action);
			buttonText = "Usuń";
			action = DeleteEntity<T>;
			newActionSet.Add(buttonText, action);
			buttonText = "Zamknij zakładkę";
			action = CloseTabHandler;
			newActionSet.Add(buttonText, action);
			return newActionSet;
		}

		private void Cleanup()
		{

		}

		#endregion Methods

		#region Event handlers

		private void CloseFormHandler(object sender, CancelEventArgs eventArgs)
		{
			if(MessageBox.Show("Czy na pewno chcesz zamknąć program?", "Wyjście", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				ExitRequested = true;
			}
			else
			{
				eventArgs.Cancel = true;
			}
		}

		private void LogoutHandler(object sender, EventArgs eventArgs)
		{
			_mainForm.FormClosing -= CloseFormHandler;
			_mainForm.Close();
		}

		private void OpenTabHandler<T>(object sender, EventArgs eventArgs) where T : class, IDBModel, new()
		{
			TabPage newTab = _mainForm.GetRecentlyOpenedTab();
			var dataSource = _dataSourceManager.Get<T>();
			if(dataSource != null)
			{
				TabContents tabContents = newTab.Controls[0] as TabContents;
				tabContents.DataGrid.DataSource = dataSource;
				tabContents.FillActionArea(GetActionsFor<T>());
			}
			else
			{
				_mainForm.CloseTab(newTab);
				MessageBox.Show(_dataSourceManager.LastErrorMessage);
			}
		}

		private void CloseTabHandler(object sender, EventArgs eventArgs)
		{
			_mainForm.CloseTab(_mainForm.GetCurrentlySelectedTab());
		}

		private void AddEntity<T>(object sender, EventArgs eventArgs) where T : class, IDBModel, new()
		{
			AddEditFormController addEditFormController = new AddEditFormController();
			T newEntity = addEditFormController.OpenForm(new T()) as T;
			if (newEntity != null)
			{
				string errorMessage = _dataSourceManager.Add(newEntity);
				if(errorMessage == null)
				{
					TabContents tabContents = _mainForm.GetCurrentlySelectedTab().Controls[0] as TabContents;
					tabContents.DataGrid.DataSource = null;
					tabContents.DataGrid.DataSource = _dataSourceManager.Get<T>();
				}
				else
				{
					MessageBox.Show(errorMessage);
				}
			}
		}

		private void UpdateEntity<T>(object sender, EventArgs eventArgs) where T : class, IDBModel, new()
		{
			AddEditFormController addEditFormController = new AddEditFormController();
			T entity = _mainForm.SelectedEntity as T;
			T modifiedEntity = addEditFormController.OpenForm(entity) as T;
			if (modifiedEntity != null)
			{
				string errorMessage = _dataSourceManager.Update(modifiedEntity, entity);
				if (errorMessage != null)
				{
					MessageBox.Show(errorMessage);
				}
				else
				{
					TabContents tabContents = _mainForm.GetCurrentlySelectedTab().Controls[0] as TabContents;
					tabContents.DataGrid.DataSource = null;
					tabContents.DataGrid.DataSource = _dataSourceManager.Get<T>();
				}
			}
		}

		private void DeleteEntity<T>(object sender, EventArgs eventArgs) where T : class, IDBModel, new()
		{
			AddEditFormController addEditFormController = new AddEditFormController();
			T entity = _mainForm.SelectedEntity as T;
			if (MessageBox.Show("Usunąć zaznaczoną pozycję?", "Potwierdzeniu usunięcia", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				string errorMessage = _dataSourceManager.Delete(entity);
				if (errorMessage == null)
				{
					TabContents tabContents = _mainForm.GetCurrentlySelectedTab().Controls[0] as TabContents;
					tabContents.DataGrid.DataSource = null;
					tabContents.DataGrid.DataSource = _dataSourceManager.Get<T>();
				}
				else
				{
					MessageBox.Show(errorMessage);
				}
			}
		}

		#endregion Event handlers
	}
}
