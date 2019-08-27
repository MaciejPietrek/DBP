using DB.Model.Attributes;
using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    public class FaultModel : IFaultModel
    {
		[PrimaryKey()]
		[System.ComponentModel.DisplayName("ID")]
		[Display(Name = "Identyfikator Usterki")]
        public int Id { get; set; }

		[ForeignKey(typeof(FlatModel))]
		[System.ComponentModel.DisplayName("Id mieszkania")]
		[Display(Name = "Identyfikator Mieszkania")]
        public int? id_mieszkania { get; set; }

		[System.ComponentModel.DisplayName("Opis usterki")]
		[Display(Name = "Opis Usterki")]
        public string opis { get; set; }

		[System.ComponentModel.DisplayName("Stan usterki")]
		[Display(Name = "Stan Usterki")]
        public string stan { get; set; }
    }
}
