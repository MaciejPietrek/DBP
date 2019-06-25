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
    public class RepairBillController : ApiController
    {
        // GET: api/RepairBill
        public IEnumerable<RepairBillModel> Get(int id)
        {
            var service = new RepairBillService();
            return service.GetAllRepairBillsById(id);
        }

        // POST: api/RepairBill
        public void Post([FromBody]string value)
        {
            return;
        }

        // PUT: api/RepairBill/5
        public void Put(int id, [FromBody]RepairBillModel value)
        {
            var service = new RepairBillService();
            service.AddOrEditRepairBill(value);
        }

        // DELETE: api/RepairBill/5
        public void Delete(int id)
        {
            var service = new RepairBillService();
            service.RemoveRepairBill(id);
        }
    }
}
