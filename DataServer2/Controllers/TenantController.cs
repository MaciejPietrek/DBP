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
    public class TenantController : ApiController
	{
        // GET: api/Tenant
        public IEnumerable<TenantModel> Get()
        {
            return ModelMapper.Mapper.Map<List<ITenantModel>, List<TenantModel>>(new TenantService().GetAll());
        }

        // GET: api/Tenant/5
        public TenantModel Get(int id)
        {
            return ModelMapper.Mapper.Map<TenantModel>(new TenantService().GetSingle(id));
        }

        // PUT: api/Tenant/5
        public void Put([FromBody]TenantModel value)
        {
            new TenantService().AddOrUpdate(value);
        }

		// DELETE: api/Tenant/5
		public IHttpActionResult Delete(int id)
		{
			bool result = new TenantService().Remove(id);
			if (result)
				return Ok();
			else
				return Conflict();
		}

		// DELETE: api/Tenant/5
		public void Delete([FromBody]TenantModel value)
        {
            new TenantService().Remove(value);
        }
    }
}
