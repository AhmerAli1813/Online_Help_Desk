using Microsoft.AspNetCore.Mvc;

namespace OHD.UI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
    {

		public IActionResult Index()
		{
			if (HttpContext.Session.GetInt32("Role") != null)
			{
				if (HttpContext.Session.GetInt32("Role") == 2000)
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
	}
}
