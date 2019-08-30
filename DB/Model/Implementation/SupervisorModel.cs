using DB.Model.Attributes;
using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    public class SupervisorModel : ISupervisorModel
    {
		[PrimaryKey()]
		[System.ComponentModel.DisplayName("ID")]
        public int Id { get; set; }

		[System.ComponentModel.DisplayName("Numer telefonu")]
        public string nr_telefonu { get; set; }

		[System.ComponentModel.DisplayName("Imię")]
        public string Imie { get; set; }

		[System.ComponentModel.DisplayName("Nazwisko")]
        public string Nazwisko { get; set; }

		[Required()]
		[System.ComponentModel.DisplayName("PESEL")]
        public string PESEL { get; set; }
    }
}
