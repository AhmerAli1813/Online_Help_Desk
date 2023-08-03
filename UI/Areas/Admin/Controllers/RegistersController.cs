 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using Models;
using Services.Infrastructure.IRepository;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegistersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegistersController(IUnitOfWork unitOfWorkt)
        {
            _unitOfWork = unitOfWorkt;
        }

        // GET: Admin/Registers
        public IActionResult Index()
        { 
            return View();
        }

        // GET: Admin/Registers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var Register = _unitOfWork.RegisterIU.GetT(x => x.RegisterId == id);
            if (Register == null)
            {
                return NotFound();
            }

            return View(Register);
        }

        // GET: Admin/Registers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Registers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Register Register)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RegisterIU.Add(Register);
                _unitOfWork.save();
                return RedirectToAction(nameof(Index));
            }
            return View(Register);
        }

        // GET: Admin/Registers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var Register = _unitOfWork.RegisterIU.GetT(x => x.RegisterId == id);
            return View(Register);
        }

        // POST: Admin/Registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( Register Register)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.RegisterIU.update(Register);
                    _unitOfWork.save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Register);
        }

        // GET: Admin/Registers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var Register = _unitOfWork.RegisterIU.GetT(x => x.RegisterId == id);
            if (Register == null)
            {
                return NotFound();
            }
                
            return View(Register);
        }

        // POST: Admin/Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            
            var Register = _unitOfWork.RegisterIU.GetT(x => x.RegisterId == id); ;
            if (Register != null)
            {
                _unitOfWork.RegisterIU.Delete(Register);
            }

            _unitOfWork.save();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
