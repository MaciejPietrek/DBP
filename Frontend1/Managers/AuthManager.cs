using Frontend.DataRecievers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Managers
{
	class AuthManager
	{
		static AuthManager _instance = new AuthManager();
		Dictionary<string, string> _tokenData;


		private AuthManager() { }

		public static AuthManager GetInstance()
		{
			return _instance;
		}

		public string SignIn(string login, string password)
		{
			HttpConnector httpConnector = HttpConnector.GetInstance();
			_tokenData = httpConnector.GetToken(login, password);
			return httpConnector.LastErrorMessage;
		}
	}
}
