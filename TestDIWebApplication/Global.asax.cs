using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestDI.Infrastructure.ConfigurationExtensions;
using TestDI.Infrastructure.DependancyInjection;

[assembly: PreApplicationStartMethod(typeof(TestDI.TestDIWebApplication), nameof(TestDI.TestDIWebApplication.InitModule))]
[assembly: PreApplicationStartMethod(typeof(TestDI.TestDIWebApplication), nameof(TestDI.TestDIWebApplication.SetDependencyResolver))]

namespace TestDI
{
	public class TestDIWebApplication : System.Web.HttpApplication
	{
		public static void InitModule()
		{
			RegisterModule(typeof(ServiceScopeModule));
		}

		public static void SetDependencyResolver()
		{
			var services = new ServiceCollection();

			services.AddControllers();
			services.ConfigureForWeb();

			var serviceProvider = services.BuildServiceProvider(new ServiceProviderOptions
			{
				ValidateOnBuild = true,
				ValidateScopes = true
			});

			ServiceScopeModule.SetServiceProvider(serviceProvider);
			DependencyResolver.SetResolver(new DefaultDependencyResolver());
		}

		protected void Application_Start()
		{

			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

		}
	}
}
