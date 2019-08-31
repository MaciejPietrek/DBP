using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;
using DB.Model.Implementation;
using DB.Model.Interfaces;
using DB.Services.Interfaces;

namespace DB.Services.Implementation
{
    public class IncomeService : IIncomeService
    {
        public void AddOrUpdate(IIncomeModel model)
        {
            throw new NotImplementedException();
        }

        public List<IIncomeModel> GetAll()
        {
            List<IIncomeModel> result = new List<IIncomeModel>();
            try
            {
                foreach (var obiekt in GetIncome())
                {
                    result.Add(Mapper.ModelMapper.Mapper.Map<IIncomeModel>(obiekt));
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return null;
            }
        }

        public IIncomeModel GetSingle(int id)
        {
            try
            {
                var queryResult = GetIncome().FirstOrDefault(x => x.Id == id);
                return Mapper.ModelMapper.Mapper.Map<IIncomeModel>(queryResult);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return null;
            }
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IIncomeModel model)
        {
            throw new NotImplementedException();
        }

        private List<IncomeModel> GetIncome()
        {
            List<IncomeModel> incomeList = new List<IncomeModel>();
            using (var ctx = new DBProjectEntities())
            {
                foreach (var building in ctx.Budynki.ToList())
                {
                    var buildingIncome = IncomeChecker.checkIncome(building, null, null);
                    buildingIncome.id_budynku = building.id;
                    buildingIncome.adres = building.adres_budynku;
                    incomeList.Add(buildingIncome);
                }
            }
            return incomeList;
        }

    }
}
