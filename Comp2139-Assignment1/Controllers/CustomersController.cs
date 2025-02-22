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
    public class CustomersController : Controller
    {
        private readonly Assignment1Context _context;

        public CustomersController(Assignment1Context context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var assignment1Context = _context.Customers.Include(c => c.Countries);
            return View(await assignment1Context.ToListAsync());
        }

       
        public IActionResult Create()
        {
            ViewData["CountriesID"] = new SelectList(_context.Countries, "CountriesID", "CountriesID");
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([Bind("CustomersID,FName,LName,Address,City,State,PostalCode,CountriesID,Email,Phone")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountriesID"] = new SelectList(_context.Countries, "CountriesID", "CountriesID", customers.CountriesID);
            return View(customers);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            ViewData["CountriesID"] = new SelectList(_context.Countries, "CountriesID", "CountriesID", customers.CountriesID);
            return View(customers);
        }

   
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("CustomersID,FName,LName,Address,City,State,PostalCode,CountriesID,Email,Phone")] Customers customers)
        {
            if (id != customers.CustomersID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersExists(customers.CustomersID))
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
            ViewData["CountriesID"] = new SelectList(_context.Countries, "CountriesID", "CountriesID", customers.CountriesID);
            return View(customers);
        }

     
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .Include(c => c.Countries)
                .FirstOrDefaultAsync(m => m.CustomersID == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

     
        [HttpPost, ActionName("Delete")]
       
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customers = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomersExists(int id)
        {
            return _context.Customers.Any(e => e.CustomersID == id);
        }
    }
}
