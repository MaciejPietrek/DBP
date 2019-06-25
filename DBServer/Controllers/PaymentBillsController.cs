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
    public class PaymentBillsController : ApiController
    {
        // GET: api/Company
        public IEnumerable<PaymentBillModel> Get(int id)
        {
            var service = new RentalService();
            return service.GetAllPaymentBillsById(id);
        }

        // POST: api/Company
        public void Post([FromBody]PaymentBillModel value)
        {
            return;
        }

        // PUT: api/Company/5
        public void Put(int id, [FromBody]PaymentBillModel value)
        {
            var service = new RentalService();
            service.AddOrEditPaymentBill(value);
        }

        // DELETE: api/Company/5
        public void Delete(int id)
        {
            var service = new RentalService();
            service.RemovePaymentBill(id);
        }
    }
}
