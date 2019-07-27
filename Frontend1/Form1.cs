using Frontend1.Model.DAO;
using Frontend1.View.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frontend1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			/*GridView grid = new GridView();
			Controls.Add(grid);*/
			grid.DataSource = new DAOBuilding().GetList();
			
		}
	}
}
