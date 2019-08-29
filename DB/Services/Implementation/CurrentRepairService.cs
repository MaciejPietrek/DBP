using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Interfaces;
using DB.Services.Interfaces;

namespace DB.Services.Implementation
{
    public class CurrentRepairService : ICurrentRepairService
    {
        public void AddOrUpdate(ICurrentRepairModel model)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var newObject = ctx.Naprawy.Find(model.Id);

                    if (newObject == null)
                    {
                        newObject = Mapper.ModelMapper.Mapper.Map<Naprawy>(model);
                        ctx.Naprawy.Add(newObject);
                    }
                    else
                    {
                        newObject.data_rozpoczecia = model.data_rozpoczecia;
                        newObject.data_zlecenia = model.data_zlecenia;
                        newObject.id_firmy = model.id_firmy;
                        newObject.stan = model.stan;
                        newObject.id_usterki = model.id_usterki;
                        newObject.nr_telefonu = model.nr_telefonu;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }

        public List<ICurrentRepairModel> GetAll()
        {
            List<ICurrentRepairModel> result = new List<ICurrentRepairModel>();
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var naprawy = ctx.Naprawy.Where(x => x.stan == "W trakcie").ToList();
                    foreach (var obiekt in naprawy)
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
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var queryResult = ctx.Naprawy.Where(x => x.id == id).FirstOrDefault();
                    if (queryResult is null)
                    {
                        return false;
                    }
                    else
                    {
                        ctx.Naprawy.Remove(queryResult);
                        ctx.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return false;
            }
        }
        public bool Remove(ICurrentRepairModel model)
        {
            return Remove(model.Id);
        }
    }
}
