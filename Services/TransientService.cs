using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Services
{
	public class TransientService : ITransientService
	{
		private string _value = Guid.NewGuid().ToString();

		private readonly IScopedService _scopedService;
		private readonly ISingletonService _singletonService;


		public TransientService(IScopedService scopedService, ISingletonService singletonService)
		{
			_scopedService = scopedService;
			_singletonService = singletonService;
		}

		public string GetValue()
		{
			return $"{this.GetType().Name}:{_value}";
		}

		public string GetScopedValue()
		{
			return $"{_scopedService.GetType().Name}:{_scopedService.GetValue()}";
		}

		public string GetSingletonValue()
		{
			return $"{_singletonService.GetType().Name}:{_singletonService.GetValue()}";
		}
	}
}