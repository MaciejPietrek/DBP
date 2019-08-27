using DB.Model.Interfaces;
using Frontend.DataRecievers;
using Frontend.Misc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.DataRecievers
{
    class DataReciever<T> : ErrorStoreFunctionality, IDataReciever<T> where T : IDBModel
    {
		HttpConnector httpConnector = HttpConnector.GetInstance(); 
        readonly string url;

        public DataReciever()
        {
			string currentTypeName = typeof(T).Name;
			int substringLength = currentTypeName.IndexOf("Model");
			this.url = "api/" + currentTypeName.Substring(0, substringLength);
        }

        public T Get(int id)
        {
			string result = httpConnector.Get(url + "/" + id.ToString());
			if (result != null)
			{
				return JsonConvert.DeserializeObject<T>(result);
			}
			else
			{
				_lastErrorMessage = httpConnector.LastErrorMessage;
				return default(T);
			}
        }

        public List<T> GetList()
        {
			string result = httpConnector.Get(url);
			if (result != null)
			{
				return JsonConvert.DeserializeObject<List<T>>(result);
			}
			else
			{
				_lastErrorMessage = httpConnector.LastErrorMessage;
				return null;
			}
        }

        public bool Delete(int id)
        {
			string result = httpConnector.Delete(url + "/" + id.ToString());
			if (result != null)
			{
				return true;
			}
			else
			{
				_lastErrorMessage = httpConnector.LastErrorMessage;
				return false;
			}
        }

        public bool Update(T model)
        {
			string result = httpConnector.Update(url, model);
			if (result != null)
			{
				return true;
			}
			else
			{
				_lastErrorMessage = httpConnector.LastErrorMessage;
				return false;
			}
        }
    }
}
