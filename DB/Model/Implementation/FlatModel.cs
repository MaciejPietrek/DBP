using DB.Model.Attributes;
using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    public class FlatModel : IFlatModel
    {
		[PrimaryKey()]
		[System.ComponentModel.DisplayName("ID")]
        public int Id { get; set; }

		[Required()]
		[ForeignKey(typeof(BuildingModel))]
		[System.ComponentModel.DisplayName("ID budynku")]
        public int? id_budynku { get; set; }

		[System.ComponentModel.DisplayName("Numer mieszkania")]
        public int numer { get; set; }

		[System.ComponentModel.DisplayName("Powierzchnia")]
        public float? metraz { get; set; }

		[System.ComponentModel.DisplayName("Opis")]
        public string opis { get; set; }
    }
}
