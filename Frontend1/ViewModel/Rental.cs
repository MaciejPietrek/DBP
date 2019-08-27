using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModel
{
	class Rental : IViewModel
	{
		[System.ComponentModel.DisplayName("ID")]
		public int Id { get; set; }

		[System.ComponentModel.DisplayName("ID mieszkania")]
		public int? FlatId { get; set; }

		[System.ComponentModel.DisplayName("Data zakończenia najmu")]
		public DateTime? EndDate { get; set; }

		[System.ComponentModel.DisplayName("Data rozpoczęcia najmu")]
		public DateTime? StartDate { get; set; }

		[System.ComponentModel.DisplayName("ID najemcy")]
		public int? TenantId { get; set; }

		[System.ComponentModel.DisplayName("Miesiączny czynsz")]
		public float? Rent { get; set; }
	}
}
