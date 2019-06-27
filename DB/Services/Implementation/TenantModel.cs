using DB.Model.Interfaces;
using DB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Implementation
{
    public class TenantService : ITenantService
    {
        public void AddOrUpdate(ITenantModel model)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var newObject = ctx.Najemcy.Find(model.id_najemcy);

                    if (newObject == null)
                    {
                        newObject = Mapper.ModelMapper.Mapper.Map<Najemcy>(model);
                        ctx.Najemcy.Add(newObject);
                    }
                    else
                    {
                        newObject.imie = model.imie;
                        newObject.nazwisko = model.nazwisko;
                        newObject.nr_telefonu = model.nr_telefonu;
                        newObject.PESEL = model.PESEL;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }

        public List<ITenantModel> GetAll()
        {
            List<ITenantModel> result = new List<ITenantModel>();
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    foreach (var obiekt in ctx.Najemcy.ToList())
                    {
                        result.Add(Mapper.ModelMapper.Mapper.Map<ITenantModel>(obiekt));
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

        public ITenantModel GetSingle(int id)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var queryResult = ctx.Najemcy.Where(x => x.id_najemcy == id).FirstOrDefault();
                    return Mapper.ModelMapper.Mapper.Map<ITenantModel>(queryResult);
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
                    var queryResult = ctx.Najemcy.Where(x => x.id_najemcy == id).FirstOrDefault();
                    if (queryResult is null)
                    {
                        return false;
                    }
                    else
                    {
                        ctx.Najemcy.Remove(queryResult);
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

        public bool Remove(ITenantModel model)
        {
            return Remove(model.id_najemcy);
        }
    }
}
