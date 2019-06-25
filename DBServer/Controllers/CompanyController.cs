using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DB.Model.Implementation;
using DB.Model.Interfaces;
using DB.Services.Implementation;

namespace DBServer.Controllers
{
    public class CompanyController : ApiController
    {
        // GET: api/Company
        public IEnumerable<CompanyModel> Get()
        {
            var service = new CompanyService();
            return service.GetAllCompanies();
        }

        // GET: api/Company/5
        public CompanyModel Get(int id)
        {
            var service = new CompanyService();
            return service.GetSingleCompany(id);
        }

        // POST: api/Company
        public void Post([FromBody]CompanyModel value)
        {
            return;
        }

        // PUT: api/Company/5
        public void Put(int id, [FromBody]CompanyModel value)
        {
            var service = new CompanyService();
            service.AddOrEditCompany(value);
        }

        // DELETE: api/Company/5
        public void Delete(int id)
        { 
            var service = new CompanyService();
            service.RemoveCompany(id);
        }
    }
}
