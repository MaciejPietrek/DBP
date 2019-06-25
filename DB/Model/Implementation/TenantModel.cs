using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    class TenantModel : ITenantModel
    {
        public int id_najemcy { get; set; }
        public string nr_telefonu { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string PESEL { get; set; }
    }
}
