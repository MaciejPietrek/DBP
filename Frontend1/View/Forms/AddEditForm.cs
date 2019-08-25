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
				return ReadFields();
			}
			set
			{
				_dataSource = value;
				CreateFields();
			}
		}

		private void OkClick(object sender, EventArgs eventArgs)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void CancelCLick(object sender, EventArgs eventArgs)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
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
							valueControl = new DateTimePicker { ShowCheckBox = true, Text = propertyValue };
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
			int i = 0;
			foreach (Control control in _valueControls)
			{
				if (properties[i].PropertyType == typeof(int) || properties[i].PropertyType == typeof(int?))
				{
					try
					{
						properties[i].SetValue(returnEntity, int.Parse(control.Text));
					}
					catch (Exception){
						properties[i].SetValue(returnEntity, null);
					}
				}
				else if(properties[i].PropertyType == typeof(float) || properties[i].PropertyType == typeof(float?))
				{
					try
					{
						properties[i].SetValue(returnEntity, float.Parse(control.Text));
					}
					catch (Exception)
					{
						properties[i].SetValue(returnEntity, null);
					}
				}
				else
				{
					properties[i].SetValue(returnEntity, control.Text);
				}
				i++;
			}
			return returnEntity;
		}

	}
}
