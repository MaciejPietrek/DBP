using DB.Mapper;
using DB.Model.Implementation;
using DB.Model.Interfaces;
using DB.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataServer.Controllers
{
	[Authorize()]
	public class CompanyController : ApiController
	{
        // GET: api/Company
        public IEnumerable<CompanyModel> Get()
        {
            return ModelMapper.Mapper.Map<List<ICompanyModel>, List<CompanyModel>>(new CompanyService().GetAll());
        }

        // GET: api/Company/5
        public CompanyModel Get(int id)
        {
            return ModelMapper.Mapper.Map<CompanyModel>(new CompanyService().GetSingle(id));
        }

        // PUT: api/Company/5
        public void Put([FromBody]CompanyModel value)
        {
            new CompanyService().AddOrUpdate(value);
        }

        // DELETE: api/Company/5
        public IHttpActionResult Delete(int id)
        {
			bool result = new CompanyService().Remove(id);
			if (result)
				return Ok();
			else
				return Conflict();
		}

        // DELETE: api/Company/5
        public void Delete([FromBody]CompanyModel value)
        {
            new CompanyService().Remove(value);
        }
    }
}
