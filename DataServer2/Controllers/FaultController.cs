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
    public class FaultController : ApiController
	{
        // GET: api/Fault
        public IEnumerable<FaultModel> Get()
        {
           return ModelMapper.Mapper.Map<List<IFaultModel>, List<FaultModel>>(new FaultService().GetAll());
        }

        // GET: api/Fault/5
        public FaultModel Get(int id)
        {
            return ModelMapper.Mapper.Map<FaultModel>(new FaultService().GetSingle(id));
        }

        // PUT: api/Fault/5
        public void Put([FromBody]FaultModel value)
        {
            new FaultService().AddOrUpdate(value);
        }

		// DELETE: api/Fault/5
		public IHttpActionResult Delete(int id)
		{
			bool result = new FaultService().Remove(id);
			if (result)
				return Ok();
			else
				return Conflict();
		}

		// DELETE: api/Fault/5
		public void Delete([FromBody]FaultModel value)
        {
            new FaultService().Remove(value);
        }
    }
}
