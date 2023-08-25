using Microsoft.AspNetCore.Mvc;
using OHD.ModelsViews;
using OHD.Services;

namespace OHD.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FacilityController : Controller
    {
        private IFacilityServices _facilityServices;

        public FacilityController(IFacilityServices facilityServices)
        {
            _facilityServices = facilityServices;
        }

        public IActionResult Index()
        {
            var dataList = _facilityServices.GetALLFacility();
            return View(dataList);
        }
        [HttpGet]
        public IActionResult CreateUpdate(int id)
        {
            FacilityView model = new FacilityView();
            
			if (id == null | id == 0)
            {

                return View(model);
            }
            else
            {
                var data = _facilityServices.GetFacilityById(id);
                if (data == null)
                {
                    return NotFound();
                }
                else { return View(data); }

            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(FacilityView modelVm)
        {
            if (ModelState.IsValid)
            {
                if (modelVm.Id == 0)
                {
                    _facilityServices.InsertFacility(modelVm);
                    TempData["Success"] = "Successfully create Done";
                }
                else
                {
                    _facilityServices.UpdateFacility(modelVm);
                    TempData["Success"] = "Employee Updated Done";
                }

                
                return RedirectToAction("Index");
            }
            return View(modelVm);
        }


        public  IActionResult Details(int id)
        {

            var data = _facilityServices.GetFacilityById(id);
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var data = _facilityServices.GetFacilityById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            if(id !=0)
            {
                _facilityServices.DeleteFacility(id);
                TempData["Success"] = " Delete Successfully";
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("badRequest", "Home", new { area = "Home" });
        }


    }
}
