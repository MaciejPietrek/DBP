using DB.Mapper;
using DB.Model.Implementation;
using DB.Model.Interfaces;
using DB.Services.Implementation;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http;

namespace DataServer.Controllers
{
	[Authorize()]
	public class CurrentRepairController : ApiController
    {
        // GET: api/CurrentRepair
        public IEnumerable<CurrentRepairModel> Get()
        {
            return ModelMapper.Mapper.Map<List<ICurrentRepairModel>, List<CurrentRepairModel>>(new CurrentRepairService().GetAll());
        }

        // GET: api/CurrentRepair/5
        public CurrentRepairModel Get(int id)
        {
            return ModelMapper.Mapper.Map<CurrentRepairModel>(new CurrentRepairService().GetSingle(id));
        }

        // PUT: api/CurrentRepair/5
        public void Put([FromBody]CurrentRepairModel value)
        {
            new CurrentRepairService().AddOrUpdate(value);
        }

        // DELETE: api/CurrentRepair/5
        public IHttpActionResult Delete(int id)
        {
            bool result = new CurrentRepairService().Remove(id);
            if (result)
                return Ok();
            else
                return Conflict();
        }

        // DELETE: api/CurrentRepair/5
        public void Delete([FromBody]CurrentRepairModel value)
        {
            new CurrentRepairService().Remove(value);
        }
    }
}