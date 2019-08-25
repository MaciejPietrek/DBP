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
    public class RepairController : DBServerApiController
    {
        // GET: api/Repair
        public IEnumerable<RepairModel> Get()
        {

            var i = ModelMapper.Mapper.Map<List<IRepairModel>, List<RepairModel>>(new RepairService().GetAll());
            Logger.Add(i).Flush(); return i;
        }

        // GET: api/Repair/5
        public RepairModel Get(int id)
        {
            return ModelMapper.Mapper.Map<RepairModel>(new RepairService().GetSingle(id));
        }

        // PUT: api/Repair/5
        public void Put([FromBody]RepairModel value)
        {
            new RepairService().AddOrUpdate(value);
        }

        // DELETE: api/Repair/5
        public void Delete(int id)
        {
            new RepairService().Remove(id);
        }

        // DELETE: api/Repair/5
        public void Delete([FromBody]RepairModel value)
        {
            new RepairService().Remove(value);
        }
    }
}
