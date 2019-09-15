using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Model
{
	public class FrontendUserModel
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public List<string> Roles { get; set; }

		public FrontendUserModel Clone()
		{
			var clone = new FrontendUserModel { Username = Username, Password = Password };
			var roleList = new List<string>();
			foreach(string roleName in Roles)
			{
				roleList.Add(roleName);
			}
			clone.Roles = roleList;
			return clone;
		}
	}
}
