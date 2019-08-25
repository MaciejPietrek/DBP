using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModel
{
	class Building : IViewModel
	{
		[System.ComponentModel.DisplayName("ID")]
		public int Id { get; set; }

		[System.ComponentModel.DisplayName("Adres")]
		public string Address { get; set; }
	}
}
