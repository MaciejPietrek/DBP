using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModel
{
	class RepairBill : IViewModel
	{
		[System.ComponentModel.DisplayName("ID")]
		public int Id { get; set; }

		[System.ComponentModel.DisplayName("Identyfikator Naprawy")]
		public int? RepairId { get; set; }

		[System.ComponentModel.DisplayName("Kwota do zapłaty")]
		public float Price { get; set; }

		[System.ComponentModel.DisplayName("Numer faktury")]
		public int InvoiceNumber { get; set; }

		[System.ComponentModel.DisplayName("Data płatności")]
		public DateTime? PaymentDate { get; set; }
	}
}
