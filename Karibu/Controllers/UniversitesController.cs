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
    public class UniversitesController : Controller
    {
        private readonly KaribuContext _context;

        public UniversitesController(KaribuContext context)
        {
            _context = context;
        }

        // GET: Universites
        public async Task<IActionResult> Index()
        {
            var karibuContext = _context.Universites.Include(u => u.IdStatutUniversiteNavigation).Include(u => u.IdTypeInstitutNavigation);
            return View(await karibuContext.ToListAsync());
        }

        // GET: Universites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Universites == null)
            {
                return NotFound();
            }

            var universite = await _context.Universites
                .Include(u => u.IdStatutUniversiteNavigation)
                .Include(u => u.IdTypeInstitutNavigation)
                .FirstOrDefaultAsync(m => m.IdUniversite == id);
            if (universite == null)
            {
                return NotFound();
            }

            return View(universite);
        }

        // GET: Universites/Create
        public IActionResult Create()
        {
            ViewData["IdStatutUniversite"] = new SelectList(_context.StatutUniversites, "IdStatutUniversite", "IdStatutUniversite");
            ViewData["IdTypeInstitut"] = new SelectList(_context.TypeInstituts, "IdTypeInstitut", "IdTypeInstitut");
            return View();
        }

        // POST: Universites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUniversite,Nom,Sigle,Adresse,NomRecteur,IdStatutUniversite,IdTypeInstitut")] Universite universite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(universite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdStatutUniversite"] = new SelectList(_context.StatutUniversites, "IdStatutUniversite", "IdStatutUniversite", universite.IdStatutUniversite);
            ViewData["IdTypeInstitut"] = new SelectList(_context.TypeInstituts, "IdTypeInstitut", "IdTypeInstitut", universite.IdTypeInstitut);
            return View(universite);
        }

        // GET: Universites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Universites == null)
            {
                return NotFound();
            }

            var universite = await _context.Universites.FindAsync(id);
            if (universite == null)
            {
                return NotFound();
            }
            ViewData["IdStatutUniversite"] = new SelectList(_context.StatutUniversites, "IdStatutUniversite", "IdStatutUniversite", universite.IdStatutUniversite);
            ViewData["IdTypeInstitut"] = new SelectList(_context.TypeInstituts, "IdTypeInstitut", "IdTypeInstitut", universite.IdTypeInstitut);
            return View(universite);
        }

        // POST: Universites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUniversite,Nom,Sigle,Adresse,NomRecteur,IdStatutUniversite,IdTypeInstitut")] Universite universite)
        {
            if (id != universite.IdUniversite)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversiteExists(universite.IdUniversite))
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
            ViewData["IdStatutUniversite"] = new SelectList(_context.StatutUniversites, "IdStatutUniversite", "IdStatutUniversite", universite.IdStatutUniversite);
            ViewData["IdTypeInstitut"] = new SelectList(_context.TypeInstituts, "IdTypeInstitut", "IdTypeInstitut", universite.IdTypeInstitut);
            return View(universite);
        }

        // GET: Universites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Universites == null)
            {
                return NotFound();
            }

            var universite = await _context.Universites
                .Include(u => u.IdStatutUniversiteNavigation)
                .Include(u => u.IdTypeInstitutNavigation)
                .FirstOrDefaultAsync(m => m.IdUniversite == id);
            if (universite == null)
            {
                return NotFound();
            }

            return View(universite);
        }

        // POST: Universites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Universites == null)
            {
                return Problem("Entity set 'KaribuContext.Universites'  is null.");
            }
            var universite = await _context.Universites.FindAsync(id);
            if (universite != null)
            {
                _context.Universites.Remove(universite);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversiteExists(int id)
        {
          return (_context.Universites?.Any(e => e.IdUniversite == id)).GetValueOrDefault();
        }
    }
}
