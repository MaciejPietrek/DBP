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

namespace DBServer.Controllers
{
    public class TenantController : DBServerApiController
    {
        // GET: api/Tenant
        public IEnumerable<TenantModel> Get()
        {

            var i = ModelMapper.Mapper.Map<List<ITenantModel>, List<TenantModel>>(new TenantService().GetAll());
            Logger.Add(i).Flush(); return i;
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
        public void Delete(int id)
        {
            new TenantService().Remove(id);
        }

        // DELETE: api/Tenant/5
        public void Delete([FromBody]TenantModel value)
        {
            new TenantService().Remove(value);
        }
    }
}
