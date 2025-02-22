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
    public class IncidentsController : Controller
    {
        private readonly Assignment1Context _context;

        public IncidentsController(Assignment1Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var assignment1Context = _context.Incidents.Include(i => i.Customers).Include(i => i.Products).Include(i => i.Technicians);
            return View(await assignment1Context.ToListAsync());
        }

      
        public IActionResult Create()
        {
            ViewData["CustomersID"] = new SelectList(_context.Customers, "CustomersID", "CustomersID");
            ViewData["ProductsID"] = new SelectList(_context.Products, "ProductsID", "ProductsID");
            ViewData["TechniciansID"] = new SelectList(_context.Technicians, "TechniciansID", "TechniciansID");
            return View();
        }

       
        [HttpPost]
    
        public async Task<IActionResult> Create([Bind("IncidentsID,Title,Description,CustomersID,ProductsID,TechniciansID,DateOpened,DateClosed")] Incidents incidents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incidents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomersID"] = new SelectList(_context.Customers, "CustomersID", "CustomersID", incidents.CustomersID);
            ViewData["ProductsID"] = new SelectList(_context.Products, "ProductsID", "ProductsID", incidents.ProductsID);
            ViewData["TechniciansID"] = new SelectList(_context.Technicians, "TechniciansID", "TechniciansID", incidents.TechniciansID);
            return View(incidents);
        }

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidents = await _context.Incidents.FindAsync(id);
            if (incidents == null)
            {
                return NotFound();
            }
            ViewData["CustomersID"] = new SelectList(_context.Customers, "CustomersID", "CustomersID", incidents.CustomersID);
            ViewData["ProductsID"] = new SelectList(_context.Products, "ProductsID", "ProductsID", incidents.ProductsID);
            ViewData["TechniciansID"] = new SelectList(_context.Technicians, "TechniciansID", "TechniciansID", incidents.TechniciansID);
            return View(incidents);
        }

        [HttpPost]
       public async Task<IActionResult> Edit(int id, [Bind("IncidentsID,Title,Description,CustomersID,ProductsID,TechniciansID,DateOpened,DateClosed")] Incidents incidents)
        {
            if (id != incidents.IncidentsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incidents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentsExists(incidents.IncidentsID))
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
            ViewData["CustomersID"] = new SelectList(_context.Customers, "CustomersID", "CustomersID", incidents.CustomersID);
            ViewData["ProductsID"] = new SelectList(_context.Products, "ProductsID", "ProductsID", incidents.ProductsID);
            ViewData["TechniciansID"] = new SelectList(_context.Technicians, "TechniciansID", "TechniciansID", incidents.TechniciansID);
            return View(incidents);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidents = await _context.Incidents
                .Include(i => i.Customers)
                .Include(i => i.Products)
                .Include(i => i.Technicians)
                .FirstOrDefaultAsync(m => m.IncidentsID == id);
            if (incidents == null)
            {
                return NotFound();
            }

            return View(incidents);
        }

       
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incidents = await _context.Incidents.FindAsync(id);
            _context.Incidents.Remove(incidents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidentsExists(int id)
        {
            return _context.Incidents.Any(e => e.IncidentsID == id);
        }
    }
}
