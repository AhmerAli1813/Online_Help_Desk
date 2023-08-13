using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace OHD.UI.Areas.Students.Controllers
{
    [Area("Students")]
    public class HomeController : Controller
    {
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
    }
}
