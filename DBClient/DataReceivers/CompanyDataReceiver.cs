using DB.Model.Implementation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DBClient.DataReceivers
{
    static class CompanyDataReceiver
    {
        //static string getResult;

        //private async static Task Get(string url)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        using (HttpResponseMessage responseMessage = await client.GetAsync(url))
        //        {
        //            using (HttpContent content = responseMessage.Content)
        //            {
        //                getResult = await content.ReadAsStringAsync();
        //            }
        //        }
        //    }
        //}

        //private async static Task Del(string url)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        using (HttpResponseMessage responseMessage = await client.DeleteAsync(url))
        //        {
        //            using (HttpContent content = responseMessage.Content)
        //            {
        //                getResult = await content.ReadAsStringAsync();
        //            }
        //            Console.WriteLine(responseMessage.StatusCode);
        //        }
        //    }
        //}

        //public static List<CompanyModel> GetCompanyList()
        //{
        //    Get("http://localhost:51950/api/Company").Wait();

        //    var result = JsonConvert.DeserializeObject<List<CompanyModel>>(getResult);

        //    return result;
        //}

        //public static CompanyModel GetCompany(int id)
        //{
        //    Get("http://localhost:51950/api/Company/" + id.ToString()).Wait();

        //    var result = JsonConvert.DeserializeObject<CompanyModel>(getResult);

        //    return result;
        //}

        //public static string RemoveCompany(int id)
        //{
        //    Del("http://localhost:51950/api/Company/Delete?id=" + id.ToString()).Wait();

        //    return getResult;
        //}
    }
}
