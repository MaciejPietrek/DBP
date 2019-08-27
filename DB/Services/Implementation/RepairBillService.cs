using DB.Model.Interfaces;
using DB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Implementation
{
    public class RepairBillService : IRepairBillService
    {
        public void AddOrUpdate(IRepairBillModel model)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var newObject = ctx.FakturyNapraw.Find(model.Id);

                    if (newObject == null)
                    {
                        newObject = Mapper.ModelMapper.Mapper.Map<FakturyNapraw>(model);
                        ctx.FakturyNapraw.Add(newObject);
                    }
                    else
                    {
                        newObject.id_naprawy = model.id_naprawy;
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

        public List<IRepairBillModel> GetAll()
        {
            List<IRepairBillModel> result = new List<IRepairBillModel>();
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    foreach (var obiekt in ctx.FakturyNapraw.ToList())
                    {
                        result.Add(Mapper.ModelMapper.Mapper.Map<IRepairBillModel>(obiekt));
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

        public IRepairBillModel GetSingle(int id)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var queryResult = ctx.FakturyNapraw.Where(x => x.id == id).FirstOrDefault();
                    return Mapper.ModelMapper.Mapper.Map<IRepairBillModel>(queryResult);
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
                    var queryResult = ctx.FakturyNapraw.Where(x => x.id == id).FirstOrDefault();
                    if (queryResult is null)
                    {
                        return false;
                    }
                    else
                    {
                        ctx.FakturyNapraw.Remove(queryResult);
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

        public bool Remove(IRepairBillModel model)
        {
            return Remove(model.Id);
        }
    }
}
