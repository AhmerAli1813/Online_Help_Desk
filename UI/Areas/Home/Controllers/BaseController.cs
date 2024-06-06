using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace OHD.UI.Areas.Home.Controllers
{
	[Authorize]
	public class BaseController : Controller
	{
	}
	[Authorize]
	public class BaseApiController : ApiController
	{
	}
}