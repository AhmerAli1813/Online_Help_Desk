using Microsoft.AspNetCore.Mvc;
using OHD.UI.Areas.Home.Controllers;

namespace OHD.UI.Areas.Admin.Controllers
{
	[Area("Admin")]

	public class HomeController : BaseController
	{


		public IActionResult Index() => View();

	}
}
