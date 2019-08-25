using DB.Model.Interfaces;
using DB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Implementation
{
    public class RentalService : IRentalService
    {
        public void AddOrUpdate(IRentalModel model)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var newObject = ctx.Wynajmy.Find(model.Id);

                    if (newObject == null)
                    {
                        newObject = Mapper.ModelMapper.Mapper.Map<Wynajmy>(model);
                        ctx.Wynajmy.Add(newObject);
                    }
                    else
                    {
                        newObject.id_najemcy = model.id_najemcy;
                        newObject.id_mieszkania = model.id_mieszkania;
                        newObject.cena_miesieczna = model.cena_miesieczna;
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

        public List<IRentalModel> GetAll()
        {
            List<IRentalModel> result = new List<IRentalModel>();
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    foreach (var obiekt in ctx.Wynajmy.ToList())
                    {
                        result.Add(Mapper.ModelMapper.Mapper.Map<IRentalModel>(obiekt));
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

        public IRentalModel GetSingle(int id)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var queryResult = ctx.Wynajmy.Where(x => x.id == id).FirstOrDefault();
                    return Mapper.ModelMapper.Mapper.Map<IRentalModel>(queryResult);
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
                    var queryResult = ctx.Wynajmy.Where(x => x.id == id).FirstOrDefault();
                    if (queryResult is null)
                    {
                        return false;
                    }
                    else
                    {
                        ctx.Wynajmy.Remove(queryResult);
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

        public bool Remove(IRentalModel model)
        {
            return Remove(model.Id);
        }
    }
}
