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
    public class CommunesController : Controller
    {
        private readonly KaribuContext _context;

        public CommunesController(KaribuContext context)
        {
            _context = context;
        }

        // GET: Communes
        public async Task<IActionResult> Index()
        {
              return _context.Communes != null ? 
                          View(await _context.Communes.ToListAsync()) :
                          Problem("Entity set 'KaribuContext.Communes'  is null.");
        }

        // GET: Communes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Communes == null)
            {
                return NotFound();
            }

            var commune = await _context.Communes
                .FirstOrDefaultAsync(m => m.IdCommune == id);
            if (commune == null)
            {
                return NotFound();
            }

            return View(commune);
        }

        // GET: Communes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Communes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCommune,NomCommune")] Commune commune)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commune);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commune);
        }

        // GET: Communes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Communes == null)
            {
                return NotFound();
            }

            var commune = await _context.Communes.FindAsync(id);
            if (commune == null)
            {
                return NotFound();
            }
            return View(commune);
        }

        // POST: Communes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCommune,NomCommune")] Commune commune)
        {
            if (id != commune.IdCommune)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commune);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommuneExists(commune.IdCommune))
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
            return View(commune);
        }

        // GET: Communes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Communes == null)
            {
                return NotFound();
            }

            var commune = await _context.Communes
                .FirstOrDefaultAsync(m => m.IdCommune == id);
            if (commune == null)
            {
                return NotFound();
            }

            return View(commune);
        }

        // POST: Communes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Communes == null)
            {
                return Problem("Entity set 'KaribuContext.Communes'  is null.");
            }
            var commune = await _context.Communes.FindAsync(id);
            if (commune != null)
            {
                _context.Communes.Remove(commune);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommuneExists(int id)
        {
          return (_context.Communes?.Any(e => e.IdCommune == id)).GetValueOrDefault();
        }
    }
}
