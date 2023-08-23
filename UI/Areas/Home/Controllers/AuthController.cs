using Microsoft.AspNetCore.Mvc;
using OHD.ModelsViews;
using OHD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using OHD.Services.utilityClasses;
using OHD.Models;

namespace OHD.UI.Areas.Home.Controllers
{
    [Area("Home")]
    public class AuthController : Controller
    {
        private IAurtrizationServices _AurthServices;
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string __layout { get; set; }

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
                if (list.Id != 0)
                {
                    HttpContext.Session.SetString("Name", list.Name);
                    HttpContext.Session.SetInt32("Role", list.RoleId);
                    HttpContext.Session.SetString("Email", list.Email);
                    HttpContext.Session.SetInt32("Id", list.Id);
                    HttpContext.Session.SetInt32("FacilityId", list.FacilityId);
                    HttpContext.Session.SetInt32("AdminId", _AurthServices.GetAdminID());
                    if (list.RoleId == 2000)
                    {
                        return RedirectToAction("Index", "Home", new { area = "admin" });
                    }
                    else if (list.RoleId == 2001)
                    {
                        return RedirectToAction("Index", "Home", new { area = "ITDep" });
                    }
                    else if (list.RoleId == 2002)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Students" });
                    }
                    
                } else
                {
                    TempData["Success"] = "username and password is not valid";
                }
            }
            return View();


        }
        public IActionResult logout()
        {
            if (HttpContext.Session != null)
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

                ViewBag.layout = __layout;

                ViewBag.Name = Name;
                return View(data);
            }
            return RedirectToAction("Auth", "Home", new { area = "Home" });
        }


        [HttpPost]
        public IActionResult Profile(ProfileUpdateView vm)
        {
            ViewBag.layout = __layout;

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
        private void ViewImport(HttpContext httpContext = null)
        {

            RoleId = (int)httpContext.Session.GetInt32("Role");
            Name = httpContext.Session.GetString("Name");

            if (RoleId == 2000)
            {//admin __layout
                __layout = "~/Areas/Admin/Views/Shared/_layout.cshtml";

            }
            else if (RoleId == 2001)
            {//students __layout
                __layout = "~/Areas/ITDep/Views/Shared/_layout.cshtml";
            }
            else if (RoleId == 2003 || RoleId == 2004)
            {//IT Department view
                __layout = "~/Areas/Students/Views/Shared/_layout.cshtml";
            }
            else
            {
                __layout = "~/Areas/Home/Views/Shared/_layout.cshtml";
            }
        }



    }
}
