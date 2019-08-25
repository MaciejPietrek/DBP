using DB.Model.Implementation;
using DBClient.DataRecievers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Model.DAO
{
	class BuildingDAO : IDataReciever<BuildingModel>
	{
		public BuildingModel Get(int id)
		{
			throw new NotImplementedException();
		}

		public List<BuildingModel> GetList()
		{
			List<BuildingModel> x = new List<BuildingModel>();
			x.Add(new BuildingModel
			{
				Id = 0,
				adres_budynku = "Gliwice, armii piłsudskiego 28"
			});
			x.Add(new BuildingModel
			{
				Id = 1,
				adres_budynku = "Lubliniec, Mikiłaja 12"
			});
			x.Add(new BuildingModel
			{
				Id = 2,
				adres_budynku = "Warszawa, Warszawiaków 23"
			});
			return x;
		}

		public void Remove(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(BuildingModel model)
		{
			throw new NotImplementedException();
		}
	}
}
