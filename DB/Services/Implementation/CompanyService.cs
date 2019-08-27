using DB.Model.Implementation;
using DB.Model.Interfaces;
using DB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        public void AddOrUpdate(ICompanyModel model)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var newObject = ctx.Firmy.Find(model.Id);

                    if (newObject == null)
                    {
                        newObject = Mapper.ModelMapper.Mapper.Map<Firmy>(model);
                        ctx.Firmy.Add(newObject);
                    }
                    else
                    {
                        newObject.nazwa_firmy = newObject.nazwa_firmy;
                        newObject.NIP = newObject.NIP;
                        newObject.nr_telefonu = newObject.nr_telefonu;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }

        public List<ICompanyModel> GetAll()
        {
            List<ICompanyModel> result = new List<ICompanyModel>();
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    foreach (var obiekt in ctx.Firmy.ToList())
                    {
                        result.Add(Mapper.ModelMapper.Mapper.Map<ICompanyModel>(obiekt));
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

        public ICompanyModel GetSingle(int id)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var queryResult = ctx.Firmy.Where(x => x.id == id).FirstOrDefault();
                    return Mapper.ModelMapper.Mapper.Map<ICompanyModel>(queryResult);
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
                    var queryResult = ctx.Firmy.Where(x => x.id == id).FirstOrDefault();
                    if (queryResult is null)
                    {
                        return false;
                    }
                    else
                    {
                        ctx.Firmy.Remove(queryResult);
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

        public bool Remove(ICompanyModel model)
        {
            return Remove(model.Id);
        }
    }
}
