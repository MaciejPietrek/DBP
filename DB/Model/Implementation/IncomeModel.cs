using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Interfaces;

namespace DB.Model.Implementation
{
    public class IncomeModel : IIncomeModel
    {
        [System.ComponentModel.DisplayName("ID")]
        [Display(Name = "Identyfikator Budynku")]
        public int Id { get; set; }

        [System.ComponentModel.DisplayName("Adres")]
        [Display(Name = "Adres budynku")]
        public string Address { get; set; }
        
        [System.ComponentModel.DisplayName("Przychód")]
        [Display(Name = "Przychód z budynku")]
        public double Income { get; set; }

        [System.ComponentModel.DisplayName("Wydatki")]
        [Display(Name = "Wydatki w budynku")]
        public double Expense { get; set; }

        [System.ComponentModel.DisplayName("Profit")]
        [Display(Name = "Profit z budynku")]
        public double Profit { get; set; }
    }
}
