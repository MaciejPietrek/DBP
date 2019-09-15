using Frontend.Misc;
using Frontend.Model;
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

		public void SetCredentials(Dictionary<string, string> tokenData)
		{
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenData["access_token"]);
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

		/// <summary>
		/// Aktualizacja modelu
		/// </summary>
		/// <param name="url">Scieżka do odpowiedniego kontrolera na serwerze</param>
		/// <param name="postContent">Model</param>
		/// <returns>String w formacie JSON zaweirający odpowiedź z serwera</returns>
        public string Update(string url, object postContent)
        {
			try
			{
				using (HttpResponseMessage responseMessage = Task.Run(async () => { return await _httpClient.PutAsJsonAsync(url, postContent); }).Result)
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

		/// <summary>
		/// Pobranie danych tokena autoryzującego, używane przy logowaniu
		/// </summary>
		/// <param name="login">Login</param>
		/// <param name="password">Hasło</param>
		/// <returns>Dictionary zawierający dane tokena</returns>
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

		/// <summary>
		/// Pobranie wszystkich użytkowników
		/// </summary>
		/// <returns></returns>
		public List<FrontendUserModel> GetUsers()
		{
			try
			{
				using (HttpResponseMessage responseMessage = Task.Run(async () => { return await _httpClient.GetAsync("api/Account/GetAll"); }).Result)
				{
					if (responseMessage.StatusCode == HttpStatusCode.OK)
					{
						using (HttpContent content = responseMessage.Content)
						{
							return JsonConvert.DeserializeObject<List<FrontendUserModel>>(Task.Run(async () => { return await content.ReadAsStringAsync(); }).Result);
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

		/// <summary>
		/// Pobranie ról zdefiniowanych w systemie
		/// </summary>
		/// <returns></returns>
		public List<string> GetRoles()
		{
			try
			{
				using (HttpResponseMessage responseMessage = Task.Run(async () => { return await _httpClient.GetAsync("api/Account/GetRoles"); }).Result)
				{
					if (responseMessage.StatusCode == HttpStatusCode.OK)
					{
						using (HttpContent content = responseMessage.Content)
						{
							return JsonConvert.DeserializeObject<List<string>>(Task.Run(async () => { return await content.ReadAsStringAsync(); }).Result);
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

		/// <summary>
		/// Pobranie ról aktualnie zalogowanego użytkownika
		/// </summary>
		/// <returns>Lista nazw ról</returns>
		public List<string> GetCurrentRoles()
		{
			try
			{
				using (HttpResponseMessage responseMessage = Task.Run(async () => { return await _httpClient.GetAsync("api/Account/GetCurrentRoles"); }).Result)
				{
					if (responseMessage.StatusCode == HttpStatusCode.OK)
					{
						using (HttpContent content = responseMessage.Content)
						{
							return JsonConvert.DeserializeObject<List<string>>(Task.Run(async () => { return await content.ReadAsStringAsync(); }).Result);
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

		/// <summary>
		/// Zmiana hasła altualnego użytkownika
		/// </summary>
		/// <param name="password">Nowe hasło</param>
		public void ChangePassword(string password)
		{
			try
			{
				HttpContent content = new FormUrlEncodedContent(new Dictionary<string, string>()
				{
					{ "Password", password }
				});
				using (HttpResponseMessage responseMessage = Task.Run(async () => { return await _httpClient.PostAsync("api/Account/ChangePassword", content); }).Result)
				{
					if (responseMessage.StatusCode == HttpStatusCode.NoContent || responseMessage.StatusCode == HttpStatusCode.OK)
					{
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
		}

		/// <summary>
		/// Dodawanie użytkownika
		/// </summary>
		/// <param name="model"></param>
		public void AddUser(FrontendUserModel model)
		{
			try
			{
				using (HttpResponseMessage responseMessage = Task.Run(async () => { return await _httpClient.PostAsJsonAsync("api/Account/AddUser", model); }).Result)
				{
					if (responseMessage.StatusCode == HttpStatusCode.OK)
					{
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
		}

		/// <summary>
		/// Edycja użytkownika
		/// </summary>
		/// <param name="model"></param>
		public void UpdateUser(FrontendUserModel model)
		{
			try
			{
				using (HttpResponseMessage responseMessage = Task.Run(async () => { return await _httpClient.PutAsJsonAsync("api/Account/UpdateUser", model); }).Result)
				{
					if (responseMessage.StatusCode == HttpStatusCode.OK)
					{
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
		}

		/// <summary>
		/// Usuwanie użytkownika
		/// </summary>
		/// <param name="model"></param>
		public void DeleteUser(FrontendUserModel model)
		{
			try
			{
				using (HttpResponseMessage responseMessage = Task.Run(async () => { return await _httpClient.PostAsJsonAsync("api/Account/DeleteUser", model); }).Result)
				{
					if (responseMessage.StatusCode == HttpStatusCode.OK)
					{
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
		}

	}
}
