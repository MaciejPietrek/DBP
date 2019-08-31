using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Interfaces
{
    public interface IIncomeModel : IDBModel
    {
        int id_budynku { get; set; }
        string adres { get; set; }
        double przychod { get; set; }
        double wydatek { get; set; }
        double profit { get; set; }
    }
}
