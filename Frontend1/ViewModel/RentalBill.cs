using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModel
{
	class RentalBill : IViewModel
	{
		[System.ComponentModel.DisplayName("ID")]
		public int Id { get; set; }

		[System.ComponentModel.DisplayName("ID wynajmu")]
		public int? RentalId { get; set; }

		[System.ComponentModel.DisplayName("Kwota")]
		public float Amount { get; set; }

		[System.ComponentModel.DisplayName("Numer faktury")]
		public int InvoiceNumber { get; set; }

		[System.ComponentModel.DisplayName("Data płatności")]
		public DateTime? PaymentDate { get; set; }
	}
}
