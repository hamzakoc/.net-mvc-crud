using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Comp2139_Assignment1.Models;

namespace Comp2139_Assignment1.Controllers
{
    public class TechniciansController : Controller
    {
        private readonly Assignment1Context _context;

        public TechniciansController(Assignment1Context context)
        {
            _context = context;
        }

   
        public async Task<IActionResult> Index()
        {
            return View(await _context.Technicians.ToListAsync());
        }

        

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TechniciansID,Name,Email,Phone")] Technicians technicians)
        {
            if (ModelState.IsValid)
            {
                _context.Add(technicians);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(technicians);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicians = await _context.Technicians.FindAsync(id);
            if (technicians == null)
            {
                return NotFound();
            }
            return View(technicians);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TechniciansID,Name,Email,Phone")] Technicians technicians)
        {
            if (id != technicians.TechniciansID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(technicians);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechniciansExists(technicians.TechniciansID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(technicians);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicians = await _context.Technicians
                .FirstOrDefaultAsync(m => m.TechniciansID == id);
            if (technicians == null)
            {
                return NotFound();
            }

            return View(technicians);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var technicians = await _context.Technicians.FindAsync(id);
            _context.Technicians.Remove(technicians);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechniciansExists(int id)
        {
            return _context.Technicians.Any(e => e.TechniciansID == id);
        }
    }
}
