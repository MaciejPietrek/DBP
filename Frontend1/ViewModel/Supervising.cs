using Frontend.Model.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModel
{
	class Supervising : IViewModel
	{
		[System.ComponentModel.DisplayName("Data Rozpoczęcia")]
		public DateTime? StartDate { get; set; }

		[System.ComponentModel.DisplayName("Data Zakończenia")]
		public DateTime? EndDate { get; set; }

		[ForeignKey(typeof(Supervisor))]
		[System.ComponentModel.DisplayName("Identyfikator Dozorcy")]
		public int SupervisorId { get; set; }

		[ForeignKey(typeof(Building))]
		[System.ComponentModel.DisplayName("Identyfikator Budynku")]
		public int BuildingId { get; set; }
	}
}
