using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    public class SupervisingModel : ISupervisingModel
    {
        [Display(Name = "Data Rozpoczęcia")]
        public DateTime? data_rozpoczecia { get; set; }

        [Display(Name = "Data Zakończenia")]
        public DateTime? data_zakonczenia { get; set; }

        [Display(Name = "Identyfikator Dozorcy")]
        public int id_dozorcy { get; set; }

        [Display(Name = "Identyfikator Budynku")]
        public int id_budynku { get; set; }
    }
}
