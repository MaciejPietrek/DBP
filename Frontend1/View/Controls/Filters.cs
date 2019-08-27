using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Frontend.ViewModel;
using System.Reflection;
using Frontend.Model.Attributes;

namespace Frontend.View.Controls
{
	public partial class Filters<T> : UserControl where T : IViewModel
	{
		List<Tuple<Label, Control>> filterFields = new List<Tuple<Label, Control>>();
		Type dataType = typeof(T);

		/// <summary>
		/// Creates entries for filter.
		/// </summary>
		public Filters()
		{
			InitializeComponent();
			PropertyInfo[] properties = dataType.GetProperties();
			foreach (PropertyInfo prop in properties)
			{
				var foreignKeyAttribute = prop.GetCustomAttribute<ForeignKeyAttribute>();
				if (foreignKeyAttribute != null)
				{

				} else
				{
					Label label = new Label();
					Control inputControl;
					var nameAttribute = prop.GetCustomAttribute<System.ComponentModel.DisplayNameAttribute>();
					label.Text = nameAttribute.DisplayName;
					if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
					{
						inputControl = new DateTimePicker();
					}else
					{
						inputControl = new TextBox();
					}
					var controlPair = new Tuple<Label, Control>(label, inputControl);
					filterFields.Add(controlPair);
				}
			}
			LayoutEntries();
		}


		/// <summary>
		/// Calculates layout of filter entries and places them around
		/// </summary>
		private void LayoutEntries()
		{
			TableLayoutPanel temp = new TableLayoutPanel();
			temp.RowStyles.Clear();
			int i = 0;
			foreach(var controlPair in filterFields)
			{
				temp.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				temp.Controls.Add(controlPair.Item1);
				temp.SetRow(controlPair.Item1, i);
				temp.SetColumn(controlPair.Item1, i);
				temp.Controls.Add(controlPair.Item2);
				temp.SetRow(controlPair.Item2, 0);
				temp.SetColumn(controlPair.Item2, 0);
				i++;
			}
			temp.RowCount = temp.RowStyles.Count;
		}

	}
}
