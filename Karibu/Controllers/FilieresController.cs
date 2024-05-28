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
    public class FilieresController : Controller
    {
        private readonly KaribuContext _context;

        public FilieresController(KaribuContext context)
        {
            _context = context;
        }

        // GET: Filieres
        public async Task<IActionResult> Index()
        {
              return _context.Filieres != null ? 
                          View(await _context.Filieres.ToListAsync()) :
                          Problem("Entity set 'KaribuContext.Filieres'  is null.");
        }

        // GET: Filieres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Filieres == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filieres
                .FirstOrDefaultAsync(m => m.IdFiliere == id);
            if (filiere == null)
            {
                return NotFound();
            }

            return View(filiere);
        }

        // GET: Filieres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filieres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFiliere,Nom")] Filiere filiere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filiere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filiere);
        }

        // GET: Filieres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Filieres == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filieres.FindAsync(id);
            if (filiere == null)
            {
                return NotFound();
            }
            return View(filiere);
        }

        // POST: Filieres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFiliere,Nom")] Filiere filiere)
        {
            if (id != filiere.IdFiliere)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filiere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiliereExists(filiere.IdFiliere))
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
            return View(filiere);
        }

        // GET: Filieres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Filieres == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filieres
                .FirstOrDefaultAsync(m => m.IdFiliere == id);
            if (filiere == null)
            {
                return NotFound();
            }

            return View(filiere);
        }

        // POST: Filieres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Filieres == null)
            {
                return Problem("Entity set 'KaribuContext.Filieres'  is null.");
            }
            var filiere = await _context.Filieres.FindAsync(id);
            if (filiere != null)
            {
                _context.Filieres.Remove(filiere);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiliereExists(int id)
        {
          return (_context.Filieres?.Any(e => e.IdFiliere == id)).GetValueOrDefault();
        }
    }
}
