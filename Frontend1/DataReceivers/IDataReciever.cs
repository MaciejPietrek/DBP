using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.DataRecievers
{
    public interface IDataReciever<T> where T : IDBModel
    {
        List<T> GetList();

        T Get(int id);

        bool Delete(int id);

        bool Update(T model);
    }
}
