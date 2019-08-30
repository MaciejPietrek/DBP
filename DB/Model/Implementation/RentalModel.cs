using DB.Model.Attributes;
using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    public class RentalModel : IRentalModel
    {
		[PrimaryKey()]
		[System.ComponentModel.DisplayName("ID")]
        public int Id { get; set; }

		[Required()]
		[ForeignKey(typeof(FlatModel))]
		[System.ComponentModel.DisplayName("ID mieszkania")]
        public int? id_mieszkania { get; set; }

		[System.ComponentModel.DisplayName("Data zakończenia najmu")]
        public DateTime? data_rozpoczecia { get; set; }

		[Required()]
		[System.ComponentModel.DisplayName("Data rozpoczęcia najmu")]
        public DateTime? data_zakonczenia { get; set; }

		[Required()]
		[ForeignKey(typeof(TenantModel))]
		[System.ComponentModel.DisplayName("ID najemcy")]
        public int? id_najemcy { get; set; }

		[System.ComponentModel.DisplayName("Miesiączny czynsz")]
        public float? cena_miesieczna { get; set; }
    }
}
