using Frontend.View.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Controllers
{
	class AddEditFormController
	{

		AddEditForm _addEditForm = new AddEditForm();

		public object OpenForm(object dataObject)
		{
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

	}
}
