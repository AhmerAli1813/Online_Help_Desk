using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using OHD.ModelsViews;
using OHD.Services;
using System.Dynamic;

namespace OHD.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TicketsController : Controller
    {
        private readonly IRequestServices _requestServices;
        private HttpContext _httpContext;
        public TicketsController(IRequestServices requestServices)
        {
            _requestServices = requestServices;
            
        }
        // GET: TicketsController
        public ActionResult Index()
        {
            
            var data = _requestServices.GetAllRequests();
            
            return View(data);
        }
        [HttpGet]
        public IActionResult  GetAssigeners(int Id)
        {
         
            var list =  _requestServices.GetALLAssigerByFacilityId(Id);
            
            return Json(list);
        }
		// GET: TicketsController/Create
		public IActionResult MyTickets()
		{

			int id = (HttpContext.Session.GetInt32("Id") == null) ? 0 : (int)HttpContext.Session.GetInt32("Id");
			var data = _requestServices.GetAllCreateRequests(id);
			return View(data);
		}
		public IActionResult Create()
		{
			if ((int)HttpContext.Session.GetInt32("AdminId") != null){ViewBag.Admin = (int)HttpContext.Session.GetInt32("AdminId");}
			if ((int)HttpContext.Session.GetInt32("Id") != null) { ViewBag.Requstor = (int)HttpContext.Session.GetInt32("Id"); }
			return View();
		}

		// POST: TicketsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateRequestView vm)
		{
			try
			{
				if (ModelState.IsValid)
				{
					//string AdminEmail = (string)HttpContext.Session.GetString("AdminEmail");
					await _requestServices.createRequest(vm);

					TempData["Success"] = "Request Created";
					return RedirectToAction(nameof(MyTickets));
				}


			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			return View(vm);
		}
		public IActionResult MyDetails(int id)
		{
			if (id == 0)
			{
				return RedirectToAction("badRequest", "Home", new { area = "Home" });
			}

            var vm = _requestServices.GetRequestByIdToCreateUser(id);

            if (vm == null)
			{
				return RedirectToAction("badRequest", "Home", new { area = "Home" });
			}
			else
			{
				return View(vm);
			}

		}
	
		public  IActionResult Edit(int id)
        {
          var modelvmData =  _requestServices.GetRequestByIdToFacilityHead(id);
            ViewBag.AllFacility = new SelectList(_requestServices.GetALLFacility(), "FacilityId", "FacilityName");
            
            return View(modelvmData);
        }

        // POST: TicketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RequstedAssigendView vm)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    var model = _requestServices.GetRequestById(vm.Id);
                    _requestServices.UpdateAssigerRequestToAssigen(vm,model);
                    TempData["Success"] = "Request update";
                    return RedirectToAction(nameof(Index));
                //}
               
              
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View(vm);
        }
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("badRequest", "Home", new { area = "Home" });
            }

            var vm = _requestServices.GetRequestByIdToFacilityHead(id);
            if (vm == null)
            {
                return RedirectToAction("badRequest", "Home", new { area = "Home" });
            }
            else
            {
                return View(vm);
            }


        }
		public IActionResult Delete(int id)
		{
			if (id == 0)
			{
				return RedirectToAction("badRequest", "Home", new { area = "Home" });
			}

			var vm = _requestServices.GetRequestByIdToCreateUser(id);
			if (vm == null)
			{
				return RedirectToAction("badRequest", "Home", new { area = "Home" });
			}
			else
			{
				return View(vm);
			}

		}
		[HttpPost]
		public IActionResult DeleteConfirmed(int id)
		{
			bool check = _requestServices.DeleteRequsted(id);
			if (check == true)
			{
				TempData["Success"] = "Request Delete";

			}
			else
			{
				TempData["Error"] = "Request not Delete";
			}
			return RedirectToAction(nameof(MyTickets));
		}
	}
}
