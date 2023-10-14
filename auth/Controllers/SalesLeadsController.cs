using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using authentication.Data;
using authentication.Models;

namespace authentication.Controllers
{
    public class SalesLeadsController : Controller
    {
        private readonly ContextDb _context;

        public SalesLeadsController(ContextDb context)
        {
            _context = context;
        }

        // GET: SalesLeads
        public async Task<IActionResult> Index()
        {
              return _context.SalesLeads != null ? 
                          View(await _context.SalesLeads.ToListAsync()) :
                          Problem("Entity set 'ContextDb.SalesLeads'  is null.");
        }

        // GET: SalesLeads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SalesLeads == null)
            {
                return NotFound();
            }

            var salesLead = await _context.SalesLeads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesLead == null)
            {
                return NotFound();
            }

            return View(salesLead);
        }

        // GET: SalesLeads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesLeads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,SecondName,Email,Phone,Source")] SalesLead salesLead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesLead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesLead);
        }

        // GET: SalesLeads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SalesLeads == null)
            {
                return NotFound();
            }

            var salesLead = await _context.SalesLeads.FindAsync(id);
            if (salesLead == null)
            {
                return NotFound();
            }
            return View(salesLead);
        }

        // POST: SalesLeads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,SecondName,Email,Phone,Source")] SalesLead salesLead)
        {
            if (id != salesLead.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesLead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesLeadExists(salesLead.Id))
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
            return View(salesLead);
        }

        // GET: SalesLeads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SalesLeads == null)
            {
                return NotFound();
            }

            var salesLead = await _context.SalesLeads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesLead == null)
            {
                return NotFound();
            }

            return View(salesLead);
        }

        // POST: SalesLeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SalesLeads == null)
            {
                return Problem("Entity set 'ContextDb.SalesLeads'  is null.");
            }
            var salesLead = await _context.SalesLeads.FindAsync(id);
            if (salesLead != null)
            {
                _context.SalesLeads.Remove(salesLead);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesLeadExists(int id)
        {
          return (_context.SalesLeads?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
