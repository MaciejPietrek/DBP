using DB.Model.Interfaces;
using DB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Interfaces
{
    public interface IDBService<T> where T : IDBModel
    {
        T GetSingle(int id);

        List<T> GetAll();

        bool Remove(int id);

        bool Remove(T model);

        void AddOrUpdate(T model);
    }
}
