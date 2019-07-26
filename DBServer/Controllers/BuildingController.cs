﻿using DB.Mapper;
using DB.Model.Implementation;
using DB.Model.Interfaces;
using DB.Services.Implementation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DBServer.Controllers
{
    public class BuildingController : DBServerApiController
    {
        // GET: api/Building
        public IEnumerable<BuildingModel> Get()
        {
            var i = ModelMapper.Mapper.Map<List<IBuildingModel>, List<BuildingModel>>(new BuildingService().GetAll());
            Logger.Add(i).Flush(); return i;
        }

        // GET: api/Building/5
        public BuildingModel Get(int id)
        {
            return ModelMapper.Mapper.Map<BuildingModel>(new BuildingService().GetSingle(id));
        }

        // PUT: api/Building/5
        public void Post([FromBody]BuildingModel value)
        {
            new BuildingService().AddOrUpdate(value);
        }

        // DELETE: api/Building/5
        public void Delete(int id)
        {
            new BuildingService().Remove(id);
        }

        // DELETE: api/Building/5
        public void Delete([FromBody]BuildingModel value)
        {
            new BuildingService().Remove(value);
        }
    }
}
