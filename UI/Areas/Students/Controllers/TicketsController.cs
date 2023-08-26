using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OHD.ModelsViews;
using OHD.Services;
using OHD.Services.utilityClasses;
using System.Dynamic;

namespace OHD.UI.Areas.Students.Controllers
{
    [Area("Students")]
    public class TicketsController : Controller
    {
        private readonly IRequestServices _requestServices;
        public TicketsController(IRequestServices requestServices)
        {
            _requestServices = requestServices;
            
            
        }
        // GET: TicketsController
        public ActionResult Index()
        {
            int id = (int)HttpContext.Session.GetInt32("Id");    
            var data = _requestServices.GetAllCreateRequests(id);
            return View(data);
        }
        public ActionResult Create()
        {
            ViewBag.Admin = (int)HttpContext.Session.GetInt32("AdminId");
            ViewBag.Requstor = (int)HttpContext.Session.GetInt32("Id");
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
                 await  _requestServices.createRequest(vm);
                
                    TempData["Success"] = "Request Created";
                    return  RedirectToAction(nameof(Index));
                }
               
              
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

            var vm = _requestServices.GetRequestByIdToFacility(id);
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
            if (check==true) {
                TempData["Success"] = "Request Delete";

            }
            else
            {
                TempData["Error"] = "Request not Delete";
            }
            return RedirectToAction(nameof(Index));
        } 
    }
}
