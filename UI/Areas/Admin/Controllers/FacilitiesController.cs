 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OHD.DataAccessLayer;

using OHD.Infrastructure;
using OHD.Services;
using OHD.ModelsViews;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FacilitiesController : Controller
    {
        private readonly IFacilityServices facilityServices;

		public FacilitiesController(IFacilityServices facilityServices)
		{
			this.facilityServices = facilityServices;
		}


		// GET: Admin/Facilitys
		public IActionResult Index()
        {
            var Facilitys =facilityServices.GetALLFacility();
            return View(Facilitys);
        }

        // GET: Admin/Facilitys/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0 )
            {
				return RedirectToAction("badRequest", "Home", new { area = "Home" });
			}

            var Facility = facilityServices.GetFacilityById(id);
            if (Facility == null)
            {
				return RedirectToAction("badRequest", "Home", new { area = "Home" });
			}

            return View(Facility);
        }

        // GET: Admin/Facilitys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Facilitys/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FacilityView Facility)
        {
            if (ModelState.IsValid)
            {
                facilityServices.InsertFacility(Facility);
                TempData["Success"] = "Create Successfuly";
                return RedirectToAction(nameof(Index));
            }
            return View(Facility);
        }

        // GET: Admin/Facilitys/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0 || id == 0)
            {
				return RedirectToAction("badRequest", "Home", new { area = "Home" });
			}
            var Facility = facilityServices.GetFacilityById(id);
            return View(Facility);
        }

        // POST: Admin/Facilitys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( FacilityView Facility)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    facilityServices.UpdateFacility(Facility);
					TempData["Success"] = "Update Successfuly";
				}
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Facility);
        }

        // GET: Admin/Facilitys/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0 )
            {
				return RedirectToAction("badRequest", "Home", new { area = "Home" });
			}

            var Facility = facilityServices.GetFacilityById(id);
            if (Facility == null)
            {
				return RedirectToAction("badRequest", "Home", new { area = "Home" });
			}
                
            return View(Facility);
        }

        // POST: Admin/Facilitys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            
            var Facility = facilityServices.GetFacilityById(id); ;
            if (Facility != null)
            {
                facilityServices.DeleteFacility(id);    
				TempData["Success"] = "Delete Successfuly";
			}

            
            return RedirectToAction(nameof(Index));
        }

        
    }
}
