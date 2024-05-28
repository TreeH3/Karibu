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
    public class StatutUniversitesController : Controller
    {
        private readonly KaribuContext _context;

        public StatutUniversitesController(KaribuContext context)
        {
            _context = context;
        }

        // GET: StatutUniversites
        public async Task<IActionResult> Index()
        {
              return _context.StatutUniversites != null ? 
                          View(await _context.StatutUniversites.ToListAsync()) :
                          Problem("Entity set 'KaribuContext.StatutUniversites'  is null.");
        }

        // GET: StatutUniversites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StatutUniversites == null)
            {
                return NotFound();
            }

            var statutUniversite = await _context.StatutUniversites
                .FirstOrDefaultAsync(m => m.IdStatutUniversite == id);
            if (statutUniversite == null)
            {
                return NotFound();
            }

            return View(statutUniversite);
        }

        // GET: StatutUniversites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatutUniversites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStatutUniversite,Statut")] StatutUniversite statutUniversite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statutUniversite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statutUniversite);
        }

        // GET: StatutUniversites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StatutUniversites == null)
            {
                return NotFound();
            }

            var statutUniversite = await _context.StatutUniversites.FindAsync(id);
            if (statutUniversite == null)
            {
                return NotFound();
            }
            return View(statutUniversite);
        }

        // POST: StatutUniversites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStatutUniversite,Statut")] StatutUniversite statutUniversite)
        {
            if (id != statutUniversite.IdStatutUniversite)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statutUniversite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatutUniversiteExists(statutUniversite.IdStatutUniversite))
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
            return View(statutUniversite);
        }

        // GET: StatutUniversites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StatutUniversites == null)
            {
                return NotFound();
            }

            var statutUniversite = await _context.StatutUniversites
                .FirstOrDefaultAsync(m => m.IdStatutUniversite == id);
            if (statutUniversite == null)
            {
                return NotFound();
            }

            return View(statutUniversite);
        }

        // POST: StatutUniversites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StatutUniversites == null)
            {
                return Problem("Entity set 'KaribuContext.StatutUniversites'  is null.");
            }
            var statutUniversite = await _context.StatutUniversites.FindAsync(id);
            if (statutUniversite != null)
            {
                _context.StatutUniversites.Remove(statutUniversite);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatutUniversiteExists(int id)
        {
          return (_context.StatutUniversites?.Any(e => e.IdStatutUniversite == id)).GetValueOrDefault();
        }
    }
}
