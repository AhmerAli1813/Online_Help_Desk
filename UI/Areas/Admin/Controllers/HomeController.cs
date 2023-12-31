﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OHD.Services;
using OHD.ModelsViews;

namespace OHD.UI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
    {
		private readonly IAurtrizationServices _aurtrizationServices;
		
		
		public HomeController(IAurtrizationServices aurtrizationServices)
		{
			_aurtrizationServices = aurtrizationServices;
		}

		public IActionResult Index()
		{
			if (HttpContext.Session.GetInt32("Role") != null)
			{
				if (HttpContext.Session.GetInt32("Role") == 2000)
				{
					if (HttpContext.Session.GetString("Name") != null)
					{
						ViewBag.Name = HttpContext.Session.GetString("Name");
					}
					
				}
				else
				{
					return RedirectToAction("badRequest", "Home", new { area = "Home" });
				}

			}
			else
			{
				return RedirectToAction("Index", "Auth", new { area = "Home" });
			}
			return View();
		}
		//[HttpGet]
		//public  IActionResult Profile()
		//{
		//	if(HttpContext.Session.GetInt32("Id") !=null) {
		//		int Id = (int)HttpContext.Session.GetInt32("Id");
		//		var data = _aurtrizationServices.GetProfileUser(Id);
		//		ViewBag.Name = HttpContext.Session.GetString("Name");
		//		return View(data);
		//	}
		//	return RedirectToAction("Aurth", "Home", new { area = "Home" });
		//}
		//[HttpPost]
		//public IActionResult Profile( ProfileUpdateView vm)
		//{
		//	bool c = _aurtrizationServices.UpdateProfile(vm);
		//		if (c == true)
		//		{
		//		TempData["success"] = "Profile Update successfully";
		//		}
		//		else { TempData["error"] = "old password is not match"; }
					
		//	return View(vm);
		//}
	}
}
