using Microsoft.AspNetCore.Mvc;

namespace OHD.UI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
		[Area("Admin")]
		public IActionResult NotFound() => View();
		public IActionResult Index() => View();
	}
}
