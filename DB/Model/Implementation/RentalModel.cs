using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    public class RentalModel : IRentalModel
    {
        [Display(Name = "Identyfikator Wynajmu")]
        public int id_wynajmu { get; set; }

        [Display(Name = "Identyfikator Mieszkania")]
        public int? id_mieszkania { get; set; }

        [Display(Name = "Data Rozpoczęcia")]
        public DateTime? data_rozpoczecia { get; set; }

        [Display(Name = "Data Zakończenia")]
        public DateTime? data_zakonczenia { get; set; }

        [Display(Name = "Identyfikator Najemcy")]
        public int? id_najemcy { get; set; }

        [Display(Name = "Cena Miesieczna Mieszkania")]
        public float? cena_miesieczna { get; set; }
    }
}
