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
    public class RolesController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public RolesController(IUnitOfWork unitOfWorkt)
        {
            _unitOfWork = unitOfWorkt;
        }

        // GET: Admin/Roles
        public IActionResult Index()
        {
            IEnumerable<Roles> roles = _unitOfWork.RolesIU.GetAll();
            return View(roles);
        }

        // GET: Admin/Roles/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null )
            {
                return RedirectToAction("badRequest", "Home", new { area = "Home" });
            }

            var role = _unitOfWork.RolesIU.GetT(x => x.RoleId == id);
            if (role == null)
            {
                return RedirectToAction("badRequest", "Home", new { area = "Home" });
            }
            else
            {
				return View(role);
			}

            
        }

        // GET: Admin/Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Roles role)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RolesIU.Add(role);
                _unitOfWork.save();
				TempData["Success"] = "Create Successfuly";
				return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // GET: Admin/Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("badRequest", "Home", new { area = "Home" });
            }
            var role = _unitOfWork.RolesIU.GetT(x => x.RoleId == id);
            if (role == null || role.RoleId == 0) { return RedirectToAction("NotFound", "Home"); }
            else { return View(role); }
        }

        // POST: Admin/Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( Roles role)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.RolesIU.update(role);
                    _unitOfWork.save();
					TempData["Success"] = "Update Successfuly";
				}
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // GET: Admin/Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null )
            {
                return RedirectToAction("badRequest", "Home", new { area = "Home" });
            }

            var role = _unitOfWork.RolesIU.GetT(x => x.RoleId == id);
            if (role == null)
            {
                return RedirectToAction("badRequest", "Home", new { area = "Home" });
            }
                
            return View(role);
        }

        // POST: Admin/Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            
            var role = _unitOfWork.RolesIU.GetT(x => x.RoleId == id); ;
            if (role != null)
            {
                _unitOfWork.RolesIU.Delete(role);
				TempData["Success"] = "Delete Successfuly";
			}

            _unitOfWork.save();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
