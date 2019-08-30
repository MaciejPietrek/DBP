using DB.Model.Attributes;
using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    public class CompanyModel : ICompanyModel
    {
		[PrimaryKey()]
		[System.ComponentModel.DisplayName("ID")]
		public int Id { get; set; }

		[Required()]
		[System.ComponentModel.DisplayName("NIP")]
		public string NIP { get; set; }

		[System.ComponentModel.DisplayName("Numer telefornu")]
        public string nr_telefonu { get; set; }

		[System.ComponentModel.DisplayName("Nazwa firmy")]
        public string nazwa_firmy { get; set; }
    }
}
