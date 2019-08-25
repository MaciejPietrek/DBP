using DB.Model.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClient.DataReceivers
{
    class DataReceiver<T> where T : IDBModel
    {
        private readonly string url;

        public DataReceiver(string url)
        {
            this.url = url;
        }

        public T Get(int id)
        {
            Connector.Get(url + "/" + id.ToString()).Wait();

            var result = JsonConvert.DeserializeObject<T>(Connector.Result);

            return result;
        }

        public List<T> GetList()
        {
            Connector.Get(url).Wait();

            var result = JsonConvert.DeserializeObject<List<T>>(Connector.Result);

            return result;
        }

        public void Remove(int id)
        {
            Connector.Del(url + "/Delete ? id=" + id.ToString()).Wait();
        }

        public void Update(T model)
        {
            Connector.Upd(url, model);
        }
    }
}
