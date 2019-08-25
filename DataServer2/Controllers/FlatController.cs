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
    public class FlatController : ApiController
	{
        // GET: api/Flat
        public IEnumerable<FlatModel> Get()
        {
           return ModelMapper.Mapper.Map<List<IFlatModel>, List<FlatModel>>(new FlatService().GetAll());
        }

        // GET: api/Flat/5
        public FlatModel Get(int id)
        {
            return ModelMapper.Mapper.Map<FlatModel>(new FlatService().GetSingle(id));
        }

        // PUT: api/Flat/5
        public void Put([FromBody]FlatModel value)
        {
            new FlatService().AddOrUpdate(value);
        }

        // DELETE: api/Flat/5
        public void Delete(int id)
        {
            new FlatService().Remove(id);
        }

        // DELETE: api/Flat/5
        public void Delete([FromBody]FlatModel value)
        {
            new FlatService().Remove(value);
        }
    }
}
