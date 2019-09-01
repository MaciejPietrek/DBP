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
	public class LatePaymentController : ApiController
    {
        // GET: api/LatePayment
        public IEnumerable<LatePaymentModel> Get()
        {
            return ModelMapper.Mapper.Map<List<ILatePaymentModel>, List<LatePaymentModel>>(new LatePaymentService().GetAll());
        }

        // GET: api/LatePayment/5
        public LatePaymentModel Get(int id)
        {
            return ModelMapper.Mapper.Map<LatePaymentModel>(new LatePaymentService().GetSingle(id));
        }

        // PUT: api/LatePayment/5
        public void Put([FromBody]LatePaymentModel value)
        {
            new LatePaymentService().AddOrUpdate(value);
        }

        // DELETE: api/LatePayment/5
        public IHttpActionResult Delete(int id)
        {
            bool result = new LatePaymentService().Remove(id);
            if (result)
                return Ok();
            else
                return Conflict();
        }

        // DELETE: api/LatePayment/5
        public void Delete([FromBody]LatePaymentModel value)
        {
            new LatePaymentService().Remove(value);
        }
    }
}