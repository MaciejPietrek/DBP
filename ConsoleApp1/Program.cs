using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ConsoleApp1
{
	class Program
	{
		static async void Main(string[] args)
		{
			System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;
			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri("https://localhost:5000/");
			object accountData = new { Email = "abc@def.gh", Password = "ab", ConfirmPassword = "ab" };
			HttpContent httpContent = new HttpContent();
			httpContent.
			HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync("api/Account/Register", accountData);
		}
	}
}
