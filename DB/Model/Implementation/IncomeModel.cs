using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Attributes;
using DB.Model.Interfaces;

namespace DB.Model.Implementation
{
	[Readonly()]
	public class IncomeModel : IIncomeModel
    {
        [System.ComponentModel.DisplayName("ID")]
        public int Id { get; set; }

        [System.ComponentModel.DisplayName("ID Budynku")]
        public int id_budynku { get; set; }

        [System.ComponentModel.DisplayName("Adres")]
        public string adres { get; set; }
        
        [System.ComponentModel.DisplayName("Przychód")]
        public double przychod { get; set; }

        [System.ComponentModel.DisplayName("Wydatki")]
        public double wydatek { get; set; }

        [System.ComponentModel.DisplayName("Profit")]
        public double profit { get; set; }
    }
}
