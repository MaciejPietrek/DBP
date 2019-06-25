using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Interfaces
{
    interface IBuildingModel : IDBModel
    {
        int id_budynku { get; set; }
        string adres_budynku { get; set; }
    }
}
