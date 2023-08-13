using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using OHD.ModelsViews;
using OHD.Services;

namespace OHD.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegistersController : Controller
    {
        IRegisterServices _RegisteredServices;

        public RegistersController(IRegisterServices registeredServices)
        {
            _RegisteredServices = registeredServices;
        }

        public IActionResult Index()
        {
            IEnumerable<RegisterView> vm = _RegisteredServices.GetALLRegisters().ToList();
            return View(vm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllRoles = new SelectList(_RegisteredServices.GetALLRoles(), "RoleId" , "RoleName");
            ViewBag.AllFacility = new SelectList(_RegisteredServices.GetALLFacility(), "FacilityId", "FacilityName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(RegisterView model)
        {
            _RegisteredServices.InsertRegister(model);
			TempData["Success"] = "Create Successfuly";
			return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null || id==0)
            {

                return RedirectToAction("badRequest", "Home", new { area = "Home" });
            }
            else
            {

				ViewBag.AllRoles = new SelectList(_RegisteredServices.GetALLRoles(), "RoleId", "RoleName");
				ViewBag.AllFacility = new SelectList(_RegisteredServices.GetALLFacility(), "FacilityId", "FacilityName");
				var Vm = _RegisteredServices.GetRegisterByExprission(id);
                if (Vm == null || Vm.Id==0)
                {
					return RedirectToAction("badRequest", "Home", new { area = "Home" });
				}
                else
                {
					return View(Vm);
				}
				
			}
        }
        [HttpPost]
        public IActionResult Edit(RegisterView model)
        {
            _RegisteredServices.UpdateRegister(model);
			TempData["Success"] = "Update Successfuly";
			return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
             _RegisteredServices.DeleteRegister(id);
			TempData["Success"] = "Delete Successfuly";
			return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {

            if (id == null || id == 0)
            {
				return RedirectToAction("badRequest", "Home", new { area = "Home" });
			}
            else
            {
                var model = _RegisteredServices.GetRegisterByExprission(id);
                if (model == null||model.Id==0) { return RedirectToAction("badRequest", "Home", new { area = "Home" }); } else {return View(model); }

			}

            
        }

    }
}
