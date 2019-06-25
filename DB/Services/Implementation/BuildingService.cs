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
    class BuildingService : IBuildingService
    { 
        private BuildingModel BudynkiToBuilding(Budynki x)
        {
            return new BuildingModel()
            {
                id_budynku = x.id_budynku,
                adres_budynku = x.adres_budynku
            };
        }

        private Budynki BuildingToBudynki(BuildingModel x)
        {
            return new Budynki()
            {
                id_budynku = x.id_budynku,
                adres_budynku = x.adres_budynku
            };
        }

        public void AddOrUpdate(IDBModel model)
        {
            var cModel = (CompanyModel)model;
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var company = ctx.Firmy.Find(cModel.id_firmy);

                    if (company == null)
                    {
                        company = CompanyToFirma(cModel);
                        ctx.Firmy.Add(company);
                    }
                    else
                    {
                        company.NIP = cModel.NIP;
                        company.nr_telefonu = cModel.nr_telefonu;
                        company.nazwa_firmy = cModel.nazwa_firmy;
                    }

                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                new Logger(ex.Message);
            }
        }

        public List<IDBModel> GetAll()
        {
            var queryResult = new List<IDBModel>();
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var companies = ctx.Firmy.AsQueryable();

                    foreach (var company in companies)
                    {
                        queryResult.Add(FirmaToCompany(company));
                    }
                }
            }
            catch (Exception ex)
            {
                new Logger(ex.Message);
            }
            return queryResult;
        }

        public IDBModel GetSingle(int id)
        {
            CompanyModel company;
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var firma = ctx.Firmy.Find(id);
                    company = FirmaToCompany(firma);
                }
            }
            catch (Exception ex)
            {
                new Logger(ex.Message);
                return null;
            }
            
            return company;
        }

        public bool Remove(int id)
        {
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var result = ctx.Firmy.Find(id);
                    if (result != null)
                    {
                        ctx.Firmy.Remove(result);
                    }

                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                new Logger(ex.Message);
                return false;
            }
        }

        public bool Remove(IDBModel model)
        {
            var cModel = (CompanyModel)model;
            try
            {
                using (var ctx = new DBProjectEntities())
                {
                    var result = ctx.Firmy.Find(cModel.id_firmy);
                    if (result != null)
                    {
                        ctx.Firmy.Remove(result);
                    }

                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                new Logger(ex.Message);
                return false;
            }
        }
    }
}
