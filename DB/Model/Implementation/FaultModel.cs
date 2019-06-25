using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    class FaultModel : IFaultModel
    {
        public int id_usterki { get; set; }
        public int? id_mieszkania { get; set; }
        public string opis { get; set; }
        public string stan { get; set; }
    }
}
