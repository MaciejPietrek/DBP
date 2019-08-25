using DB.Model.Interfaces;
using DB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Implementation
{
    public class RentalBillService : IRentalBillService
    {
        public void AddOrUpdate(IRentalBillModel model)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var newObject = ctx.FakturyWynajem.Find(model.Id);

                    if (newObject == null)
                    {
                        newObject = Mapper.ModelMapper.Mapper.Map<FakturyWynajem>(model);
                        ctx.FakturyWynajem.Add(newObject);
                    }
                    else
                    {
                        newObject.id_wynajem = model.id_wynajem;
                        newObject.numer_faktury = model.numer_faktury;
                        newObject.data_platnosci = model.data_platnosci;
                        newObject.cena = model.cena;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }

        public List<IRentalBillModel> GetAll()
        {
            List<IRentalBillModel> result = new List<IRentalBillModel>();
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    foreach (var obiekt in ctx.FakturyWynajem.ToList())
                    {
                        result.Add(Mapper.ModelMapper.Mapper.Map<IRentalBillModel>(obiekt));
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

        public IRentalBillModel GetSingle(int id)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var queryResult = ctx.FakturyWynajem.Where(x => x.id == id).FirstOrDefault();
                    return Mapper.ModelMapper.Mapper.Map<IRentalBillModel>(queryResult);
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
                    var queryResult = ctx.FakturyWynajem.Where(x => x.id == id).FirstOrDefault();
                    if (queryResult is null)
                    {
                        return false;
                    }
                    else
                    {
                        ctx.FakturyWynajem.Remove(queryResult);
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

        public bool Remove(IRentalBillModel model)
        {
            return Remove(model.Id);
        }
    }
}
