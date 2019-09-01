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
		List<string> _userRoles = new List<string>();

		private AuthManager() { }

		public static AuthManager GetInstance()
		{
			return _instance;
		}

		public List<string> UserRoles { get { return _userRoles; } }

		public string SignIn(string login, string password)
		{
			HttpConnector httpConnector = HttpConnector.GetInstance();
			_tokenData = httpConnector.GetToken(login, password);
			string errorMessage = httpConnector.LastErrorMessage;
			if(errorMessage == null)
			{
				httpConnector.SetCredentials(_tokenData);
				_userRoles = httpConnector.GetCurrentRoles();
				errorMessage = httpConnector.LastErrorMessage;
			}
			return errorMessage;
		}
	}
}
