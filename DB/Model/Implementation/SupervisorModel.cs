using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    public class SupervisorModel : ISupervisorModel
    {
        [Display(Name = "Identyfikator Dozorcy")]
        public int id_dozorcy { get; set; }

        [Display(Name = "Numer Telefonu")]
        public string nr_telefonu { get; set; }

        [Display(Name = "Imie")]
        public string Imie { get; set; }

        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }

        [Display(Name = "Pesel")]
        public string PESEL { get; set; }
    }
}
