using DB.Model.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frontend.View.Forms
{
	public partial class AddEditForm : Form
	{
		object _dataSource = null;
		List<Control> _valueControls = new List<Control>();
		List<Type> _foreignTypes = new List<Type>();
		bool _cancelClose = false;

		public EventHandler ChooseEntityEvent;

		public AddEditForm()
		{
			InitializeComponent();
		}

		public List<Type> ForeignKeyTypes
		{
			get
			{
				return _foreignTypes;
			}
		}

		public object DataSource
		{
			get
			{
				return _dataSource;
			}
			set
			{
				_dataSource = value;
				CreateFields();
			}
		}

		private void OkClick(object sender, EventArgs eventArgs)
		{
			object newDataSource = ReadFields();
			if(newDataSource != null)
			{
				_cancelClose = false;
				_dataSource = newDataSource;
				this.DialogResult = DialogResult.OK;
			}
			else
			{
				_cancelClose = true;
				MessageBox.Show("Wprowadź informacje do zaznaczonych pól");
			}
		}

		private void CancelCLick(object sender, EventArgs eventArgs)
		{
			_cancelClose = false;
			this.DialogResult = DialogResult.Cancel;
		}

		private void OnFormClosing(object sender, FormClosingEventArgs eventArgs)
		{
			eventArgs.Cancel = _cancelClose;
		}

		public void SetForeignKeyId(int index, int entityId)
		{
			foreach(Control control in _valueControls)
			{
				if(control.Tag != null && (int)control.Tag == index)
				{
					control.Text = entityId.ToString();
				} 
			}
		}

		private void CreateFields()
		{
			tableLayoutPanelInternal.RowCount = 0;
			tableLayoutPanelInternal.RowStyles.Clear();
			Type dataSourceType = _dataSource.GetType();
			int i = 0;
			foreach (PropertyInfo property in dataSourceType.GetProperties())
			{
				Control valueControl;
				string propertyValue = property.GetValue(_dataSource) != null ? property.GetValue(_dataSource).ToString() : "";
				if (property.GetCustomAttribute<PrimaryKeyAttribute>() != null)
				{
					valueControl = new Control { Text = propertyValue };
				}
				else
				{
					var foreignKeyAttribute = property.GetCustomAttribute<ForeignKeyAttribute>();
					var nameAttribute = property.GetCustomAttribute<System.ComponentModel.DisplayNameAttribute>();
					Control descriptionControl;
					if (foreignKeyAttribute != null)
					{
						_foreignTypes.Add(foreignKeyAttribute.ReferencedClass);
						descriptionControl = new Button { Text = nameAttribute.DisplayName, AutoSize = true, Tag = _foreignTypes.Count - 1 };
						descriptionControl.Click += ChooseEntityEvent;
						valueControl = new TextBox { Enabled = false, Text = propertyValue, Tag = _foreignTypes.Count - 1 };
					}
					else
					{
						descriptionControl = new Label { Text = nameAttribute.DisplayName };
						if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
						{
							valueControl = new DateTimePicker { ShowCheckBox = property.GetCustomAttribute<RequiredAttribute>() == null, Text = propertyValue };
						}
						else
						{
							valueControl = new TextBox { Width = 200, Text = propertyValue };
						}
					}

					tableLayoutPanelInternal.RowStyles.Add(new RowStyle { SizeType = SizeType.Absolute, Height = 30 });
					tableLayoutPanelInternal.Controls.Add(descriptionControl);
					tableLayoutPanelInternal.Controls.Add(valueControl);
					tableLayoutPanelInternal.SetRow(descriptionControl, i);
					tableLayoutPanelInternal.SetColumn(descriptionControl, 0);
					tableLayoutPanelInternal.SetRow(valueControl, i++);
					tableLayoutPanelInternal.SetColumn(valueControl, 1);
				}
				_valueControls.Add(valueControl);
			}
			tableLayoutPanelInternal.RowCount = i;
		}

		private object ReadFields()
		{
			Type dataSourceType = _dataSource.GetType();
			object returnEntity = Activator.CreateInstance(dataSourceType);
			var properties = dataSourceType.GetProperties();
			bool cancelRead = false;
			int i = 0;
			foreach (Control control in _valueControls)
			{
				bool required = properties[i].GetCustomAttribute<RequiredAttribute>() != null;
				bool requiredFieldFilled = true;
				if (properties[i].PropertyType == typeof(int) || properties[i].PropertyType == typeof(int?))
				{
					requiredFieldFilled = ReadIntField(returnEntity, control, properties[i], required);
				}
				else if(properties[i].PropertyType == typeof(float) || properties[i].PropertyType == typeof(float?))
				{
					requiredFieldFilled = ReadFloatField(returnEntity, control, properties[i], required);
				}
				else if (properties[i].PropertyType == typeof(DateTime) || properties[i].PropertyType == typeof(DateTime?))
				{
					requiredFieldFilled = ReadDateTimeField(returnEntity, control, properties[i], required);
				}
				else
				{
					if(control.Text == "" && required)
					{
						requiredFieldFilled = false;
					}
					else
					{
						properties[i].SetValue(returnEntity, control.Text);
					}
				}

				if(!requiredFieldFilled)
				{
					control.BackColor = Color.Red;
					cancelRead = true;
				}
				else
				{
					control.BackColor = Color.White;
					cancelRead = false;
				}

				i++;
			}
			if (cancelRead)
			{
				return null;
			}
			else
			{
				return returnEntity;
			}
		}

		private bool ReadIntField(object returnEntity, Control control, PropertyInfo fieldProperty, bool required)
		{
			try
			{
				fieldProperty.SetValue(returnEntity, int.Parse(control.Text));
			}
			catch (Exception)
			{
				if (required)
				{
					return false;
				}
				else
				{
					if (fieldProperty.PropertyType == typeof(int))
					{
						fieldProperty.SetValue(returnEntity, default(int));
					}
					else
					{
						fieldProperty.SetValue(returnEntity, null);
					}
				}
			}
			return true;
		}

		private bool ReadFloatField(object returnEntity, Control control, PropertyInfo fieldProperty, bool required)
		{
			try
			{
				fieldProperty.SetValue(returnEntity, float.Parse(control.Text));
			}
			catch (Exception)
			{
				if (required)
				{
					return false;
				}
				else
				{
					if (fieldProperty.PropertyType == typeof(float))
					{
						fieldProperty.SetValue(returnEntity, default(float));
					}
					else
					{
						fieldProperty.SetValue(returnEntity, null);
					}
				}
			}
			return true;
		}

		private bool ReadDateTimeField(object returnEntity, Control control, PropertyInfo fieldProperty, bool required)
		{
			try
			{
				if ((control as DateTimePicker).Checked)
				{
					fieldProperty.SetValue(returnEntity, DateTime.Parse(control.Text));
				}
				else if(required)
				{
					throw new Exception();
				}
			}
			catch (Exception)
			{
				if (required)
				{
					return false;
				}
				else
				{
					if (fieldProperty.PropertyType == typeof(DateTime))
					{
						fieldProperty.SetValue(returnEntity, default(DateTime));
					}
					else
					{
						fieldProperty.SetValue(returnEntity, null);
					}
				}
			}
			return true;
		}

	}
}
