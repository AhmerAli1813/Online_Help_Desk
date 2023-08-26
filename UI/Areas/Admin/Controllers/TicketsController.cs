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
        public  IActionResult Edit(int id)
        {
          var modelvmData =  _requestServices.GetRequestByIdToFacilityHead(id);
            ViewBag.AllFacility = new SelectList(_requestServices.GetALLFacility(), "FacilityId", "FacilityName");
            
            return View(modelvmData);
        }

        // POST: TicketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RequstedAssigendView vm)
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

    }
}
