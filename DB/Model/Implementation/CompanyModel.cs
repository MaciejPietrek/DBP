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
    public class CompanyModel : ICompanyModel
    {
		[PrimaryKey()]
		[Display(Name = "Identyfikator Firmy")]
		[System.ComponentModel.DisplayName("ID")]
		public int Id { get; set; }

        [Display(Name = "NIP")]
		[System.ComponentModel.DisplayName("NIP")]
		public string NIP { get; set; }

		[System.ComponentModel.DisplayName("Numer telefornu")]
		[Display(Name = "Numer Telefonu")]
        public string nr_telefonu { get; set; }

		[System.ComponentModel.DisplayName("Nazwa firmy")]
		[Display(Name = "Nazwa Firmy")]
        public string nazwa_firmy { get; set; }
    }
}
