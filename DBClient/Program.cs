using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using DBClient.DataRecievers;
using DB.Model.Implementation;

namespace DBClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();

            BuildingDataReceiver som = new BuildingDataReceiver();

            var a = new BuildingModel()
            {
                adres_budynku = "Siemianowicka 100",
                id_budynku = 10001
            };
            Console.ReadKey();

        }
    }
}
