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
    public class RepairBillController : ApiController
	{
        // GET: api/RepairBill
        public IEnumerable<RepairBillModel> Get()
        {
            return ModelMapper.Mapper.Map<List<IRepairBillModel>, List<RepairBillModel>>(new RepairBillService().GetAll());
        }

        // GET: api/RepairBill/5
        public RepairBillModel Get(int id)
        {
            return ModelMapper.Mapper.Map<RepairBillModel>(new RepairBillService().GetSingle(id));
        }

        // PUT: api/RepairBill/5
        public void Put([FromBody]RepairBillModel value)
        {
            new RepairBillService().AddOrUpdate(value);
        }

		// DELETE: api/RepairBill/5
		public IHttpActionResult Delete(int id)
		{
			bool result = new RepairBillService().Remove(id);
			if (result)
				return Ok();
			else
				return Conflict();
		}

		// DELETE: api/RepairBill/5
		public void Delete([FromBody]RepairBillModel value)
        {
            new RepairBillService().Remove(value);
        }
    }
}
