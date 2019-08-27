using Frontend.Misc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.DataRecievers
{
    class HttpConnector : ErrorStoreFunctionality
    {
		HttpClient _httpClient = null;
		static HttpConnector _instance = new HttpConnector();
		

		private HttpConnector()
		{
			_httpClient = new HttpClient
			{
				BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings.Get("remoteAddress"))
			};
		}

		public static HttpConnector GetInstance()
		{
			return _instance;
		}

        public string Get(string url)
        {
			try
			{
				using (HttpResponseMessage responseMessage = Task.Run(async () => { return await _httpClient.GetAsync(url); }).Result)
				{
					if (responseMessage.StatusCode == HttpStatusCode.OK)
					{
						using (HttpContent content = responseMessage.Content)
						{
							return Task.Run(async () => { return await content.ReadAsStringAsync(); }).Result;
						}
					}
					else if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
					{
						_lastErrorMessage = "Odmowa dostępu";
					}
					else
					{
						_lastErrorMessage = "Błąd połączenia z serwerem";
					}
				}
			}
			catch (Exception exc)
			{
				_lastErrorMessage = "Błąd połączenia z serwerem";
			}

			return null;
        }

        public string Delete(string url)
        {
			try
			{
				using (HttpResponseMessage responseMessage = Task.Run(async () => { return await _httpClient.DeleteAsync(url); }).Result)
				{
					if (responseMessage.StatusCode == HttpStatusCode.OK)
					{
						using (HttpContent content = responseMessage.Content)
						{
							return Task.Run(async () => { return await content.ReadAsStringAsync(); }).Result;
						}
					}else if(responseMessage.StatusCode == HttpStatusCode.Conflict)
					{
						_lastErrorMessage = "Nie można usunąć rekordu do którego istnieje odwołanie w innej tabeli";
					}
					else if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
					{
						_lastErrorMessage = "Odmowa dostępu";
					}
					else
					{
						_lastErrorMessage = "Błąd połączenia z serwerem";
					}

				}
			}
			catch(Exception exc)
			{
				_lastErrorMessage = "Błąd połączenia z serwerem";
			}
			return null;
        }

        public string Update(string url, object postContent)
        {
			try
			{
				using (HttpResponseMessage responseMessage = Task.Run(async () => { return await _httpClient.PostAsJsonAsync(url, postContent); }).Result)
				{
					if (responseMessage.StatusCode == HttpStatusCode.NoContent)
					{
						using (HttpContent content = responseMessage.Content)
						{
							return Task.Run(async () => { return await content.ReadAsStringAsync(); }).Result;
						}
					}
					else if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
					{
						_lastErrorMessage = "Odmowa dostępu";
					}
					else
					{
						_lastErrorMessage = "Błąd połączenia z serwerem";
					}

				}
			}
			catch (Exception exc)
			{
				_lastErrorMessage = "Błąd połączenia z serwerem";
			}
			return null;
        }

		public Dictionary<string, string> GetToken(string login, string password)
		{
			HttpContent content = new FormUrlEncodedContent(new Dictionary<string, string>()
				{
					{"grant_type", "password" },
					{ "username", login },
					{ "password", password }
				});
			try
			{
				using (HttpResponseMessage responseMessage = Task.Run(async () => { return await _httpClient.PostAsync("Token", content); }).Result)
				{
					if (responseMessage.StatusCode == HttpStatusCode.OK)
					{
						content = responseMessage.Content;
						string jsonString = Task.Run(async () => { return await content.ReadAsStringAsync(); }).Result;
						Dictionary<string, string> tokenData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
						return tokenData;
					}
					else if (responseMessage.StatusCode == HttpStatusCode.BadRequest)
					{
						_lastErrorMessage = "Niepoprawne dane logowania";
					}
					else
					{
						_lastErrorMessage = "Błąd połączenia z serwerem";
					}
				}
			}
			catch(Exception exc)
			{
				_lastErrorMessage = "Błąd połączenia z serwerem";
			}
			finally
			{
				content.Dispose();
			}

			return null;
		}

		/*public void setAuthorizeToken(string token)
		{
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue()
		}*/
	}
}
