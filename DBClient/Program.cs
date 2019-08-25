using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using DBClient.DataRecievers;
using System.Runtime.Serialization;

namespace DBClient
{
    class Program
    {
		static void Main(string[] args)
		{
			Program program = new Program();
			program.XD().Wait();
        }

		public async Task XD()
		{
			System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;
			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri("http://localhost:5000/");

			object loginData = new { grant_type = "password", username = "admin", password = "P@ssw0rd" };

			HttpContent content = new FormUrlEncodedContent(new Dictionary<string, string>()
			{
				{"grant_type", "password" },
				{ "username", "admin" },
				{ "password", "P@ssw0rd"}
			});
			try
			{
				using (HttpResponseMessage responseMessage = await httpClient.PostAsync("Token", content))
				{
					using (HttpContent ct = responseMessage.Content)
					{
						string result = await ct.ReadAsStringAsync();
					}
				}
			}
			catch (Exception x)
			{

			}

			object accountData = new { Email = "admin@zarzad.pl", Username = "admin", Password = "P@ssw0rd", ConfirmPassword = "P@ssw0rd" };
			try
			{
				using (HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("api/Account/Register", accountData))
				{
					using (HttpContent ct = responseMessage.Content)
					{
						string result = await ct.ReadAsStringAsync();
					}
				}
			}
			catch(Exception x)
			{

			}
		}
    }
}
