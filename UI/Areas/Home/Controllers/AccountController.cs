using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OHD.DataAccessLayer;
using OHD.ModelsViews;
using OHD.Services.utilityClasses;

namespace OHD.UI.Areas.Home.Controllers
{
	[Area("Home")]
	public class AccountController : Controller
	{
		//private IAurtrizationServices _AurthServices;
		private IEmailSender _emailSender;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;
		private int _RoleId;
		private int _FgId;
		private string? _Name;
		private string? MyLayout;
		private int _pin;
		private string? _username;
		private bool? _sendEmailCheck;

		public AccountController(IEmailSender emailSender, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, int roleId, int fgId, string? name, string? myLayout, int pin, string? username, bool? sendEmailCheck)
		{
			_emailSender = emailSender;
			_signInManager = signInManager;
			_userManager = userManager;
			_RoleId = roleId;
			_FgId = fgId;
			_Name = name;
			MyLayout = myLayout;
			_pin = pin;
			_username = username;
			_sendEmailCheck = sendEmailCheck;
		}

		public IActionResult Login() => View();
		public IActionResult Register() => View();
		//login working start here
		[HttpPost]
		public async Task<IActionResult> Login(AurthrizationView model)
		{
			if (ModelState.IsValid)
			{
				//Login proccess Here
				var resp = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
				//   var list = await _AurthServices.Authorization(auth);

				if (resp.Succeeded)
				{
					return RedirectToAction("Index", "Home", "Home");
				}
				ModelState.AddModelError("", "Invalid login attempt");
				return View(model);
			}
			return View(model);


		}
		[HttpPost]
		public async Task<IActionResult> Register(ApplicationUser model)
		{
			if (ModelState.IsValid)
			{
				//Login proccess Here
				ApplicationUser user = new ApplicationUser()
				{
					Address = model.Address,
					Email = model.Email,
					FullName = model.FullName,
					UserName = model.Email,
				};
				var resp = await _userManager.CreateAsync(user, model.PasswordHash);
				if (resp.Succeeded)
				{
					await _signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("Index", "Home", "Home");
				}
				foreach (var item in resp.Errors)
				{
					ModelState.AddModelError("", item.Description);
				}
				//   var list = await _AurthServices.Authorization(auth);

				if (resp.Succeeded)
				{
					return RedirectToAction("Index", "Home", "Home");
				}
				ModelState.AddModelError("", "Invalid login attempt");
				return View(model);
			}
			return View(model);


		}
		public IActionResult logout()
		{
			if (HttpContext.Session != null)
			{
				HttpContext.Session.Clear();

			}
			return RedirectToAction(nameof(Login));
		}
		[HttpGet]
		public IActionResult ForgetPassword() => View();
		//[HttpPost]
		//public async Task<IActionResult> ForgetPassword(ChangePasswordView Vm)
		//{
		//    SetPin();
		// if(_pin!=0 && Vm.pin == _pin || Vm.id!=0)
		//    {
		//        ViewBag.SendEmailCheck = true;
		//        ViewBag.pinVerified = true;
		//        if (Vm.id != 0)
		//        {
		//            try
		//            {
		//                var IsOk = await _AurthServices.ForgetPassword(Vm);
		//                if (IsOk == true)
		//                {
		//                    TempData["Success"] = "Password is change ! Login now";
		//                    return RedirectToAction("Index");
		//                }
		//            }
		//            catch (Exception ex)
		//            {
		//                Console.WriteLine(ex.Message);
		//            }
		//        }
		//        else
		//        {
		//            ViewBag.id = _FgId;
		//            TempData["Error"] = "Must given new password";
		//        }
		//    }
		//    else
		//    {
		//        try
		//        {
		//            var modelVm = await _AurthServices.GetUserDataByUsername(Vm.username);
		//            if(modelVm.id == 0)
		//            {
		//                TempData["Error"] = "Username is not valid";
		//            }
		//            else
		//            {
		//                var PinGenrator = new RandomNumberGenerator().GenerateRandomNumbers(1);
		//                _pin = PinGenrator[0];
		//                HttpContext.Session.SetInt32("pin", _pin);
		//                await _emailSender.SendEmailAsync("Forget Password" ,"If you Don't remmeber password <br> Pin: <b>"+_pin+"</b> <br> Don't share Your Pin " , modelVm.email);
		//                Console.WriteLine(_pin);
		//                ViewBag.pinVerified = false;
		//                ViewBag.SendEmailCheck = true;
		//                ViewBag.email = modelVm.email;
		//                HttpContext.Session.SetInt32("FgId", modelVm.id);
		//                _FgId = modelVm.id;
		//                ViewBag.id = _FgId;


		//            }
		//        }
		//        catch(Exception ex)
		//        {
		//            Console.WriteLine(ex.Message);
		//        }

		//    }
		//    ViewBag.id = _FgId;
		//    return View();

		//}

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
		public async Task<IActionResult> Profile()
		{
			//if (HttpContext.Session.GetInt32("Id") != null)
			//{
			//    _RoleId = (int)HttpContext.Session.GetInt32("Role");
			//    ViewImport();
			//    int Id = (int)HttpContext.Session.GetInt32("Id");

			//    var data = await _AurthServices.GetProfileUser(Id);

			//    ViewBag.layout = MyLayout;

			//    ViewBag.Name = (string)HttpContext.Session.GetString("Name");
			//    return View(data);
			//}
			return RedirectToAction("Auth", "Home", new { area = "Home" });
		}


		[HttpPost]
		public async Task<IActionResult> Profile(ProfileUpdateView vm)
		{
			//ViewImport();   
			//ViewBag.layout = MyLayout;

			//if (ModelState.IsValid)
			//{
			//    bool c = await _AurthServices.UpdateProfile(vm);
			//    if (c == true)
			//    {
			//        TempData["success"] = "Profile Update successfully";
			//    }
			//    else { TempData["error"] = "old password is not match"; }
			//    return View(vm);
			//}
			return View(vm);
		}

		[HttpGet]
		public IActionResult ChangePassword()
		{
			ViewBag.Id = HttpContext.Session.GetInt32("Id");

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ChangePassword(ModifiyPasswordView vm)
		{
			//if (ModelState.IsValid)
			//{
			//    bool c = await _AurthServices.UpdatePassword(vm);

			//    if (c == true)
			//    {
			//        TempData["success"] = "Password Update successfully";
			//        return RedirectToAction("Profile", "auth", new { area = "Home" });
			//    }
			//    else { TempData["error"] = "old password is not match"; }

			//}

			return View(vm);

		}

		//private void ViewImport()
		//{
		//    _RoleId = (int)HttpContext.Session.GetInt32("Role");

		//    if (_RoleId == 2000)
		//    {//admin MyLayout
		//        MyLayout = "~/Areas/Admin/Views/Shared/_layout.cshtml";

		//    }
		//    else if (_RoleId == 2001)
		//    {//students MyLayout
		//        MyLayout = "~/Areas/ITDep/Views/Shared/_layout.cshtml";
		//    }
		//    else if (_RoleId == 2002 || _RoleId == 2004)
		//    {//IT Department view
		//        MyLayout = "~/Areas/Students/Views/Shared/_layout.cshtml";
		//    }
		//    else
		//    {
		//        MyLayout = "~/Areas/Home/Views/Shared/_layout.cshtml";
		//    }
		//}



	}
}
