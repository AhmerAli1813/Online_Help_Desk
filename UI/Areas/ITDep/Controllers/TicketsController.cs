using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OHD.ModelsViews;
using OHD.Services;
using System.Dynamic;
using System.Net.WebSockets;

namespace OHD.UI.Areas.ITDep.Controllers
{
    [Area("ITDep")]
    public class TicketsController : Controller
    {
        private readonly IRequestServices _requestServices;
        private HttpContext _httpContext;
        public TicketsController(IRequestServices requestServices)
        {
            _requestServices = requestServices;

        }
        public ActionResult Index()
        {
            int id = (int)HttpContext.Session.GetInt32("FacilityId");
            var modelvm = _requestServices.GetAllRequestByFacility(id);
            return View(modelvm);
        }
        public IActionResult MyTickets()
        {

            int id = (HttpContext.Session.GetInt32("Id") == null) ? 0 : (int)HttpContext.Session.GetInt32("Id");
            var data = _requestServices.GetAllCreateRequests(id);
            return View(data);
        }
        public IActionResult Create()
        {
            if ((int)HttpContext.Session.GetInt32("AdminId") != null) { ViewBag.Admin = (int)HttpContext.Session.GetInt32("AdminId"); }
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

        // GET: TicketsController/Create
        public ActionResult Edit(int id)
        {
            var modelvmData = _requestServices.GetRequestByIdToFacility(id);
            
            return View(modelvmData);
        }

        // POST: TicketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RequstedAssigendByFacilityView vm)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                var model = _requestServices.GetRequestById(vm.Id);
                _requestServices.UpdateAssigerRequestRemarks(vm, model);
                TempData["Success"] = "Request update";
                return RedirectToAction(nameof(Index));
                //}


            }
            catch (Exception ex)
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
    }
}
