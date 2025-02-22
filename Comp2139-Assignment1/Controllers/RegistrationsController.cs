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
    public class RegistrationsController : Controller
    {
        private readonly Assignment1Context _context;

        public RegistrationsController(Assignment1Context context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            var assignment1Context = _context.Registrations.Include(i => i.Customers).Include(i => i.Products);
            return View(await assignment1Context.ToListAsync());
        }

     

        
        public IActionResult Create()
        {
            ViewData["FName"] = new SelectList(_context.Customers, "FName", "FName");
            ViewData["Name"] = new SelectList(_context.Products, "Name", "Name");
            return View();
        }

     
        [HttpPost]
        public async Task<IActionResult> Create([Bind("RegistrationsID,CustomersID,FName,ProductsID,Name")] Registrations registrations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registrations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["FName"] = new SelectList(_context.Customers, "FName", "FName", registrations.CustomersID);
            ViewData["Name"] = new SelectList(_context.Products, "Name", "Name", registrations.ProductsID);
            return View(registrations);
        }

     
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrations = await _context.Registrations.FindAsync(id);
            if (registrations == null)
            {
                return NotFound();
            }

            ViewData["FName"] = new SelectList(_context.Customers, "FName", "FName", registrations.CustomersID);
            ViewData["Name"] = new SelectList(_context.Products, "Name", "Name", registrations.ProductsID);
            return View(registrations);
        }

      
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("RegistrationsID,CustomersID,FName, ProductsID,Name")] Registrations registrations)
        {
            if (id != registrations.RegistrationsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registrations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationsExists(registrations.RegistrationsID))
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
            ViewData["FName"] = new SelectList(_context.Customers, "FName", "FName", registrations.CustomersID);
            ViewData["Name"] = new SelectList(_context.Products, "Name", "Name", registrations.ProductsID);
            return View(registrations);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrations = await _context.Registrations
                .Include(i => i.Customers)
                .Include(i => i.Products)
                .FirstOrDefaultAsync(m => m.RegistrationsID == id);
            if (registrations == null)
            {
                return NotFound();
            }

            return View(registrations);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registrations = await _context.Registrations.FindAsync(id);
            _context.Registrations.Remove(registrations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationsExists(int id)
        {
            return _context.Registrations.Any(e => e.RegistrationsID == id);
        }
    }
}
