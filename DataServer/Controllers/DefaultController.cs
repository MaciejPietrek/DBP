using DataServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataServer.Controllers
{
    public class DefaultController : ApiController
    {
		public IHttpActionResult Get()
		{
			return Ok(new temp { Temp = 2 });
		}
    }
}
