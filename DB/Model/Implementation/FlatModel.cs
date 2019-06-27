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
        [Display(Name = "Identyfikator Mieszkania")]
        public int id_mieszkania { get; set; }

        [Display(Name = "Identyfikator Budynku")]
        public int? id_budynku { get; set; }

        [Display(Name = "Numer Mieszkania")]
        public int numer { get; set; }

        [Display(Name = "Metraż Mieszkania")]
        public float? metraz { get; set; }

        [Display(Name = "Opis Mieszkania")]
        public string opis { get; set; }
    }
}
