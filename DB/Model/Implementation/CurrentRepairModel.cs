using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Interfaces;
using DB.Model.Attributes;

namespace DB.Model.Implementation
{
	[Readonly()]
	public class CurrentRepairModel : ICurrentRepairModel
    {
        [PrimaryKey()]
        [System.ComponentModel.DisplayName("ID")]
        public int Id { get; set; }

		[ForeignKey(typeof(RepairModel))]
        [System.ComponentModel.DisplayName("Identyfikator usterki")]
        public int? id_usterki { get; set; }

		[ForeignKey(typeof(CompanyModel))]
        [System.ComponentModel.DisplayName("Identyfikator firmy")]
        public int? id_firmy { get; set; }

        [System.ComponentModel.DisplayName("Numer telefonu")]
        public string nr_telefonu { get; set; }

		[System.ComponentModel.DisplayName("Data zlecenia")]
        public DateTime? data_zlecenia { get; set; }

        [System.ComponentModel.DisplayName("Data rozpoczęcia")]
        public DateTime? data_rozpoczecia { get; set; }

		[System.ComponentModel.DisplayName("Stan")]
        public string stan { get; set; }
    }
}
