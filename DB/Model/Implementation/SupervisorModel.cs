using DB.Model.Attributes;
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
		[PrimaryKey()]
		[System.ComponentModel.DisplayName("ID")]
		[Display(Name = "Identyfikator Dozorcy")]
        public int Id { get; set; }

		[System.ComponentModel.DisplayName("Numer telefonu")]
		[Display(Name = "Numer Telefonu")]
        public string nr_telefonu { get; set; }

		[System.ComponentModel.DisplayName("Imię")]
		[Display(Name = "Imie")]
        public string Imie { get; set; }

		[System.ComponentModel.DisplayName("Nazwisko")]
		[Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }

		[System.ComponentModel.DisplayName("PESEL")]
		[Display(Name = "Pesel")]
        public string PESEL { get; set; }
    }
}
