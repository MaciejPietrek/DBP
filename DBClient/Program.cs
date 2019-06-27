using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using DBClient.DataReceivers;

namespace DBClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var som = new DB.Services.Implementation.FaultService();
            var son = som.GetAll();

            foreach (var building in son)
            {
                Console.WriteLine($"1: {building.id_mieszkania} 2: {building.id_usterki}");
            }

            Console.WriteLine();
            Console.WriteLine();

            var b = som.GetSingle(2);

            Console.WriteLine($"1: {b.id_mieszkania} 2: {b.id_usterki}");

            var aa = new DB.Services.Implementation.SupervisingService();

            Console.ReadKey();
        }
    }
}
