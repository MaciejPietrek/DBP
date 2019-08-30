using DB.Model.Attributes;
using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    public class FaultModel : IFaultModel
    {
		[PrimaryKey()]
		[System.ComponentModel.DisplayName("ID")]
        public int Id { get; set; }

		[Required()]
		[ForeignKey(typeof(FlatModel))]
		[System.ComponentModel.DisplayName("Id mieszkania")]
        public int? id_mieszkania { get; set; }

		[Required()]
		[System.ComponentModel.DisplayName("Opis usterki")]
        public string opis { get; set; }

		[Required()]
		[System.ComponentModel.DisplayName("Stan usterki")]
        public string stan { get; set; }
    }
}
