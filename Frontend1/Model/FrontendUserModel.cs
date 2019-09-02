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
	}
}
