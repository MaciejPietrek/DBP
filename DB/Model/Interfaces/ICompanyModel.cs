using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Interfaces
{
    public interface ICompanyModel : IDBModel
    {
        int id_firmy { get; set; }
        string NIP { get; set; }
        string nr_telefonu { get; set; }
        string nazwa_firmy { get; set; }
    }
}
