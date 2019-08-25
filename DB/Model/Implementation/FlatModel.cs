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
    public class FlatModel : IFlatModel
    {
		[PrimaryKey()]
		[System.ComponentModel.DisplayName("ID")]
		[Display(Name = "Identyfikator Mieszkania")]
        public int Id { get; set; }

		[ForeignKey(typeof(BuildingModel))]
		[System.ComponentModel.DisplayName("ID budynku")]
		[Display(Name = "Identyfikator Budynku")]
        public int? id_budynku { get; set; }

		[System.ComponentModel.DisplayName("Numer mieszkania")]
		[Display(Name = "Numer Mieszkania")]
        public int numer { get; set; }

		[System.ComponentModel.DisplayName("Powierzchnia")]
		[Display(Name = "Metraż Mieszkania")]
        public float? metraz { get; set; }

		[System.ComponentModel.DisplayName("Opis")]
		[Display(Name = "Opis Mieszkania")]
        public string opis { get; set; }
    }
}
