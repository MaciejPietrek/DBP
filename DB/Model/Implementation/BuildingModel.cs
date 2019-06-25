using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    class BuildingModel : IBuildingModel
    {
        public int id_budynku { get; set; }
        public string adres_budynku { get; set; }
    }
}
