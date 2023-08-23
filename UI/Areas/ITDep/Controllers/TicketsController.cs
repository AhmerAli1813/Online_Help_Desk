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


        // GET: TicketsController
        public ActionResult Index()
        {
            int id = (int)HttpContext.Session.GetInt32("FacilityId");
            var modelvm = _requestServices.GetAllRequestByFacility(id);
            return View(modelvm);
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
