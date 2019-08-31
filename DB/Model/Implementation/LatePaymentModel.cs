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
    public class LatePaymentModel : ILatePaymentModel
    {
        [System.ComponentModel.DisplayName("ID")]
        public int Id { get; set; }

        [System.ComponentModel.DisplayName("ID Najemcy")]
        public int id_najemcy { get; set; }

        [System.ComponentModel.DisplayName("Imię i nazwisko")]
        public string imie { get; set; }
        
        [System.ComponentModel.DisplayName("Numer Telefonu")]
        public string nr_telefonu { get; set; }

        [System.ComponentModel.DisplayName("Adres")]
        public string adres { get; set; }

        [System.ComponentModel.DisplayName("Zadłużenie")]
        public double kwota { get; set; }
    }
}
