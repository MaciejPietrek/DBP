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

namespace DBServer.Controllers
{
    public class FaultController : DBServerApiController
    {
        // GET: api/Fault
        public IEnumerable<FaultModel> Get()
        {

            var i = ModelMapper.Mapper.Map<List<IFaultModel>, List<FaultModel>>(new FaultService().GetAll());
            Logger.Add(i).Flush(); return i;
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
        public void Delete(int id)
        {
            new FaultService().Remove(id);
        }

        // DELETE: api/Fault/5
        public void Delete([FromBody]FaultModel value)
        {
            new FaultService().Remove(value);
        }
    }
}
