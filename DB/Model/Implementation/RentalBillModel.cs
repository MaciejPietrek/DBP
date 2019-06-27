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
        [Display(Name = "Identyfikator Faktury")]
        public int id_faktury { get; set; }

        [Display(Name = "Identyfikator Wynajmu")]
        public int? id_wynajem { get; set; }

        [Display(Name = "Kwota")]
        public float cena { get; set; }

        [Display(Name = "Numer Faktury")]
        public int numer_faktury { get; set; }

        [Display(Name = "Data Płatności")]
        public DateTime? data_platnosci { get; set; }
    }
}
