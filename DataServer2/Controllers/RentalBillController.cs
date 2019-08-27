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

namespace DataServer.Controllers
{
    public class RentalBillController : ApiController
	{
        // GET: api/RentalBill
        public IEnumerable<RentalBillModel> Get()
        {
           return ModelMapper.Mapper.Map<List<IRentalBillModel>, List<RentalBillModel>>(new RentalBillService().GetAll());
        }

        // GET: api/RentalBill/5
        public RentalBillModel Get(int id)
        {
            return ModelMapper.Mapper.Map<RentalBillModel>(new RentalBillService().GetSingle(id));
        }

        // PUT: api/RentalBill/5
        public void Put([FromBody]RentalBillModel value)
        {
            new RentalBillService().AddOrUpdate(value);
        }

        // DELETE: api/RentalBill/5
        public IHttpActionResult Delete(int id)
        {
			bool result = new CompanyService().Remove(id);
			if (result)
				return Ok();
			else
				return Conflict();
		}

        // DELETE: api/RentalBill/5
        public void Delete([FromBody]RentalBillModel value)
        {
            new RentalBillService().Remove(value);
        }
    }
}
