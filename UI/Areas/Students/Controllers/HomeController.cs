using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OHD.ModelsViews;
using OHD.Services;

namespace OHD.UI.Areas.Students.Controllers
{
    [Area("Students")]
    public class HomeController : Controller
    {
		private readonly IAurtrizationServices _aurtrizationServices;


		public HomeController(IAurtrizationServices aurtrizationServices)
		{
			_aurtrizationServices = aurtrizationServices;
		}

		public IActionResult Index()
        {   
            if(HttpContext.Session.GetInt32("Role") != null)
            {
                if (HttpContext.Session.GetInt32("Role") == 2002)
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
