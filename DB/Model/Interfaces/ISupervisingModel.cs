using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Interfaces
{
    interface ISupervisingModel : IDBModel
    {
        DateTime? data_rozpoczecia { get; set; }
        DateTime? data_zakonczenia { get; set; }
        int id_dozorcy { get; set; }
        int id_budynku { get; set; }
    }
}
