using DB.Model.Interfaces;
using DB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Implementation
{
    public class RepairService : IRepairService
    {
        public void AddOrUpdate(IRepairModel model)
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
                        newObject.data_ukonczenia = model.data_ukonczenia;
                        newObject.data_zlecenia = model.data_zlecenia;
                        newObject.id_firmy = model.id_firmy;
                        newObject.id_usterki = model.id_usterki;
                        newObject.nr_telefonu = model.nr_telefonu;
                        newObject.stan = model.stan;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }

        public List<IRepairModel> GetAll()
        {
            List<IRepairModel> result = new List<IRepairModel>();
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    foreach (var obiekt in ctx.Naprawy.ToList())
                    {
                        result.Add(Mapper.ModelMapper.Mapper.Map<IRepairModel>(obiekt));
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

        public IRepairModel GetSingle(int id)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var queryResult = ctx.Naprawy.Where(x => x.id == id).FirstOrDefault();
                    return Mapper.ModelMapper.Mapper.Map<IRepairModel>(queryResult);
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

        public bool Remove(IRepairModel model)
        {
            return Remove(model.Id);
        }
    }
}
