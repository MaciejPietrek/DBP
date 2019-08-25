using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Interfaces
{
    public interface IBuildingModel : IDBModel
    {
        string adres_budynku { get; set; }
    }
}
