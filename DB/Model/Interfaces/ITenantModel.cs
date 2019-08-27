using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Interfaces
{
    public interface ITenantModel : IDBModel
    {
        string nr_telefonu { get; set; }
        string imie { get; set; }
        string nazwisko { get; set; }
        string PESEL { get; set; }
    }
}
