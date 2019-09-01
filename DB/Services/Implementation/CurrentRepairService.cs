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
    public class CurrentRepairService : ICurrentRepairService
    {
        public void AddOrUpdate(ICurrentRepairModel model)
        {
            throw new NotImplementedException();
        }

        public List<ICurrentRepairModel> GetAll()
        {
            List<ICurrentRepairModel> result = new List<ICurrentRepairModel>();
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    foreach (var obiekt in GetRepairs())
                    {
                        result.Add(Mapper.ModelMapper.Mapper.Map<ICurrentRepairModel>(obiekt));
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return null;
            }
        }

        public ICurrentRepairModel GetSingle(int id)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var queryResult = ctx.Naprawy.Where(x => x.id == id).FirstOrDefault();
                    return Mapper.ModelMapper.Mapper.Map<ICurrentRepairModel>(queryResult);
                }
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
        public bool Remove(ICurrentRepairModel model)
        {
            throw new NotImplementedException();
        }

        private List<CurrentRepairModel> GetRepairs()
        {
            var currentRepairs = new List<CurrentRepairModel>();
            using (var ctx = new DBProjectEntities())
            {
                foreach (var repair in ctx.Naprawy.Where(x=>x.stan=="W trakcie").ToList())
                {
                    var repairModel = CurrentRepairChecker.checkRepair(repair);
                    currentRepairs.Add(repairModel);
                }
            }
            return currentRepairs;
        }
    }
}
