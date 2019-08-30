using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Interfaces;

namespace DB.Model.Implementation
{
    public class LatePaymentModel : ILatePaymentModel
    {
        [System.ComponentModel.DisplayName("ID")]
        [Display(Name = "Identyfikator Najemcy")]
        public int Id { get; set; }

        [System.ComponentModel.DisplayName("Imię i nazwisko")]
        [Display(Name = "Imie i nazwisko")]
        public string imie { get; set; }
        
        [System.ComponentModel.DisplayName("Numer Telefonu")]
        [Display(Name = "Numer Telefonu")]
        public string nr_telefonu { get; set; }

        [System.ComponentModel.DisplayName("Adres")]
        [Display(Name = "Adres")]
        public string adres { get; set; }

        [System.ComponentModel.DisplayName("Zadłużenie")]
        [Display(Name = "Zadłużenie")]
        public double kwota { get; set; }
    }
}
