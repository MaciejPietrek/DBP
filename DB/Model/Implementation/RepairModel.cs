using DB.Model.Attributes;
using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    public class RepairModel : IRepairModel
    {
		[PrimaryKey()]
		[System.ComponentModel.DisplayName("ID")]
        public int Id { get; set; }

		[Required()]
		[ForeignKey(typeof(FaultModel))]
		[System.ComponentModel.DisplayName("Identyfikator usterki")]
        public int? id_usterki { get; set; }

		[Required()]
		[ForeignKey(typeof(CompanyModel))]
		[System.ComponentModel.DisplayName("Identyfikator firmy")]
        public int? id_firmy { get; set; }

		[System.ComponentModel.DisplayName("Numer telefonu")]
        public string nr_telefonu { get; set; }

		[Required()]
		[System.ComponentModel.DisplayName("Stan usterki")]
        public string stan { get; set; }

		[Required()]
		[System.ComponentModel.DisplayName("Data zlecenia")]
        public DateTime? data_zlecenia { get; set; }

		[System.ComponentModel.DisplayName("Data rozpoczęcia")]
        public DateTime? data_rozpoczecia { get; set; }

		[System.ComponentModel.DisplayName("Data ukończenia")]
        public DateTime? data_ukonczenia { get; set; }
    }
}
