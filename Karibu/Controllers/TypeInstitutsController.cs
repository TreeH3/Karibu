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
    public class TypeInstitutsController : Controller
    {
        private readonly KaribuContext _context;

        public TypeInstitutsController(KaribuContext context)
        {
            _context = context;
        }

        // GET: TypeInstituts
        public async Task<IActionResult> Index()
        {
              return _context.TypeInstituts != null ? 
                          View(await _context.TypeInstituts.ToListAsync()) :
                          Problem("Entity set 'KaribuContext.TypeInstituts'  is null.");
        }

        // GET: TypeInstituts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeInstituts == null)
            {
                return NotFound();
            }

            var typeInstitut = await _context.TypeInstituts
                .FirstOrDefaultAsync(m => m.IdTypeInstitut == id);
            if (typeInstitut == null)
            {
                return NotFound();
            }

            return View(typeInstitut);
        }

        // GET: TypeInstituts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeInstituts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTypeInstitut,Type")] TypeInstitut typeInstitut)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeInstitut);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeInstitut);
        }

        // GET: TypeInstituts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeInstituts == null)
            {
                return NotFound();
            }

            var typeInstitut = await _context.TypeInstituts.FindAsync(id);
            if (typeInstitut == null)
            {
                return NotFound();
            }
            return View(typeInstitut);
        }

        // POST: TypeInstituts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTypeInstitut,Type")] TypeInstitut typeInstitut)
        {
            if (id != typeInstitut.IdTypeInstitut)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeInstitut);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeInstitutExists(typeInstitut.IdTypeInstitut))
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
            return View(typeInstitut);
        }

        // GET: TypeInstituts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeInstituts == null)
            {
                return NotFound();
            }

            var typeInstitut = await _context.TypeInstituts
                .FirstOrDefaultAsync(m => m.IdTypeInstitut == id);
            if (typeInstitut == null)
            {
                return NotFound();
            }

            return View(typeInstitut);
        }

        // POST: TypeInstituts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeInstituts == null)
            {
                return Problem("Entity set 'KaribuContext.TypeInstituts'  is null.");
            }
            var typeInstitut = await _context.TypeInstituts.FindAsync(id);
            if (typeInstitut != null)
            {
                _context.TypeInstituts.Remove(typeInstitut);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeInstitutExists(int id)
        {
          return (_context.TypeInstituts?.Any(e => e.IdTypeInstitut == id)).GetValueOrDefault();
        }
    }
}
