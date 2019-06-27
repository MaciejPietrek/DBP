using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClient.DataReceivers
{
    interface IDataReceiver<T> where T : IDBModel
    {
        List<T> GetList();

        T Get(int id);

        void Remove(int id);

        void Update(T model);
    }
}
