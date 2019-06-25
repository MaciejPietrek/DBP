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
    public class ResidentsController : ApiController
    {
        // GET: api/Residents
        public IEnumerable<ResidentModel> Get()
        {
            var service = new ResidentsService();
            return service.GetAllResidents();
        }

        // GET: api/Residents/5
        public ResidentModel Get(int id)
        {
            var service = new ResidentsService();
            return service.GetSingleResident(id);
        }

        // POST: api/Residents
        public void Post([FromBody]string value)
        {
            return;
        }

        // PUT: api/Residents/5
        public void Put(int id, [FromBody]ResidentModel value)
        {
            var service = new ResidentsService();
            service.AddOrEditResident(value);
        }

        // DELETE: api/Residents/5
        public void Delete(int id)
        {
            var service = new ResidentsService();
            service.RemoveResident(id);
        }
    }
}
