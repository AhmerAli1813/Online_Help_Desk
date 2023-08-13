using Microsoft.AspNetCore.Mvc;
using OHD.ModelsViews;
using OHD.Services;
using Microsoft.AspNetCore.Http;

namespace OHD.UI.Areas.Home.Controllers
{
	[Area("Home")]
	public class HomeController : Controller
	{
		public IActionResult badRequest(int? httpError)
		{
			if(httpError!= null)
			{
				if(httpError == 400)
				{
					ViewBag.HttpError = 400;
					ViewBag.HttpMessage = "You Seem To Be Trying To Find His Way Home";

				}
				else if(httpError == 403)
				{
					ViewBag.HttpError = 403;
					ViewBag.HttpMessage = "Sorry, access to this resource on the server is denied.\r\n Either check the URL";

				}
				else if (httpError == 500)
				{
					ViewBag.HttpError = 500;
					ViewBag.HttpMessage = "An error ocurred and your request couldn’t be completed..<br>Either check the URL";

				}
				else if (httpError == 503)
				{
					ViewBag.HttpError = 503;
					ViewBag.HttpMessage = "THIS SITE IS GETTING UP IN FEW MINUTES.\r\nPlease Try After Some Time\r\n\r\n\r\n";

				}
			}
			else
			{
				ViewBag.HttpError = 404;
				ViewBag.HttpMessage = "Sorry, the page you’re looking for cannot be accessed.\r\nEither check the URL";
			}
			return View();
		}
	}
}

