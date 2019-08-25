using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModel
{
	class Supervisor : IViewModel
	{
		[System.ComponentModel.DisplayName("ID")]
		public int Id { get; set; }

		[System.ComponentModel.DisplayName("Numer telefonu")]
		public string PhoneNumber { get; set; }

		[System.ComponentModel.DisplayName("Imię")]
		public string Name { get; set; }

		[System.ComponentModel.DisplayName("Nazwisko")]
		public string Surname { get; set; }

		[System.ComponentModel.DisplayName("PESEL")]
		public string PESEL { get; set; }
	}
}
