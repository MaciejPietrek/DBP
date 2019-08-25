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
    public class SupervisorController : ApiController
	{
        // GET: api/Supervisor
        public IEnumerable<SupervisorModel> Get()
        {
            return ModelMapper.Mapper.Map<List<ISupervisorModel>, List<SupervisorModel>>(new SupervisorService().GetAll());
        }

        // GET: api/Supervisor/5
        public SupervisorModel Get(int id)
        {
            return ModelMapper.Mapper.Map<SupervisorModel>(new SupervisorService().GetSingle(id));
        }

        // PUT: api/Supervisor/5
        public void Put([FromBody]SupervisorModel value)
        {
            new SupervisorService().AddOrUpdate(value);
        }

		// DELETE: api/Supervisor/5
		public IHttpActionResult Delete(int id)
		{
			bool result = new SupervisorService().Remove(id);
			if (result)
				return Ok();
			else
				return Conflict();
		}

		// DELETE: api/Supervisor/5
		public void Delete([FromBody]SupervisorModel value)
        {
            new SupervisorService().Remove(value);
        }
    }
}
