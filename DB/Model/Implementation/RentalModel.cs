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
    public class RentalModel : IRentalModel
    {
		[PrimaryKey()]
		[System.ComponentModel.DisplayName("ID")]
		[Display(Name = "Identyfikator Wynajmu")]
        public int Id { get; set; }

		[ForeignKey(typeof(FlatModel))]
		[System.ComponentModel.DisplayName("ID mieszkania")]
		[Display(Name = "Identyfikator Mieszkania")]
        public int? id_mieszkania { get; set; }

		[System.ComponentModel.DisplayName("Data zakończenia najmu")]
		[Display(Name = "Data Rozpoczęcia")]
        public DateTime? data_rozpoczecia { get; set; }

		[System.ComponentModel.DisplayName("Data rozpoczęcia najmu")]
		[Display(Name = "Data Zakończenia")]
        public DateTime? data_zakonczenia { get; set; }

		[ForeignKey(typeof(TenantModel))]
		[System.ComponentModel.DisplayName("ID najemcy")]
		[Display(Name = "Identyfikator Najemcy")]
        public int? id_najemcy { get; set; }

		[System.ComponentModel.DisplayName("Miesiączny czynsz")]
		[Display(Name = "Cena Miesieczna Mieszkania")]
        public float? cena_miesieczna { get; set; }
    }
}
