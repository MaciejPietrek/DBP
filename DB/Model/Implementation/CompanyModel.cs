using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Implementation
{
    class CompanyModel : ICompanyModel
    {
        public int id_firmy { get; set; }
        public string NIP { get; set; }
        public string nr_telefonu { get; set; }
        public string nazwa_firmy { get; set; }
    }
}
