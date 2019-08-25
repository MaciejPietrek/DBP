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
    public class RentalController : ApiController
	{
        // GET: api/Rental
        public IEnumerable<RentalModel> Get()
        {
            return ModelMapper.Mapper.Map<List<IRentalModel>, List<RentalModel>>(new RentalService().GetAll());
        }

        // GET: api/Rental/5
        public RentalModel Get(int id)
        {
            return ModelMapper.Mapper.Map<RentalModel>(new RentalService().GetSingle(id));
        }

        // PUT: api/Rental/5
        public void Put([FromBody]RentalModel value)
        {
            new RentalService().AddOrUpdate(value);
        }

        // DELETE: api/Rental/5
        public void Delete(int id)
        {
            new RentalService().Remove(id);
        }

        // DELETE: api/Rental/5
        public void Delete([FromBody]RentalModel value)
        {
            new RentalService().Remove(value);
        }
    }
}
