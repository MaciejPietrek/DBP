using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModel
{
	class Flat : IViewModel
	{
		[System.ComponentModel.DisplayName("ID")]
		public int Id { get; set; }

		[System.ComponentModel.DisplayName("ID budynku")]
		public int? BuildingId { get; set; }

		[System.ComponentModel.DisplayName("Numer mieszkania")]
		public int Number { get; set; }

		[System.ComponentModel.DisplayName("Powierzchnia")]
		public float? Surface { get; set; }

		[System.ComponentModel.DisplayName("Opis")]
		public string Description { get; set; }
	}
}
