using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Interfaces
{
    public interface ISupervisorModel : IDBModel
    {
        string nr_telefonu { get; set; }
        string Imie { get; set; }
        string Nazwisko { get; set; }
        string PESEL { get; set; }
    }
}
