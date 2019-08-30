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

        [System.ComponentModel.DisplayName("Adres")]
        public string Address { get; set; }
        
        [System.ComponentModel.DisplayName("Przychód")]
        public double Income { get; set; }

        [System.ComponentModel.DisplayName("Wydatki")]
        public double Expense { get; set; }

        [System.ComponentModel.DisplayName("Profit")]
        public double Profit { get; set; }
    }
}
