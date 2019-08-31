using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Frontend.View.Controls;

namespace Frontend.View.Controls
{
	public partial class TabContents : UserControl
	{
		public TabContents()
		{
			InitializeComponent();
			Dock = DockStyle.Fill;
			gridView.AutoSize = true;
		}

		public GridView DataGrid { get { return gridView; } }

		public void FillActionArea(Dictionary<string, EventHandler> data)
		{
			foreach(var element in data)
			{
				Button actionButton = new Button { Text = element.Key, AutoSize = true};
				actionButton.Click += element.Value;
				actionFlowLayoutPanel.Controls.Add(actionButton);
			}
		}

	}
}
