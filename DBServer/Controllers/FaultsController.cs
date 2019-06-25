using DB.Mappers;
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
    public class FaultsController : ApiController
    {
        // GET: api/Faults
        public IEnumerable<FaultDataModel> Get()
        {
            var service = new FaultService();
            return service.GetAllFaultsData();
        }

        // GET: api/Faults/5
        public FaultDataModel Get(int id)
        {
            var service = new FaultService();
            return service.GetSingleFaultDataModel(id);
        }

        // POST: api/Faults
        public void Post([FromBody]string value)
        {
            return;
        }

        // PUT: api/Faults/5
        public void Put(int id, [FromBody]FaultDataModel value)
        {

            var service = new FaultService();
            var result = new FaultModel()
            {
                id_mieszkania = value.id_mieszkania,
                id_usterki = value.id_usterki,
                opis = value.opis,
                stan = value.stan
            };
            service.AddOrEditFault(result);
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
