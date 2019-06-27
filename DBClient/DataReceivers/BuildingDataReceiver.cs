using DB.Model.Implementation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DBClient.DataReceivers
{
    class BuildingDataReceiver : IDataReceiver<BuildingModel>
    {
        static private readonly string url = "http://localhost:51950/api/Building";

        public BuildingModel Get(int id)
        {
            Connector.Get(url + "/" + id.ToString()).Wait();

            var result = JsonConvert.DeserializeObject<BuildingModel>(Connector.Result);

            return result;
        }

        public List<BuildingModel> GetList()
        {
            Connector.Get(url).Wait();

            var result = JsonConvert.DeserializeObject<List<BuildingModel>>(Connector.Result);

            return result;
        }

        public void Remove(int id)
        {
            Connector.Del(url + "/Delete ? id=" + id.ToString()).Wait();
        }

        public void Update(BuildingModel model)
        {
            Connector.Upd(url, model);
        }

    }
}
