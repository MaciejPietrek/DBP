using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    class RepairBillModel : IRepairBillModel
    {
        public int id_faktury { get; set; }
        public int? id_naprawy { get; set; }
        public float cena { get; set; }
        public int numer_faktury { get; set; }
        public DateTime? data_platnosci { get; set; }
    }
}
