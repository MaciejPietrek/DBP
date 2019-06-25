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
    public class ResidencesController : ApiController
    {
        // GET: api/Faults
        public IEnumerable<ResidenceModel> Get(int BuildingID)
        {
            var service = new ResidencesService();
            return service.GetResidencesById(BuildingID);
        }

        // PUT: api/Faults/5
        public void Put(int id, [FromBody]ResidenceModel value)
        {

            var service = new ResidencesService();
            service.AddOrEditResidence(value);
        }

        public void Put(int id, [FromBody]FaultModel value)
        {
            var service = new FaultService();
            service.AddOrEditFault(value);
        }

        // DELETE: api/Faults/5
        public void Delete(int id)
        {
            var service = new FaultService();
            service.RemoveFault(id);
        }
    }
}
