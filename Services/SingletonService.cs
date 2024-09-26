using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services
{
	public class SingletonService : ISingletonService
	{
		private string _value = Guid.NewGuid().ToString();


		public string GetValue()
		{
			return _value;
		}
	}
}