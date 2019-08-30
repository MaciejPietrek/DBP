using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Interfaces;
using System.ComponentModel.DataAnnotations;
using DB.Model.Attributes;

namespace DB.Model.Implementation
{
    public class PaymentModel : IPaymentModel
    {
        [PrimaryKey()]
        [System.ComponentModel.DisplayName("ID")]
        [Display(Name = "Identyfikator Platnosci")]
        public int Id { get; set; }

        [ForeignKey(typeof(RentalModel))]
        [System.ComponentModel.DisplayName("ID wynajmu")]
        [Display(Name = "Identyfikator Wynajmu")]
        public int? id_wynajmu { get; set; }

        [System.ComponentModel.DisplayName("Kwota")]
        [Display(Name = "Kwota")]
        public float cena { get; set; }

        [System.ComponentModel.DisplayName("Tytul")]
        [Display(Name = "Tytul")]
        public string tytul { get; set; }

        [System.ComponentModel.DisplayName("Data płatności")]
        [Display(Name = "Data Płatności")]
        public DateTime? data_platnosci { get; set; }
    }
}
