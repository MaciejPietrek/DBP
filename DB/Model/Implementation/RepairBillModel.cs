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
    public class RepairBillModel : IRepairBillModel
    {
		[PrimaryKey()]
		[System.ComponentModel.DisplayName("ID")]
		[Display(Name = "Identyfikator Faktury")]
        public int Id { get; set; }

		[ForeignKey(typeof(RepairModel))]
		[System.ComponentModel.DisplayName("Identyfikator Naprawy")]
		[Display(Name = "Identyfikator Naprawy")]
        public int? id_naprawy { get; set; }

		[System.ComponentModel.DisplayName("Kwota do zapłaty")]
		[Display(Name = "Kwota")]
        public float cena { get; set; }

		[System.ComponentModel.DisplayName("Numer faktury")]
		[Display(Name = "Numer Faktury")]
        public int numer_faktury { get; set; }

		[System.ComponentModel.DisplayName("Data płatności")]
		[Display(Name = "Data Płatności")]
        public DateTime? data_platnosci { get; set; }
    }
}
