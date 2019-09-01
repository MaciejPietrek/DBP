using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DB.Mapper;
using DB.Model.Implementation;
using DB.Model.Interfaces;
using DB.Services.Implementation;

namespace DataServer.Controllers
{
	[Authorize()]
	public class PaymentController : ApiController
    {

        // GET: api/Payment
        public IEnumerable<PaymentModel> Get()
        {
            return ModelMapper.Mapper.Map<List<IPaymentModel>, List<PaymentModel>>(new PaymentService().GetAll());
        }

        // GET: api/Payment/5
        public PaymentModel Get(int id)
        {
            return ModelMapper.Mapper.Map<PaymentModel>(new PaymentService().GetSingle(id));
        }

        // PUT: api/Payment/5
        public void Put([FromBody]PaymentModel value)
        {
            new PaymentService().AddOrUpdate(value);
        }

        // DELETE: api/Payment/5
        public IHttpActionResult Delete(int id)
        {
            bool result = new PaymentService().Remove(id);
            if (result)
                return Ok();
            else
                return Conflict();
        }

        // DELETE: api/Payment/5
        public void Delete([FromBody]PaymentModel value)
        {
            new PaymentService().Remove(value);
        }
    }
}