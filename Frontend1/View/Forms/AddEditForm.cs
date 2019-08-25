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

		public AddEditForm()
		{
			InitializeComponent();
		}

		public object DataSource
		{
			get
			{
				ReadFields();
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
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void CancelCLick(object sender, EventArgs eventArgs)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void CreateFields()
		{
			tableLayoutPanelInternal.RowCount = 0;
			tableLayoutPanelInternal.RowStyles.Clear();
			Type dataSourceType = _dataSource.GetType();
			int i = 0;
			foreach (PropertyInfo property in dataSourceType.GetProperties())
			{
				if (property.GetCustomAttribute<PrimaryKeyAttribute>() != null)
					continue;
				var foreignKeyAttribute = property.GetCustomAttribute<ForeignKeyAttribute>();
				var nameAttribute = property.GetCustomAttribute<System.ComponentModel.DisplayNameAttribute>();
				Control descriptionControl;
				Control valueControl;
				string propertyValue = property.GetValue(_dataSource) != null ? property.GetValue(_dataSource).ToString() : "";
				if (foreignKeyAttribute != null)
				{
					descriptionControl = new Button { Text = nameAttribute.DisplayName, AutoSize = true };
					valueControl = new TextBox { Enabled = false, Text = propertyValue };
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
				_valueControls.Add(valueControl);
			}
			tableLayoutPanelInternal.RowCount = i;
		}

		private void ReadFields()
		{
			
			Type dataSourceType = _dataSource.GetType();
			var properties = dataSourceType.GetProperties();
			int i = 1;
			foreach (Control control in _valueControls)
			{
				properties[i++].SetValue(_dataSource, control.Text);
			}
		}
	}
}
