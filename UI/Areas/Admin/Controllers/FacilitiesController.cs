 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OHD.DataAccessLayer;
using OHD.Models;
using OHD.DataAccessLayer.Infrastructure.IRepository;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FacilitiesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FacilitiesController(IUnitOfWork unitOfWorkt)
        {
            _unitOfWork = unitOfWorkt;
        }

        // GET: Admin/Facilitys
        public IActionResult Index()
        {
            IEnumerable<Facility> Facilitys = _unitOfWork.FacilityIU.GetAll();
            return View(Facilitys);
        }

        // GET: Admin/Facilitys/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null )
            {
				return RedirectToAction("badRequest", "Home", new { area = "Home" });
			}

            var Facility = _unitOfWork.FacilityIU.GetT(x => x.FacilityId == id);
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
        public IActionResult Create(Facility Facility)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.FacilityIU.Add(Facility);
                _unitOfWork.save();
                TempData["Success"] = "Create Successfuly";
                return RedirectToAction(nameof(Index));
            }
            return View(Facility);
        }

        // GET: Admin/Facilitys/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
				return RedirectToAction("badRequest", "Home", new { area = "Home" });
			}
            var Facility = _unitOfWork.FacilityIU.GetT(x => x.FacilityId == id);
            return View(Facility);
        }

        // POST: Admin/Facilitys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( Facility Facility)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.FacilityIU.update(Facility);
                    _unitOfWork.save();
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
        public IActionResult Delete(int? id)
        {
            if (id == null )
            {
				return RedirectToAction("badRequest", "Home", new { area = "Home" });
			}

            var Facility = _unitOfWork.FacilityIU.GetT(x => x.FacilityId == id);
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
            
            var Facility = _unitOfWork.FacilityIU.GetT(x => x.FacilityId == id); ;
            if (Facility != null)
            {
                _unitOfWork.FacilityIU.Delete(Facility);
				TempData["Success"] = "Delete Successfuly";
			}

            _unitOfWork.save();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
