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
    public class OrganesController : Controller
    {
        private readonly KaribuContext _context;

        public OrganesController(KaribuContext context)
        {
            _context = context;
        }

        // GET: Organes
        public async Task<IActionResult> Index()
        {
            var karibuContext = _context.Organes.Include(o => o.IdOrganeParentNavigation).Include(o => o.IdTypeOrganeNavigation);
            return View(await karibuContext.ToListAsync());
        }

        // GET: Organes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Organes == null)
            {
                return NotFound();
            }

            var organe = await _context.Organes
                .Include(o => o.IdOrganeParentNavigation)
                .Include(o => o.IdTypeOrganeNavigation)
                .FirstOrDefaultAsync(m => m.IdOrgane == id);
            if (organe == null)
            {
                return NotFound();
            }

            return View(organe);
        }

        // GET: Organes/Create
        public IActionResult Create()
        {
            ViewData["IdOrganeParent"] = new SelectList(_context.Organes, "IdOrgane", "IdOrgane");
            ViewData["IdTypeOrgane"] = new SelectList(_context.TypeOrganes, "IdTypeOrgane", "IdTypeOrgane");
            return View();
        }

        // POST: Organes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrgane,NomOrgane,IdTypeOrgane,IdOrganeParent")] Organe organe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdOrganeParent"] = new SelectList(_context.Organes, "IdOrgane", "IdOrgane", organe.IdOrganeParent);
            ViewData["IdTypeOrgane"] = new SelectList(_context.TypeOrganes, "IdTypeOrgane", "IdTypeOrgane", organe.IdTypeOrgane);
            return View(organe);
        }

        // GET: Organes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Organes == null)
            {
                return NotFound();
            }

            var organe = await _context.Organes.FindAsync(id);
            if (organe == null)
            {
                return NotFound();
            }
            ViewData["IdOrganeParent"] = new SelectList(_context.Organes, "IdOrgane", "IdOrgane", organe.IdOrganeParent);
            ViewData["IdTypeOrgane"] = new SelectList(_context.TypeOrganes, "IdTypeOrgane", "IdTypeOrgane", organe.IdTypeOrgane);
            return View(organe);
        }

        // POST: Organes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdOrgane,NomOrgane,IdTypeOrgane,IdOrganeParent")] Organe organe)
        {
            if (id != organe.IdOrgane)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganeExists(organe.IdOrgane))
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
            ViewData["IdOrganeParent"] = new SelectList(_context.Organes, "IdOrgane", "IdOrgane", organe.IdOrganeParent);
            ViewData["IdTypeOrgane"] = new SelectList(_context.TypeOrganes, "IdTypeOrgane", "IdTypeOrgane", organe.IdTypeOrgane);
            return View(organe);
        }

        // GET: Organes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Organes == null)
            {
                return NotFound();
            }

            var organe = await _context.Organes
                .Include(o => o.IdOrganeParentNavigation)
                .Include(o => o.IdTypeOrganeNavigation)
                .FirstOrDefaultAsync(m => m.IdOrgane == id);
            if (organe == null)
            {
                return NotFound();
            }

            return View(organe);
        }

        // POST: Organes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Organes == null)
            {
                return Problem("Entity set 'KaribuContext.Organes'  is null.");
            }
            var organe = await _context.Organes.FindAsync(id);
            if (organe != null)
            {
                _context.Organes.Remove(organe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganeExists(string id)
        {
          return (_context.Organes?.Any(e => e.IdOrgane == id)).GetValueOrDefault();
        }
    }
}
