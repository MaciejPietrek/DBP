using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Interfaces
{
    public interface IIncomeModel : IDBModel
    {
        string Address { get; set; }
        double Income { get; set; }
        double Expense { get; set; }
        double Profit { get; set; }
    }
}
