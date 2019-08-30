using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Interfaces;
using DB.Model.Attributes;

namespace DB.Model.Implementation
{
    public class PaymentModel : IPaymentModel
    {
        [PrimaryKey()]
        [System.ComponentModel.DisplayName("ID")]
        public int Id { get; set; }

		[Required()]
		[ForeignKey(typeof(RentalModel))]
        [System.ComponentModel.DisplayName("ID wynajmu")]
        public int? id_wynajmu { get; set; }

		[Required()]
		[System.ComponentModel.DisplayName("Kwota")]
        public float cena { get; set; }

		[Required()]
		[System.ComponentModel.DisplayName("Tytul")]
        public string tytul { get; set; }

		[System.ComponentModel.DisplayName("Data płatności")]
        public DateTime? data_platnosci { get; set; }
    }
}
