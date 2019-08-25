using DB.Model.Interfaces;
using DB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Implementation;

namespace DB.Services.Implementation
{
    public class BuildingService : IBuildingService
    {
        public void AddOrUpdate(IBuildingModel model)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var newObject = ctx.Budynki.Find(model.Id);

                    if (newObject == null)
                    {
                        newObject = Mapper.ModelMapper.Mapper.Map<Budynki>(model);
                        ctx.Budynki.Add(newObject);
                    }
                    else
                    {
                        newObject.adres_budynku = model.adres_budynku;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }

        public List<IBuildingModel> GetAll()
        {
            List<IBuildingModel> result = new List<IBuildingModel>();
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    foreach(var obiekt in ctx.Budynki.ToList())
                    {
                        result.Add(Mapper.ModelMapper.Mapper.Map<IBuildingModel>(obiekt));
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

        public IBuildingModel GetSingle(int id)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var queryResult = ctx.Budynki.Where(x => x.id == id).FirstOrDefault();
                    return Mapper.ModelMapper.Mapper.Map<IBuildingModel>(queryResult);
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
                    var queryResult = ctx.Budynki.Where(x => x.id == id).FirstOrDefault();
                    if(queryResult is null)
                    {
                        return false;
                    }
                    else
                    {
                        ctx.Budynki.Remove(queryResult);
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

        public bool Remove(IBuildingModel model)
        {
            return Remove(model.Id);
        }
    }
}
