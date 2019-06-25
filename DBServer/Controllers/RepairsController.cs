using DB.Model.Implementation;
using DB.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DBServer.Controllers
{
    public class RepairsController : ApiController
    {
        // GET: api/Repairs
        public IEnumerable<RepairModel> Get(int id)
        {
            var service = new RepairsService();
            return service.GetAllRepairsById(id);
        }

        // POST: api/Repairs
        public void Post([FromBody]string value)
        {
            return;
        }

        // PUT: api/Repairs/5
        public void Put(int id, [FromBody]RepairModel value)
        {
            var service = new RepairsService();
            service.AddOrEditRepair(value);
        }

        // DELETE: api/Repairs/5
        public void Delete(int id)
        {
            var service = new RepairsService();
            service.RemoveRepair(id);
        }
    }
}
