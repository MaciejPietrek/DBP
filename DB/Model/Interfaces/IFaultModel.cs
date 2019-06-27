using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Interfaces
{
    public interface IFaultModel : IDBModel
    {
        int id_usterki { get; set; }
        int? id_mieszkania { get; set; }
        string opis { get; set; }
        string stan { get; set; }
    }
}
