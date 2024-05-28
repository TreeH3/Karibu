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
    public class PaysController : Controller
    {
        private readonly KaribuContext _context;

        public PaysController(KaribuContext context)
        {
            _context = context;
        }

        // GET: Pays
        public async Task<IActionResult> Index()
        {
              return _context.Pays != null ? 
                          View(await _context.Pays.ToListAsync()) :
                          Problem("Entity set 'KaribuContext.Pays'  is null.");
        }

        // GET: Pays/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Pays == null)
            {
                return NotFound();
            }

            var pay = await _context.Pays
                .FirstOrDefaultAsync(m => m.IdPays == id);
            if (pay == null)
            {
                return NotFound();
            }

            return View(pay);
        }

        // GET: Pays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPays,NomPays")] Pay pay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pay);
        }

        // GET: Pays/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Pays == null)
            {
                return NotFound();
            }

            var pay = await _context.Pays.FindAsync(id);
            if (pay == null)
            {
                return NotFound();
            }
            return View(pay);
        }

        // POST: Pays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdPays,NomPays")] Pay pay)
        {
            if (id != pay.IdPays)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayExists(pay.IdPays))
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
            return View(pay);
        }

        // GET: Pays/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Pays == null)
            {
                return NotFound();
            }

            var pay = await _context.Pays
                .FirstOrDefaultAsync(m => m.IdPays == id);
            if (pay == null)
            {
                return NotFound();
            }

            return View(pay);
        }

        // POST: Pays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Pays == null)
            {
                return Problem("Entity set 'KaribuContext.Pays'  is null.");
            }
            var pay = await _context.Pays.FindAsync(id);
            if (pay != null)
            {
                _context.Pays.Remove(pay);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayExists(string id)
        {
          return (_context.Pays?.Any(e => e.IdPays == id)).GetValueOrDefault();
        }
    }
}
