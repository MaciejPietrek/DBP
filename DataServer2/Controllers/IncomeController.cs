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
    public class IncomeController : ApiController
    {
        // GET: api/Income
        public IEnumerable<IncomeModel> Get()
        {
            return ModelMapper.Mapper.Map<List<IIncomeModel>, List<IncomeModel>>(new IncomeService().GetAll());
        }

        // GET: api/Income/5
        public IncomeModel Get(int id)
        {
            return ModelMapper.Mapper.Map<IncomeModel>(new IncomeService().GetSingle(id));
        }

        // PUT: api/Income/5
        public void Put([FromBody]IncomeModel value)
        {
            new IncomeService().AddOrUpdate(value);
        }

        // DELETE: api/Income/5
        public IHttpActionResult Delete(int id)
        {
            bool result = new IncomeService().Remove(id);
            if (result)
                return Ok();
            else
                return Conflict();
        }

        // DELETE: api/Income/5
        public void Delete([FromBody]IncomeModel value)
        {
            new IncomeService().Remove(value);
        }
    }
}