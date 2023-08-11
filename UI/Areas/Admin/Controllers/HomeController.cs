using Microsoft.AspNetCore.Mvc;

namespace OHD.UI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
    {
		public IActionResult NotFound() => View();
		public IActionResult Index() => View();
	}
}
