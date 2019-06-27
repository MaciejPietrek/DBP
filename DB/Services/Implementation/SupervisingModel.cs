using DB.Model.Interfaces;
using DB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Implementation
{
    public class SupervisingService : ISupervisingService
    {
        public void AddOrUpdate(ISupervisingModel model)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var newObject = ctx.Dozorowania.Where(x => x.id_budynku == model.id_budynku && x.id_dozorcy == model.id_dozorcy).FirstOrDefault();

                    if (newObject == null)
                    {
                        newObject = Mapper.ModelMapper.Mapper.Map<Dozorowania>(model);
                        ctx.Dozorowania.Add(newObject);
                    }
                    else
                    {
                        newObject.data_rozpoczecia = model.data_rozpoczecia;
                        newObject.data_zakonczenia = model.data_zakonczenia;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }

        public List<ISupervisingModel> GetAll()
        {
            List<ISupervisingModel> result = new List<ISupervisingModel>();
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    foreach (var obiekt in ctx.Dozorowania.ToList())
                    {
                        result.Add(Mapper.ModelMapper.Mapper.Map<ISupervisingModel>(obiekt));
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

        [Obsolete("GetSingle(int id) deprecated, please use GetSingle(int id_dozorcy, int id_budynku) instead.")]
        public ISupervisingModel GetSingle(int id) => null;

        public ISupervisingModel GetSingle(int id_dozorcy, int id_budynku)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var queryResult = ctx.
                        Dozorowania.
                        Where(x => x.id_budynku == id_budynku && x.id_dozorcy == id_dozorcy).
                        FirstOrDefault();
                    return Mapper.ModelMapper.Mapper.Map<ISupervisingModel>(queryResult);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return null;
            }
        }

        [Obsolete("Remove(int id) deprecated, please use Remove(int id_dozorcy, int id_budynku) or Remove(ISupervisingModel model) instead.")]
        public bool Remove(int id) => false;

        public bool Remove(int id_dozorcy, int id_budynku)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var queryResult = ctx.
                        Dozorowania.
                        Where(x => x.id_budynku == id_budynku && x.id_dozorcy == id_dozorcy).
                        FirstOrDefault();
                    if (queryResult is null)
                    {
                        return false;
                    }
                    else
                    {
                        ctx.Dozorowania.Remove(queryResult);
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

        public bool Remove(ISupervisingModel model)
        {
            return Remove(model.id_dozorcy, model.id_budynku);
        }
    }
}
