using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Interfaces;
using System.ComponentModel.DataAnnotations;
using DB.Model.Attributes;

namespace DB.Model.Implementation
{
    public class CurrentRepairModel : ICurrentRepairModel
    {
        [PrimaryKey()]
        [System.ComponentModel.DisplayName("ID")]
        [Display(Name = "Identyfikator Naprawy")]
        public int Id { get; set; }

        [ForeignKey(typeof(RepairModel))]
        [System.ComponentModel.DisplayName("Identyfikator usterki")]
        [Display(Name = "Identyfikator Usterki")]
        public int? id_usterki { get; set; }

        [ForeignKey(typeof(CompanyModel))]
        [System.ComponentModel.DisplayName("Identyfikator firmy")]
        [Display(Name = "Identyfikator Firmy")]
        public int? id_firmy { get; set; }

        [System.ComponentModel.DisplayName("Numer telefonu")]
        [Display(Name = "Numer Telefonu")]
        public string nr_telefonu { get; set; }
        
        [System.ComponentModel.DisplayName("Data zlecenia")]
        [Display(Name = "Data Zlecenia")]
        public DateTime? data_zlecenia { get; set; }

        [System.ComponentModel.DisplayName("Data rozpoczęcia")]
        [Display(Name = "Data Rozpoczęcia")]
        public DateTime? data_rozpoczecia { get; set; }

        [System.ComponentModel.DisplayName("Stan")]
        [Display(Name = "Stan")]
        public string stan { get; set; }
    }
}
