using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModel
{
	class Company : IViewModel
	{
		[System.ComponentModel.DisplayName("ID")]
		public int Id { get; set; }

		[System.ComponentModel.DisplayName("NIP")]
		public string NIP { get; set; }

		[System.ComponentModel.DisplayName("Numer telefornu")]
		public string PhoneNumber { get; set; }

		[System.ComponentModel.DisplayName("Nazwa firmy")]
		public string CompanyName { get; set; }

	}
}
