using Microsoft.Extensions.DependencyInjection;
using Services;
using System;

namespace DependencyInjection
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection ConfigureForWeb(this IServiceCollection services)
		{
			//TODO web specific configuration
			return ConfigureForAll(services);
		}

		public static IServiceCollection ConfigureForConsole(this IServiceCollection services)
		{
			// TODO console specific configuration
			return ConfigureForAll(services);
		}

		private static IServiceCollection ConfigureForAll(this IServiceCollection services)
		{
			services.AddTransient<ITransientService, TransientService>();
			services.AddScoped<IScopedService, ScopedService>();
			services.AddSingleton<ISingletonService, SingletonService>();
			return services;
		}
	}
}
