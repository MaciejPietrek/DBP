using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Interfaces
{
    interface ISupervisorModel : IDBModel
    {
        int id_dozorcy { get; set; }
        string nr_telefonu { get; set; }
        string Imie { get; set; }
        string Nazwisko { get; set; }
        string PESEL { get; set; }
    }
}
