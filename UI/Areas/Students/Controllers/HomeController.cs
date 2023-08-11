using Microsoft.AspNetCore.Mvc;

namespace OHD.UI.Areas.Students.Controllers
{
    [Area("Students")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
