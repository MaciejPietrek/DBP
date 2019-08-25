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
    public class RentalBillModel : IRentalBillModel
    {
		[PrimaryKey()]
		[System.ComponentModel.DisplayName("ID")]
		[Display(Name = "Identyfikator Faktury")]
        public int Id { get; set; }

		[ForeignKey(typeof(RentalModel))]
		[System.ComponentModel.DisplayName("ID wynajmu")]
		[Display(Name = "Identyfikator Wynajmu")]
        public int? id_wynajem { get; set; }

		[System.ComponentModel.DisplayName("Kwota")]
		[Display(Name = "Kwota")]
        public float cena { get; set; }

		[System.ComponentModel.DisplayName("Numer faktury")]
		[Display(Name = "Numer Faktury")]
        public int numer_faktury { get; set; }

		[System.ComponentModel.DisplayName("Data płatności")]
		[Display(Name = "Data Płatności")]
        public DateTime? data_platnosci { get; set; }
    }
}
