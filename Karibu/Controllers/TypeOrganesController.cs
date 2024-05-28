using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Karibu.Models;

namespace Karibu.Controllers
{
    public class TypeOrganesController : Controller
    {
        private readonly KaribuContext _context;

        public TypeOrganesController(KaribuContext context)
        {
            _context = context;
        }

        // GET: TypeOrganes
        public async Task<IActionResult> Index()
        {
              return _context.TypeOrganes != null ? 
                          View(await _context.TypeOrganes.ToListAsync()) :
                          Problem("Entity set 'KaribuContext.TypeOrganes'  is null.");
        }

        // GET: TypeOrganes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeOrganes == null)
            {
                return NotFound();
            }

            var typeOrgane = await _context.TypeOrganes
                .FirstOrDefaultAsync(m => m.IdTypeOrgane == id);
            if (typeOrgane == null)
            {
                return NotFound();
            }

            return View(typeOrgane);
        }

        // GET: TypeOrganes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeOrganes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTypeOrgane,NomType")] TypeOrgane typeOrgane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeOrgane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeOrgane);
        }

        // GET: TypeOrganes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeOrganes == null)
            {
                return NotFound();
            }

            var typeOrgane = await _context.TypeOrganes.FindAsync(id);
            if (typeOrgane == null)
            {
                return NotFound();
            }
            return View(typeOrgane);
        }

        // POST: TypeOrganes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTypeOrgane,NomType")] TypeOrgane typeOrgane)
        {
            if (id != typeOrgane.IdTypeOrgane)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeOrgane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeOrganeExists(typeOrgane.IdTypeOrgane))
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
            return View(typeOrgane);
        }

        // GET: TypeOrganes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeOrganes == null)
            {
                return NotFound();
            }

            var typeOrgane = await _context.TypeOrganes
                .FirstOrDefaultAsync(m => m.IdTypeOrgane == id);
            if (typeOrgane == null)
            {
                return NotFound();
            }

            return View(typeOrgane);
        }

        // POST: TypeOrganes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeOrganes == null)
            {
                return Problem("Entity set 'KaribuContext.TypeOrganes'  is null.");
            }
            var typeOrgane = await _context.TypeOrganes.FindAsync(id);
            if (typeOrgane != null)
            {
                _context.TypeOrganes.Remove(typeOrgane);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeOrganeExists(int id)
        {
          return (_context.TypeOrganes?.Any(e => e.IdTypeOrgane == id)).GetValueOrDefault();
        }
    }
}
