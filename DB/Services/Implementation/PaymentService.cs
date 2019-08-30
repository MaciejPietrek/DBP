using DB.Services.Interfaces;
using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        public void AddOrUpdate(IPaymentModel model)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var newObject = ctx.Platnosci.Find(model.Id);

                    if (newObject == null)
                    {
                        newObject = Mapper.ModelMapper.Mapper.Map<Platnosci>(model);
                        ctx.Platnosci.Add(newObject);
                    }
                    else
                    {
                        newObject.id_wynajmu = model.id_wynajmu;
                        newObject.cena = model.cena;
                        newObject.tytul = model.tytul;
                        newObject.data_platnosci = model.data_platnosci;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }

        public List<IPaymentModel> GetAll()
        {
            List<IPaymentModel> result = new List<IPaymentModel>();
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    foreach (var obiekt in ctx.Platnosci.ToList())
                    {
                        result.Add(Mapper.ModelMapper.Mapper.Map<IPaymentModel>(obiekt));
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

        public IPaymentModel GetSingle(int id)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var queryResult = ctx.Platnosci.Where(x => x.id == id).FirstOrDefault();
                    return Mapper.ModelMapper.Mapper.Map<IPaymentModel>(queryResult);
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
                    var queryResult = ctx.Platnosci.Where(x => x.id == id).FirstOrDefault();
                    if (queryResult is null)
                    {
                        return false;
                    }
                    else
                    {
                        ctx.Platnosci.Remove(queryResult);
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

        public bool Remove(IPaymentModel model)
        {
            return Remove(model.Id);
        }
    }
}
