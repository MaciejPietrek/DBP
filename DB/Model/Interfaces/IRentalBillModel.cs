using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Interfaces
{
    public interface IRentalBillModel : IDBModel
    {
        int id_faktury { get; set; }
        int? id_wynajem { get; set; }
        float cena { get; set; }
        int numer_faktury { get; set; }
        DateTime? data_platnosci { get; set; }
    }
}
