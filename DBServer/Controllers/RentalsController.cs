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
    public class RentalsController : ApiController
    {
        // GET: api/Company
        public IEnumerable<RentalDataModel> Get()
        {
            var service = new RentalService();
            return service.GetAllRentals();
        }

        // GET: api/Company/5
        public RentalDataModel Get(int id)
        {
            var service = new RentalService();
            return service.GetSingleRentalDataModel(id);
        }

        // POST: api/Company
        public void Post([FromBody]RentalDataModel value)
        {
            return;
        }

        // PUT: api/Company/5
        public void Put(int id, [FromBody]RentalDataModel value)
        {
            var service = new RentalService();
            var result = new StrictRentalDataModel()
            {
                cena_miesieczna = value.cena_miesieczna,
                data_rozpoczecia = value.data_rozpoczecia,
                data_zakonczenia = value.data_zakonczenia,
                id_mieszkania = value.id_mieszkania,
                id_najemcy = value.id_najemcy,
                id_wynajmu = value.id_wynajmu
            };
            service.AddOrEditRental(result);
        }

        public void Put(int id, [FromBody]StrictRentalDataModel value)
        {
            var service = new RentalService();
            service.AddOrEditRental(value);
        }

        // DELETE: api/Company/5
        public void Delete(int id)
        {
            var service = new RentalService();
            service.RemoveRental(id);
        }
    }
}
