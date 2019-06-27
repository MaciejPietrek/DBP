using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    public class BuildingModel : IBuildingModel
    {
        [Display(Name = "Identyfikator Budynku")]
        public int id_budynku { get; set; }

        [Display(Name = "Adres Budynku")]
        public string adres_budynku { get; set; }
    }
}
