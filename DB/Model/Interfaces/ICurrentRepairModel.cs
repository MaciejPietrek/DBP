using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Interfaces
{
    public interface ICurrentRepairModel : IDBModel
    {
        int? id_usterki { get; set; }
        int? id_firmy { get; set; }
        string nr_telefonu { get; set; }
        string stan { get; set; }
        DateTime? data_zlecenia { get; set; }
        DateTime? data_rozpoczecia { get; set; }
    }
}
