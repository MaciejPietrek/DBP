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
    public class SupervisingModel : ISupervisingModel
    {
		[PrimaryKey()]
		[System.ComponentModel.DisplayName("ID")]
		public int Id { get; set; }

		[System.ComponentModel.DisplayName("Data Rozpoczęcia")]
		[Display(Name = "Data Rozpoczęcia")]
        public DateTime? data_rozpoczecia { get; set; }

		[System.ComponentModel.DisplayName("Data Zakończenia")]
		[Display(Name = "Data Zakończenia")]
        public DateTime? data_zakonczenia { get; set; }

		[ForeignKey(typeof(SupervisorModel))]
		[System.ComponentModel.DisplayName("Identyfikator Dozorcy")]
		[Display(Name = "Identyfikator Dozorcy")]
        public int id_dozorcy { get; set; }

		[ForeignKey(typeof(BuildingModel))]
		[System.ComponentModel.DisplayName("Identyfikator Budynku")]
		[Display(Name = "Identyfikator Budynku")]
        public int id_budynku { get; set; }
    }
}
