using Microsoft.AspNetCore.Mvc;

namespace OHD.UI.Areas.ITDep.Controllers
{
    [Area("ITDep")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
