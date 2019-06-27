using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    public class RepairModel : IRepairModel
    {
        [Display(Name = "Identyfikator Naprawy")]
        public int id_naprawy { get; set; }

        [Display(Name = "Identyfikator Usterki")]
        public int? id_usterki { get; set; }

        [Display(Name = "Identyfikator Firmy")]
        public int? id_firmy { get; set; }

        [Display(Name = "Numer Telefonu")]
        public string nr_telefonu { get; set; }

        [Display(Name = "Stan Usterki")]
        public string stan { get; set; }

        [Display(Name = "Data Zlecenia")]
        public DateTime? data_zlecenia { get; set; }

        [Display(Name = "Data Rozpoczęcia")]
        public DateTime? data_rozpoczecia { get; set; }

        [Display(Name = "Data Ukończenia")]
        public DateTime? data_ukonczenia { get; set; }
    }
}
