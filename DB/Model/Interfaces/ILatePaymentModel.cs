using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Interfaces
{
    public interface ILatePaymentModel : IDBModel
    {
        string imie { get; set; }
        string nr_telefonu { get; set; }
        string adres { get; set; }
        double kwota { get; set; }
    }
}
