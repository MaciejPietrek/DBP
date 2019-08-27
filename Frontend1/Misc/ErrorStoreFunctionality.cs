using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Misc
{
	public class ErrorStoreFunctionality
	{
		protected string _lastErrorMessage = null;
		public string LastErrorMessage {
			get
			{
				string message = _lastErrorMessage;
				_lastErrorMessage = null;
				return message;
			}
		}
	}
}
