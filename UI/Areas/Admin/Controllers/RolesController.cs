 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OHD.ModelsViews;
using OHD.Services;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
		private readonly IRolesServices RolesServices;

		public RolesController(IRolesServices rolesServices)
		{
			RolesServices = rolesServices;
		}

		// GET: Admin/Roles
		public IActionResult Index()
        {
            var roles = RolesServices.GetALLRoles();
            return View(roles);
        }

        // GET: Admin/Roles/Details/5
        public IActionResult Details(int id)
        {
            if (id ==0 )
            {
                return RedirectToAction("badRequest", "Home", new { area = "Home" });
            }

            var role = RolesServices.GetRoleById(id);
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
        public IActionResult Create(RolesView vm)
        {
            if (ModelState.IsValid)
            {
                RolesServices.InsertRoles(vm);
                TempData["Success"] = "Create Successfuly";
				return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/Roles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("badRequest", "Home", new { area = "Home" });
            }
            var role =RolesServices.GetRoleById(id);
            if (role == null || role.Id == 0) { return RedirectToAction("NotFound", "Home"); }
            else { return View(role); }
        }

        // POST: Admin/Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( RolesView vm)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    RolesServices.UpdateRoles(vm);
					TempData["Success"] = "Update Successfuly";
				}
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/Roles/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0 )
            {
                return RedirectToAction("badRequest", "Home", new { area = "Home" });
            }

            var role =RolesServices.GetRoleById(id);
            if (role == null || role.Id==0)
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
            
            var role =RolesServices.GetRoleById(id); ;
            if (role != null)
            {
                RolesServices.DeleteRoles(id);
				TempData["Success"] = "Delete Successfuly";
			}

            
            return RedirectToAction(nameof(Index));
        }

        
    }
}
