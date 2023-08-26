using Microsoft.AspNetCore.Mvc;
using OHD.ModelsViews;
using OHD.Services;

namespace OHD.UI.Areas.ITDep.Controllers
{
    [Area("ITDep")]
    public class HomeController : Controller
    {
		private readonly IAurtrizationServices _aurtrizationServices;


		public HomeController(IAurtrizationServices aurtrizationServices)
		{
			_aurtrizationServices = aurtrizationServices;
		}

		public IActionResult Index()
		{
			if (HttpContext.Session.GetInt32("Role") != null)
			{
				if (HttpContext.Session.GetInt32("Role") == 2001)
				{
                    if (HttpContext.Session.GetInt32("Name") != null)
					{
                        ViewBag.Name = HttpContext.Session.GetString("Name");
                    }
                        
				}
				else
				{
					return RedirectToAction("badRequest", "Home", new { area = "Home" });
				}

			}
			else
			{
				return RedirectToAction("Index", "Auth", new { area = "Home" });
			}
			return View();
		}
		
	}
}
