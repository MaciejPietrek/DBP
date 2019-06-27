using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    public class CompanyModel : ICompanyModel
    {
        [Display(Name = "Identyfikator Firmy")]
        public int id_firmy { get; set; }

        [Display(Name = "NIP")]
        public string NIP { get; set; }

        [Display(Name = "Numer Telefonu")]
        public string nr_telefonu { get; set; }

        [Display(Name = "Nazwa Firmy")]
        public string nazwa_firmy { get; set; }
    }
}
