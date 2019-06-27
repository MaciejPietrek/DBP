using DB.Model.Interfaces;
using DB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Implementation
{
    public class FlatService : IFlatService
    {
        public void AddOrUpdate(IFlatModel model)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var newObject = ctx.Mieszkania.Find(model.id_mieszkania);

                    if (newObject == null)
                    {
                        newObject = Mapper.ModelMapper.Mapper.Map<Mieszkania>(model);
                        ctx.Mieszkania.Add(newObject);
                    }
                    else
                    {
                        newObject.id_budynku = model.id_budynku;
                        newObject.metraz = model.metraz;
                        newObject.numer = model.numer;
                        newObject.opis = model.opis;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }

        public List<IFlatModel> GetAll()
        {
            List<IFlatModel> result = new List<IFlatModel>();
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    foreach (var obiekt in ctx.Mieszkania.ToList())
                    {
                        result.Add(Mapper.ModelMapper.Mapper.Map<IFlatModel>(obiekt));
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

        public IFlatModel GetSingle(int id)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var queryResult = ctx.Mieszkania.Where(x => x.id_mieszkania == id).FirstOrDefault();
                    return Mapper.ModelMapper.Mapper.Map<IFlatModel>(queryResult);
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
                    var queryResult = ctx.Mieszkania.Where(x => x.id_mieszkania == id).FirstOrDefault();
                    if (queryResult is null)
                    {
                        return false;
                    }
                    else
                    {
                        ctx.Mieszkania.Remove(queryResult);
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

        public bool Remove(IFlatModel model)
        {
            return Remove(model.id_mieszkania);
        }
    }
}
