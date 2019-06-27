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
    public class RentalBillController : ApiController
    {
        // GET: api/RentalBill
        public IEnumerable<RentalBillModel> Get()
        {

            var i = ModelMapper.Mapper.Map<List<IRentalBillModel>, List<RentalBillModel>>(new RentalBillService().GetAll());
            return i;
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
        public void Delete(int id)
        {
            new RentalBillService().Remove(id);
        }

        // DELETE: api/RentalBill/5
        public void Delete([FromBody]RentalBillModel value)
        {
            new RentalBillService().Remove(value);
        }
    }
}
