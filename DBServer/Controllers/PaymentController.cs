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
    public class PaymentController : ApiController
    {
        // GET: api/Company
        public IEnumerable<PaymentModel> Get(int id)
        {
            var service = new RentalService();
            return service.GetAllPaymentsById(id);
        }

        // POST: api/Company
        public void Post([FromBody]PaymentModel value)
        {
            return;
        }

        // PUT: api/Company/5
        public void Put(int id, [FromBody]PaymentModel value)
        {
            var service = new RentalService();
            service.AddOrEditPayment(value);
        }

        // DELETE: api/Company/5
        public void Delete(int id)
        {
            var service = new RentalService();
            service.RemovePayment(id);
        }
    }
}
