﻿using DB.Mapper;
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
	public class SupervisingController : ApiController
	{
        // GET: api/Supervising
        public IEnumerable<SupervisingModel> Get()
        {
            return ModelMapper.Mapper.Map<List<ISupervisingModel>, List<SupervisingModel>>(new SupervisingService().GetAll());
        }

        // GET: api/Supervising/5
        public SupervisingModel Get(int id_d, int id_b)
        {
            return ModelMapper.Mapper.Map<SupervisingModel>(new SupervisingService().GetSingle(id_d, id_b));
        }

        // PUT: api/Supervising/5
        public void Put([FromBody]SupervisingModel value)
        {
            new SupervisingService().AddOrUpdate(value);
        }

		// DELETE: api/Supervising/5
		public IHttpActionResult Delete(int id)
		{
			bool result = new SupervisingService().Remove(id);
			if (result)
				return Ok();
			else
				return Conflict();
		}

		// DELETE: api/Supervising/5
		public void Delete([FromBody]SupervisingModel value)
        {
            new SupervisingService().Remove(value);
        }
    }
}
