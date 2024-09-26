using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestDI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ITransientService transientService;
		private readonly ITransientService transientService2;


		public HomeController(ITransientService transientService, ITransientService transientService2)
		{
			this.transientService = transientService;
			this.transientService2 = transientService2;
		}

		public ActionResult Index()
		{
			string[] injectedValues = {
				transientService.GetValue(),
				transientService.GetScopedValue(),
				transientService.GetSingletonValue(),
				transientService2.GetValue(),
				transientService2.GetScopedValue(),
				transientService2.GetSingletonValue()
			};
			ViewBag.InjectedValues = string.Join(Environment.NewLine, injectedValues);
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}