using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DBClient.DataRecievers
{
    class Connector
    {
        public static string Result { get; set; }

        public async static Task Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = await client.GetAsync(url).ConfigureAwait(false))
                {
                    using (HttpContent content = responseMessage.Content)
                    {
                        Result = await content.ReadAsStringAsync();
                    }
                }
            }
        }

        public async static Task Del(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = await client.DeleteAsync(url))
                {
                    using (HttpContent content = responseMessage.Content)
                    {
                        Result = await content.ReadAsStringAsync();
                    }
                }
            }
        }

        public async static Task Upd(string url, object PostContent)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, PostContent))
                {
                    using (HttpContent content = responseMessage.Content)
                    {
                        Result = await content.ReadAsStringAsync();
                    }
                }
            }
        }
    }
}
