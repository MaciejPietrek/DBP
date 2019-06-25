using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using DB.Model.Implementation;
using DBClient.DataReceivers;

namespace DBClient
{
    class Program
    {
        static void Main(string[] args)
        {
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                foreach (var obj in CompanyDataReceiver.GetCompanyList())
                {
                    Console.WriteLine($"a : {obj.id_firmy,-10} b : {obj.nazwa_firmy,-10} c : {obj.NIP,-10} d : {obj.nr_telefonu,-10}");
                }
                Console.WriteLine(CompanyDataReceiver.RemoveCompany(2));
                foreach (var obj in CompanyDataReceiver.GetCompanyList())
                {
                    Console.WriteLine($"a : {obj.id_firmy,-10} b : {obj.nazwa_firmy,-10} c : {obj.NIP,-10} d : {obj.nr_telefonu,-10}");
                }
            }
            Console.ReadKey();
        }
    }
}
