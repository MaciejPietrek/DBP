using DB.Model.Interfaces;
using DB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Implementation
{
    public class SupervisorService : ISupervisorService
    {
        public void AddOrUpdate(ISupervisorModel model)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var newObject = ctx.Dozorcy.Find(model.Id);

                    if (newObject == null)
                    {
                        newObject = Mapper.ModelMapper.Mapper.Map<Dozorcy>(model);
                        ctx.Dozorcy.Add(newObject);
                    }
                    else
                    {
                        newObject.Imie = model.Imie;
                        newObject.Nazwisko = model.Nazwisko;
                        newObject.PESEL = model.PESEL;
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

        public List<ISupervisorModel> GetAll()
        {
            List<ISupervisorModel> result = new List<ISupervisorModel>();
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    foreach (var obiekt in ctx.Dozorcy.ToList())
                    {
                        result.Add(Mapper.ModelMapper.Mapper.Map<ISupervisorModel>(obiekt));
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

        public ISupervisorModel GetSingle(int id)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var queryResult = ctx.Dozorcy.Where(x => x.id == id).FirstOrDefault();
                    return Mapper.ModelMapper.Mapper.Map<ISupervisorModel>(queryResult);
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
                    var queryResult = ctx.Dozorcy.Where(x => x.id == id).FirstOrDefault();
                    if (queryResult is null)
                    {
                        return false;
                    }
                    else
                    {
                        ctx.Dozorcy.Remove(queryResult);
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

        public bool Remove(ISupervisorModel model)
        {
            return Remove(model.Id);
        }
    }
}
