using DB.Model.Attributes;
using DB.Model.Implementation;
using DB.Model.Interfaces;
using Frontend.DataRecievers;
using Frontend.Managers;
using Frontend.View.Controls;
using Frontend.View.Forms;
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
		ChangePasswordForm _passwordForm = new ChangePasswordForm();

		#endregion Private members

		#region Ctors

		public MainFormController()
		{
			_mainForm.FormClosing += CloseFormHandler;
			_mainForm.LogoutEvent += LogoutHandler;
			_mainForm.AccountButton.Click += AccountEditHandler;
			_mainForm.ChangePasswordButton.Click += ChangePassword;
			_passwordForm.FormClosing += SavePassword;

			PrepareTabSet();
		}

		#endregion Ctors

		#region Properties

		/// <summary>
		/// Określa, czy po zamknięciu formularza należy zamknąć program czy tylko wylogować użytkownika
		/// </summary>
		public bool ExitRequested { get; private set; }

		#endregion Properties

		#region Methods

		/// <summary>
		/// Otwiera formularz
		/// </summary>
		public void Start()
		{
			_mainForm.ShowDialog();
		}

		/// <summary>
		/// Pobiera akcje dla podanego typu
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
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

		/// <summary>
		/// Przgotowanie przycisków do otwierania zakładek
		/// </summary>
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

		/// <summary>
		/// Dla podanego typu tworzy  dostępne akcje.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>Słownik, w którym klucz jest nazwą akcji, a wartość to event hander do obsługi akcji</returns>
		private Dictionary<string, EventHandler> GenerateActionsFor<T>() where T : class, IDBModel, new()
		{
			Dictionary<string, EventHandler> newActionSet = new Dictionary<string, EventHandler>();
			string buttonText;
			EventHandler action;
			if (typeof(T).GetCustomAttributes(typeof(ReadonlyAttribute), false).FirstOrDefault() == null)
			{
				buttonText = "Dodaj";
				action = AddEntity<T>;
				newActionSet.Add(buttonText, action);
				buttonText = "Edytuj";
				action = UpdateEntity<T>;
				newActionSet.Add(buttonText, action);
				buttonText = "Usuń";
				action = DeleteEntity<T>;
				newActionSet.Add(buttonText, action);
			}
			buttonText = "Zamknij zakładkę";
			action = CloseTabHandler;
			newActionSet.Add(buttonText, action);
			return newActionSet;
		}

		/// <summary>
		/// ODświeża zawartość data gridów we wszystkich zakładkach po aktualizacji zawartości bazy danych.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		private void RefreshDataGrids<T>() where T : class, IDBModel, new()
		{
			TabPage tab = _mainForm.GetCurrentlySelectedTab() as TabPage;
			_mainForm.RefreshPages(_dataSourceManager.Get<T>(), tab.Text);
		}

		#endregion Methods

		#region Event handlers

		/// <summary>
		/// Kliknięcie w krzyżyk zamykający okno
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
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

		/// <summary>
		/// Klikniećie w przycisk wyloguj
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		private void LogoutHandler(object sender, EventArgs eventArgs)
		{
			_mainForm.FormClosing -= CloseFormHandler;
			_mainForm.Close();
		}

		private void AccountEditHandler(object sender, EventArgs eventArgs)
		{
			AccountManagementController accountManagement = new AccountManagementController();
			accountManagement.Start();
		}

		/// <summary>
		/// Kliknięcię w przycisk otwierania nowej karty.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
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

		/// <summary>
		/// Klinięcie w przycisk zamknięcia karty
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		private void CloseTabHandler(object sender, EventArgs eventArgs)
		{
			_mainForm.CloseTab(_mainForm.GetCurrentlySelectedTab());
		}

		/// <summary>
		/// Handler dodawania obiektu. Otwiera formularz do wypełnienia danych.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		private void AddEntity<T>(object sender, EventArgs eventArgs) where T : class, IDBModel, new()
		{
			AddEditFormController addEditFormController = new AddEditFormController();
			T newEntity = addEditFormController.OpenForm(new T()) as T;
			if (newEntity != null)
			{
				string errorMessage = _dataSourceManager.Add(newEntity);
				if(errorMessage != null)
				{
					MessageBox.Show(errorMessage);
				}
				RefreshDataGrids<T>();
			}
		}

		/// <summary>
		/// Handler edycji obiektu. Otwiera formularz i wypełnia go aktualnymi danymi.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
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
				RefreshDataGrids<T>();
			}
		}

		/// <summary>
		/// Usunięcie zaznaczonej pozycji z listy
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		private void DeleteEntity<T>(object sender, EventArgs eventArgs) where T : class, IDBModel, new()
		{
			AddEditFormController addEditFormController = new AddEditFormController();
			T entity = _mainForm.SelectedEntity as T;
			if (MessageBox.Show("Usunąć zaznaczoną pozycję?", "Potwierdzeniu usunięcia", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				string errorMessage = _dataSourceManager.Delete(entity);
				if (errorMessage != null)
				{
					MessageBox.Show(errorMessage);
				}
				RefreshDataGrids<T>();
			}
		}

		/// <summary>
		/// Kliknięcie przycisku zmiany hasła
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		private void ChangePassword(object sender, EventArgs eventArgs)
		{
			_passwordForm.ShowDialog();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SavePassword(object sender, FormClosingEventArgs e)
		{
			if (!_passwordForm.CloseWithoutSaving && !e.Cancel)
			{
				HttpConnector httpConnector = HttpConnector.GetInstance();
				string password = _passwordForm.GetPassword();
				httpConnector.ChangePassword(password);
				string errorMessage = httpConnector.LastErrorMessage;
				if (errorMessage != null)
				{
					MessageBox.Show("Zmiana hasła się nie powiodła. Hasło musi mieć co najmniej 6 liter, zawierać jedną cyfrę, jeden znak specjalny i jedną wielką literę.", "Niepowodzenie zmiany hasła");
					e.Cancel = true;
					return;
				}
			}
			_passwordForm.Reset();
		}

		#endregion Event handlers
	}
}
