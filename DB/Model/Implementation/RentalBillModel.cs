using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    class RentalBillModel : IRentalBillModel
    {
        public int id_faktury { get; set; }
        public int? id_wynajem { get; set; }
        public float cena { get; set; }
        public int numer_faktury { get; set; }
        public DateTime? data_platnosci { get; set; }
    }
}
