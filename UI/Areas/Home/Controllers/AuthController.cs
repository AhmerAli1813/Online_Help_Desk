using Microsoft.AspNetCore.Mvc;
using OHD.ModelsViews;
using OHD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace OHD.UI.Areas.Home.Controllers
{
    [Area("Home")]
    public class AuthController : Controller
    {
        private IAurtrizationServices _AurthServices;

		public AuthController(IAurtrizationServices aurthview)
		{
			_AurthServices = aurthview;
		}

		public IActionResult Index() => View();
        //login working start here
        [HttpPost]
        public IActionResult Index(AurthrizationView auth)
        {
            if (ModelState.IsValid) { 
                //Login proccess Here
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

		[HttpGet]
		public IActionResult Profile()
		{
			if (HttpContext.Session.GetInt32("Id") != null)
			{
				int Id = (int)HttpContext.Session.GetInt32("Id");

				var data = _AurthServices.GetProfileUser(Id);

				ViewBag.Layout = ViewImport();

				ViewBag.Name = HttpContext.Session.GetString("Name");
				return View(data);
			}
			return RedirectToAction("Auth", "Home", new { area = "Home" });
		}


		[HttpPost]
		public IActionResult Profile(ProfileUpdateView vm)
		{
			ViewBag.Layout = ViewImport();

			if (ModelState.IsValid)
            {
				bool c = _AurthServices.UpdateProfile(vm);
				if (c == true)
				{
					TempData["success"] = "Profile Update successfully";
				}
				else { TempData["error"] = "old password is not match"; }
                return View(vm);
			}
			return View(vm);
		}

		[HttpGet]
		public IActionResult ChangePassword() 
		{ ViewBag.Id = HttpContext.Session.GetInt32("Id");
				
			return View();
		}
		[HttpPost]
		public IActionResult ChangePassword(ChangePasswordView vm)
		{
			if (ModelState.IsValid)
			{
				bool c = _AurthServices.UpdatePassword(vm);

				if (c == true)
				{
					TempData["success"] = "Password Update successfully";
					return RedirectToAction("Profile", "auth", new { area = "Home" });
				}
				else { TempData["error"] = "old password is not match"; }
				
			}

			return View(vm);

		}

		
		private string ViewImport()
		{
			
			int RoleId = (int)HttpContext.Session.GetInt32("Role");
			if (RoleId == 2000)
			{//admin layout
				return "~/Areas/Admin/Views/Shared/_Layout.cshtml";
			}
			else if (RoleId == 2001)
			{//students Layout
				return "~/Areas/Students/Views/Shared/_Layout.cshtml";
			}
			else if (RoleId == 4001)
			{//IT Department view
				return "~/Areas/ITDep/Views/Shared/_Layout.cshtml";
			}
			else
			{
				return "~/Areas/Home/Views/Shared/_Layout.cshtml";
			}
		}

	}
}
