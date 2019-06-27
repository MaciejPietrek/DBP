using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    public class FaultModel : IFaultModel
    {
        [Display(Name = "Identyfikator Usterki")]
        public int id_usterki { get; set; }

        [Display(Name = "Identyfikator Mieszkania")]
        public int? id_mieszkania { get; set; }

        [Display(Name = "Opis Usterki")]
        public string opis { get; set; }

        [Display(Name = "Stan Usterki")]
        public string stan { get; set; }
    }
}
