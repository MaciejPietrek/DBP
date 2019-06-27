using DB.Model.Interfaces;
using DB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Implementation
{
    public class FaultService : IFaultService
    {
        public void AddOrUpdate(IFaultModel model)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var newObject = ctx.Usterki.Find(model.id_usterki);

                    if (newObject == null)
                    {
                        newObject = Mapper.ModelMapper.Mapper.Map<Usterki>(model);
                        ctx.Usterki.Add(newObject);
                    }
                    else
                    {
                        newObject.id_mieszkania = model.id_mieszkania;
                        newObject.opis = model.opis;
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

        public List<IFaultModel> GetAll()
        {
            List<IFaultModel> result = new List<IFaultModel>();
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    foreach (var obiekt in ctx.Usterki.ToList())
                    {
                        result.Add(Mapper.ModelMapper.Mapper.Map<IFaultModel>(obiekt));
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

        public IFaultModel GetSingle(int id)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var queryResult = ctx.Usterki.Where(x => x.id_usterki == id).FirstOrDefault();
                    return Mapper.ModelMapper.Mapper.Map<IFaultModel>(queryResult);
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
                    var queryResult = ctx.Usterki.Where(x => x.id_usterki == id).FirstOrDefault();
                    if (queryResult is null)
                    {
                        return false;
                    }
                    else
                    {
                        ctx.Usterki.Remove(queryResult);
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

        public bool Remove(IFaultModel model)
        {
            return Remove(model.id_usterki);
        }
    }
}
