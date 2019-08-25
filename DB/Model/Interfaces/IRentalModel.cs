using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Interfaces
{
    public interface IRentalModel : IDBModel
    {
        int? id_mieszkania { get; set; }
        DateTime? data_rozpoczecia { get; set; }
        DateTime? data_zakonczenia { get; set; }
        int? id_najemcy { get; set; }
        float? cena_miesieczna { get; set; }
    }
}
