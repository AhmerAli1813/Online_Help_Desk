using Microsoft.AspNetCore.Mvc;
using OHD.ModelsViews;
using OHD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OHD.UI.Areas.Home.Controllers
{
    [Area("Home")]
    public class AurthController : Controller
    {
        private IAurtrizationServices _AurthServices;

		public AurthController(IAurtrizationServices aurthview)
		{
			_AurthServices = aurthview;
		}

		public IActionResult Index() => View();
        //login working start here
        [HttpPost]
        public IActionResult Index(AurthrizationView auth)
        {
            if (ModelState.IsValid) { 
            var list = _AurthServices.Aurthrization(auth);
            if ( list.Id!=0)
            {
                HttpContext.Session.SetString("Name", list.Name);
                HttpContext.Session.SetInt32("Role", list.RoleId);
                HttpContext.Session.SetString("Email", list.Email);
				HttpContext.Session.SetInt32("Id", list.Id);
					if (list.RoleId == 2000)
                {
                    return RedirectToAction("Index", "Home", new { area = "admin" });
                }
                else if (list.RoleId == 2001)
                {
                    return RedirectToAction("Index", "Home", new { area = "Students" });
                }
                else if (list.RoleId == 4001)
                {
                    return RedirectToAction("Index", "Home", new { area = "ITDep" });
                }
            }else
                {
					TempData["Success"] = "username and password is not valid";
                }
        }
            return View(); 
            
            
        }
       public IActionResult logout()
        {
            if(HttpContext.Session != null)
            {
                HttpContext.Session.Clear();
                
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ForgetPassword() => View();
        
    }
}
