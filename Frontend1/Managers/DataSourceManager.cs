using DB.Model.Interfaces;
using Frontend.DataRecievers;
using Frontend.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Managers
{
	class DataSourceManager : ErrorStoreFunctionality
	{
		static DataSourceManager _instance = new DataSourceManager();

		//HttpConnector _httpConnector = HttpConnector.GetInstance();
		Dictionary<Type, object> _dataHolder = new Dictionary<Type, object>(); 

		private DataSourceManager() { }

		public static DataSourceManager GetInstance()
		{
			return _instance;
		}

		public object Get<T>() where T : IDBModel
		{
			foreach (var data in _dataHolder)
			{
				if (data.Key.Equals(typeof(T)))
				{
					return data.Value;
				}
			}
			DataReciever<T> dataReciever = new DataReciever<T>();
			var recievedData = dataReciever.GetList();
			if (recievedData != null)
			{
				KeyValuePair<Type, object> newEntry = new KeyValuePair<Type, object>(typeof(T), recievedData);
				_dataHolder.Add(newEntry.Key, newEntry.Value);
				return newEntry.Value;
			}
			else
			{
				_lastErrorMessage = dataReciever.LastErrorMessage;
				return null;
			}
		}

		public string Add<T>(T newEntity) where T : IDBModel
		{
			DataReciever<T> dataReciever = new DataReciever<T>();
			if (dataReciever.Update(newEntity))
			{
				foreach (var data in _dataHolder)
				{
					if (data.Key.Equals(typeof(T)))
					{
						(data.Value as List<T>).Add(newEntity);
					}
				}
				return null;
			}
			else
			{
				return dataReciever.LastErrorMessage;
			}
		}

		public string Update<T>(T modifiedEntity, T oldEntity) where T : IDBModel
		{
			DataReciever<T> dataReciever = new DataReciever<T>();
			if (dataReciever.Update(modifiedEntity))
			{
				foreach (var data in _dataHolder)
				{
					if (data.Key.Equals(typeof(T)))
					{
						var entityList = data.Value as List<T>;
						entityList[entityList.IndexOf(oldEntity)] = modifiedEntity;
					}
				}
				return null;
			}
			else
			{
				return dataReciever.LastErrorMessage;
			}
		}

		public string Delete<T>(T entity) where T : IDBModel
		{
			DataReciever<T> dataReciever = new DataReciever<T>();
			if (dataReciever.Delete(entity.Id))
			{
				foreach (var data in _dataHolder)
				{
					if (data.Key.Equals(typeof(T)))
					{
						(data.Value as List<T>).Remove(entity);
					}
				}
				return null;
			}
			else
			{
				return dataReciever.LastErrorMessage;
			}
		}
	}
}
