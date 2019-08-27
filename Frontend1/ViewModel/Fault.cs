using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModel
{
	class Fault : IViewModel
	{
		[System.ComponentModel.DisplayName("ID")]
		public int Id { get; set; }

		[System.ComponentModel.DisplayName("Id mieszkania")]
		public int? FlatId { get; set; }

		[System.ComponentModel.DisplayName("Opis usterki")]
		public string Description { get; set; }

		[System.ComponentModel.DisplayName("Stan usterki")]
		public string State { get; set; }
	}
}
