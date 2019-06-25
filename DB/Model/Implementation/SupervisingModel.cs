using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    class SupervisingModel : ISupervisingModel
    {
        public DateTime? data_rozpoczecia { get; set; }
        public DateTime? data_zakonczenia { get; set; }
        public int id_dozorcy { get; set; }
        public int id_budynku { get; set; }
    }
}
