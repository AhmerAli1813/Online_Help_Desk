using Microsoft.AspNetCore.Mvc;

namespace OHD.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult NotFound()
        {
            return View();
        }
    }
}
