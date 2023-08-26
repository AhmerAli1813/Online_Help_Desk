using Microsoft.AspNetCore.Mvc;
using OHD.ModelsViews;
using OHD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using OHD.Services.utilityClasses;
using OHD.Models;
using Microsoft.AspNetCore.Authentication;

namespace OHD.UI.Areas.Home.Controllers
{
    [Area("Home")]
    public class AuthController : Controller
    {
        private IAurtrizationServices _AurthServices;
        private IEmailSender _emailSender;
        private  int _RoleId;
        private int _FgId;
        private  string? _Name;
        private  string? MyLayout ;
        private int _pin;
        private string? _username;
        private bool? _sendEmailCheck;
        public AuthController(IAurtrizationServices aurthview, IEmailSender emailSender)
        {
            _AurthServices = aurthview;
            _emailSender = emailSender;
        }

        public IActionResult Index() => View();
        //login working start here
        [HttpPost]
        public async Task<IActionResult> Index(AurthrizationView auth)
        {
            if (ModelState.IsValid) {
                //Login proccess Here
                var list = _AurthServices.Aurthrization(auth);
                if (list.Id != 0)
                {
                   Task task = _emailSender.SendEmailAsync("Welcome to OHD", "Salam " + list.Name, list.Email);
                    _RoleId = list.RoleId;
                    _Name = list.Name;
                    HttpContext.Session.SetString("Name", list.Name);
                    HttpContext.Session.SetInt32("Role", list.RoleId);
                    HttpContext.Session.SetString("Email", list.Email);
                    HttpContext.Session.SetInt32("Id", list.Id);
                    HttpContext.Session.SetInt32("FacilityId", list.FacilityId);
                    HttpContext.Session.SetInt32("AdminId", _AurthServices.GetAdminID());
                    HttpContext.Session.SetString("AdminEmail", _AurthServices.GetAdminEmail());
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
        [HttpGet]
        public IActionResult ForgetPassword() => View();
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ChangePasswordView Vm)
        {
            SetPin();
         if(_pin!=0 && Vm.pin == _pin || Vm.id!=0)
            {
                ViewBag.SendEmailCheck = true;
                ViewBag.pinVerified = true;
                if (Vm.id != 0)
                {
                    try
                    {
                        var IsOk = _AurthServices.ForgetPassword(Vm);
                        if (IsOk == true)
                        {
                            TempData["Success"] = "Password is change ! Login now";
                            return RedirectToAction("Index");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    ViewBag.id = _FgId;
                    TempData["Error"] = "Must given new password";
                }
            }
            else
            {
                try
                {
                    var modelVm = _AurthServices.GetUserDataByUsername(Vm.username);
                    if(modelVm.id == 0)
                    {
                        TempData["Error"] = "Username is not valid";
                    }
                    else
                    {
                        var PinGenrator = new RandomNumberGenerator().GenerateRandomNumbers(1);
                        _pin = PinGenrator[0];
                        HttpContext.Session.SetInt32("pin", _pin);
                        await _emailSender.SendEmailAsync("Forget Password" ,"If you Don't remmeber password <br> Pin: <b>"+_pin+"</b> <br> Don't share Your Pin " , modelVm.email);
                        Console.WriteLine(_pin);
                        ViewBag.pinVerified = false;
                        ViewBag.SendEmailCheck = true;
                        ViewBag.email = modelVm.email;
                        HttpContext.Session.SetInt32("FgId", modelVm.id);
                        _FgId = modelVm.id;
                        ViewBag.id = _FgId;
                        

                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            ViewBag.id = _FgId;
            return View();

        }

        private void SetPin()
        {
            if (HttpContext.Session.GetInt32("pin") != null)
            {
                _pin = (int)HttpContext.Session.GetInt32("pin");

            }
            else
            {
                _pin = 0;
            }
            if (HttpContext.Session.GetInt32("FgId") != null)
            {
                _FgId = (int)HttpContext.Session.GetInt32("FgId");

            }
            else
            {
                _FgId = 0;
            }
        }

        [HttpGet]
        public IActionResult Profile()
        {
            if (HttpContext.Session.GetInt32("Id") != null)
            {
                _RoleId = (int)HttpContext.Session.GetInt32("Role");
                ViewImport();
                int Id = (int)HttpContext.Session.GetInt32("Id");

                var data = _AurthServices.GetProfileUser(Id);

                ViewBag.layout = MyLayout;

                ViewBag.Name = (string)HttpContext.Session.GetString("Name");
                return View(data);
            }
            return RedirectToAction("Auth", "Home", new { area = "Home" });
        }


        [HttpPost]
        public IActionResult Profile(ProfileUpdateView vm)
        {
            ViewImport();   
            ViewBag.layout = MyLayout;

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
        public IActionResult ChangePassword(ModifiyPasswordView vm)
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
        
        private void ViewImport()
        {
            _RoleId = (int)HttpContext.Session.GetInt32("Role");
            
            if (_RoleId == 2000)
            {//admin MyLayout
                MyLayout = "~/Areas/Admin/Views/Shared/_layout.cshtml";

            }
            else if (_RoleId == 2001)
            {//students MyLayout
                MyLayout = "~/Areas/ITDep/Views/Shared/_layout.cshtml";
            }
            else if (_RoleId == 2002 || _RoleId == 2004)
            {//IT Department view
                MyLayout = "~/Areas/Students/Views/Shared/_layout.cshtml";
            }
            else
            {
                MyLayout = "~/Areas/Home/Views/Shared/_layout.cshtml";
            }
        }



    }
}
