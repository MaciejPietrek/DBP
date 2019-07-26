using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DBServer.Controllers
{
    public class DBServerApiController : ApiController
    {
        static protected FileLogger.Logger Logger { get; set; } = FileLogger.Logger.GetInstance("C:\\Users\\Maciek\\Desktop\\Data_Controllers_DBServer_LOG.json");
    }
}