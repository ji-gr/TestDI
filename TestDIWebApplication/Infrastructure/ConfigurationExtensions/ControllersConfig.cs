using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestDI.Infrastructure.ConfigurationExtensions
{
	public static class ControllersConfig
	{
		public static IServiceCollection AddControllers(this IServiceCollection services)
		{
			var controllers = typeof(ControllersConfig).Assembly.GetExportedTypes()
			  .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
			  .Where(t => typeof(IController).IsAssignableFrom(t)
			   || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase));
			foreach (var type in controllers)
			{
				services.AddTransient(type);
			}
			return services;
		}
	}
}