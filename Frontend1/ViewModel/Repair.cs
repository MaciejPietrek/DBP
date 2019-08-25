using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModel
{
	class Repair : IViewModel
	{
		[System.ComponentModel.DisplayName("ID")]
		public int Id { get; set; }

		[System.ComponentModel.DisplayName("Identyfikator usterki")]
		public int? FaultId { get; set; }

		[System.ComponentModel.DisplayName("Identyfikator firmy")]
		public int? CompanyId { get; set; }

		[System.ComponentModel.DisplayName("Numer telefonu")]
		public string PhoneNumber { get; set; }

		[System.ComponentModel.DisplayName("Stan usterki")]
		public string State { get; set; }

		[System.ComponentModel.DisplayName("Data zlecenia")]
		public DateTime? DateOdOrder { get; set; }

		[System.ComponentModel.DisplayName("Data rozpoczęcia")]
		public DateTime? StartDate { get; set; }

		[System.ComponentModel.DisplayName("Data ukończenia")]
		public DateTime? EndDate { get; set; }
	}
}
