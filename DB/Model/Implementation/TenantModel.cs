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
    public class TenantModel : ITenantModel
    {
		[PrimaryKey()]
		[System.ComponentModel.DisplayName("ID")]
		[Display(Name = "Identyfikator Najemcy")]
        public int Id { get; set; }

		[System.ComponentModel.DisplayName("Numer Telefonu")]
		[Display(Name = "Numer Telefonu")]
        public string nr_telefonu { get; set; }

		[System.ComponentModel.DisplayName("Imię")]
		[Display(Name = "Imie")]
        public string imie { get; set; }

		[System.ComponentModel.DisplayName("Nazwisko")]
		[Display(Name = "Nazwisko")]
        public string nazwisko { get; set; }

		[System.ComponentModel.DisplayName("PESEL")]
		[Display(Name = "PESEL")]
        public string PESEL { get; set; }
    }
}
