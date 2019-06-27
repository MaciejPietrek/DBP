using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    public class TenantModel : ITenantModel
    {
        [Display(Name = "Identyfikator Najemcy")]
        public int id_najemcy { get; set; }

        [Display(Name = "Numer Telefonu")]
        public string nr_telefonu { get; set; }

        [Display(Name = "Imie")]
        public string imie { get; set; }

        [Display(Name = "Nazwisko")]
        public string nazwisko { get; set; }

        [Display(Name = "PESEL")]
        public string PESEL { get; set; }
    }
}
