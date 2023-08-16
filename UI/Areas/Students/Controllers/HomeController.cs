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
                if (HttpContext.Session.GetInt32("Role") == 2001)
                {
                    ViewBag.Name = HttpContext.Session.GetString("Name");
                }
                else
                {
                     return RedirectToAction("badRequest", "Home", new { area = "Home" });
				}
                
            }
            else
            {
                return RedirectToAction("Index", "Aurth", new { area = "Home" });
            }
            return View();
        }
		[HttpGet]
		public IActionResult Profile()
		{
			if (HttpContext.Session.GetInt32("Id") != null)
			{
				int Id = (int)HttpContext.Session.GetInt32("Id");
				var data = _aurtrizationServices.GetProfileUser(Id);
				ViewBag.Name = HttpContext.Session.GetString("Name");
				return View(data);
			}
			return RedirectToAction("Aurth", "Home", new { area = "Home" });
		}
		[HttpPost]
		public IActionResult Profile(ProfileUpdateView vm)
		{
			bool c = _aurtrizationServices.UpdateProfile(vm);
			if (c == true)
			{
				TempData["success"] = "Profile Update successfully";
			}
			else { TempData["error"] = "old password is not match"; }

			return View(vm);
		}
	}
}
