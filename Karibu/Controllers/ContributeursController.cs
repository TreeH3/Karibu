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
    public class ContributeursController : Controller
    {
        private readonly KaribuContext _context;

        public ContributeursController(KaribuContext context)
        {
            _context = context;
        }

        // GET: Contributeurs
        public async Task<IActionResult> Index()
        {
              return _context.Contributeurs != null ? 
                          View(await _context.Contributeurs.ToListAsync()) :
                          Problem("Entity set 'KaribuContext.Contributeurs'  is null.");
        }

        // GET: Contributeurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contributeurs == null)
            {
                return NotFound();
            }

            var contributeur = await _context.Contributeurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contributeur == null)
            {
                return NotFound();
            }

            return View(contributeur);
        }

        // GET: Contributeurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contributeurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Surnom,NomComplet,Genre,Universite,Promotion,Annee,CreatedDate")] Contributeur contributeur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contributeur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contributeur);
        }

        // GET: Contributeurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contributeurs == null)
            {
                return NotFound();
            }

            var contributeur = await _context.Contributeurs.FindAsync(id);
            if (contributeur == null)
            {
                return NotFound();
            }
            return View(contributeur);
        }

        // POST: Contributeurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Surnom,NomComplet,Genre,Universite,Promotion,Annee,CreatedDate")] Contributeur contributeur)
        {
            if (id != contributeur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contributeur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContributeurExists(contributeur.Id))
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
            return View(contributeur);
        }

        // GET: Contributeurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contributeurs == null)
            {
                return NotFound();
            }

            var contributeur = await _context.Contributeurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contributeur == null)
            {
                return NotFound();
            }

            return View(contributeur);
        }

        // POST: Contributeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contributeurs == null)
            {
                return Problem("Entity set 'KaribuContext.Contributeurs'  is null.");
            }
            var contributeur = await _context.Contributeurs.FindAsync(id);
            if (contributeur != null)
            {
                _context.Contributeurs.Remove(contributeur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContributeurExists(int id)
        {
          return (_context.Contributeurs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
