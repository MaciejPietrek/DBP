using DB.Model.Attributes;
using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    public class RentalBillModel : IRentalBillModel
    {
		[PrimaryKey()]
		[System.ComponentModel.DisplayName("ID")]
        public int Id { get; set; }

		[Required()]
		[ForeignKey(typeof(RentalModel))]
		[System.ComponentModel.DisplayName("ID wynajmu")]
        public int? id_wynajem { get; set; }

		[Required()]
		[System.ComponentModel.DisplayName("Kwota")]
        public float cena { get; set; }

		[System.ComponentModel.DisplayName("Numer faktury")]
        public int numer_faktury { get; set; }

		[System.ComponentModel.DisplayName("Data płatności")]
        public DateTime? data_platnosci { get; set; }
    }
}
