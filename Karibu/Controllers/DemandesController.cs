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
    public class DemandesController : Controller
    {
        private readonly KaribuContext _context;

        public DemandesController(KaribuContext context)
        {
            _context = context;
        }

        // GET: Demandes
        public async Task<IActionResult> Index()
        {
            var karibuContext = _context.Demandes.Include(d => d.IdCommuneNavigation).Include(d => d.IdDomaineSujetNavigation).Include(d => d.IdFilliereNavigation).Include(d => d.IdNationaliteNavigation).Include(d => d.IdUniversiteNavigation);
            return View(await karibuContext.ToListAsync());
        }

        // GET: Demandes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Demandes == null)
            {
                return NotFound();
            }

            var demande = await _context.Demandes
                .Include(d => d.IdCommuneNavigation)
                .Include(d => d.IdDomaineSujetNavigation)
                .Include(d => d.IdFilliereNavigation)
                .Include(d => d.IdNationaliteNavigation)
                .Include(d => d.IdUniversiteNavigation)
                .FirstOrDefaultAsync(m => m.IdDemande == id);
            if (demande == null)
            {
                return NotFound();
            }

            return View(demande);
        }

        // GET: Demandes/Create
        public IActionResult Create()
        {
            ViewData["IdCommune"] = new SelectList(_context.Communes, "IdCommune", "IdCommune");
            ViewData["IdDomaineSujet"] = new SelectList(_context.Categories, "IdCategorie", "IdCategorie");
            ViewData["IdFilliere"] = new SelectList(_context.Filieres, "IdFiliere", "IdFiliere");
            ViewData["IdNationalite"] = new SelectList(_context.Pays, "IdPays", "IdPays");
            ViewData["IdUniversite"] = new SelectList(_context.Universites, "IdUniversite", "IdUniversite");
            return View();
        }

        // POST: Demandes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDemande,Nom,Postnom,Prenom,Genre,IdNationalite,LieuNaissance,DateNaissance,IdCommune,AdresseDomicile,Telephone,TypePieceIdentite,NumeroPieceIdentite,IdUniversite,NomUniversite,StatutUniverssite,AdresseUniversite,NomRecteur,Promotion,IdFilliere,Filliere,SujetTravail,IdDomaineSujet,ObjectifPoursuivi,ProbableDebut,ProbableFin,PersonneContact,TelephoneContact,FonctionContact,LettreStage,Photo")] Demande demande)
        {
            if (ModelState.IsValid)
            {
                _context.Add(demande);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCommune"] = new SelectList(_context.Communes, "IdCommune", "IdCommune", demande.IdCommune);
            ViewData["IdDomaineSujet"] = new SelectList(_context.Categories, "IdCategorie", "IdCategorie", demande.IdDomaineSujet);
            ViewData["IdFilliere"] = new SelectList(_context.Filieres, "IdFiliere", "IdFiliere", demande.IdFilliere);
            ViewData["IdNationalite"] = new SelectList(_context.Pays, "IdPays", "IdPays", demande.IdNationalite);
            ViewData["IdUniversite"] = new SelectList(_context.Universites, "IdUniversite", "IdUniversite", demande.IdUniversite);
            return View(demande);
        }

        // GET: Demandes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Demandes == null)
            {
                return NotFound();
            }

            var demande = await _context.Demandes.FindAsync(id);
            if (demande == null)
            {
                return NotFound();
            }
            ViewData["IdCommune"] = new SelectList(_context.Communes, "IdCommune", "IdCommune", demande.IdCommune);
            ViewData["IdDomaineSujet"] = new SelectList(_context.Categories, "IdCategorie", "IdCategorie", demande.IdDomaineSujet);
            ViewData["IdFilliere"] = new SelectList(_context.Filieres, "IdFiliere", "IdFiliere", demande.IdFilliere);
            ViewData["IdNationalite"] = new SelectList(_context.Pays, "IdPays", "IdPays", demande.IdNationalite);
            ViewData["IdUniversite"] = new SelectList(_context.Universites, "IdUniversite", "IdUniversite", demande.IdUniversite);
            return View(demande);
        }

        // POST: Demandes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdDemande,Nom,Postnom,Prenom,Genre,IdNationalite,LieuNaissance,DateNaissance,IdCommune,AdresseDomicile,Telephone,TypePieceIdentite,NumeroPieceIdentite,IdUniversite,NomUniversite,StatutUniverssite,AdresseUniversite,NomRecteur,Promotion,IdFilliere,Filliere,SujetTravail,IdDomaineSujet,ObjectifPoursuivi,ProbableDebut,ProbableFin,PersonneContact,TelephoneContact,FonctionContact,LettreStage,Photo")] Demande demande)
        {
            if (id != demande.IdDemande)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demande);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemandeExists(demande.IdDemande))
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
            ViewData["IdCommune"] = new SelectList(_context.Communes, "IdCommune", "IdCommune", demande.IdCommune);
            ViewData["IdDomaineSujet"] = new SelectList(_context.Categories, "IdCategorie", "IdCategorie", demande.IdDomaineSujet);
            ViewData["IdFilliere"] = new SelectList(_context.Filieres, "IdFiliere", "IdFiliere", demande.IdFilliere);
            ViewData["IdNationalite"] = new SelectList(_context.Pays, "IdPays", "IdPays", demande.IdNationalite);
            ViewData["IdUniversite"] = new SelectList(_context.Universites, "IdUniversite", "IdUniversite", demande.IdUniversite);
            return View(demande);
        }

        // GET: Demandes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Demandes == null)
            {
                return NotFound();
            }

            var demande = await _context.Demandes
                .Include(d => d.IdCommuneNavigation)
                .Include(d => d.IdDomaineSujetNavigation)
                .Include(d => d.IdFilliereNavigation)
                .Include(d => d.IdNationaliteNavigation)
                .Include(d => d.IdUniversiteNavigation)
                .FirstOrDefaultAsync(m => m.IdDemande == id);
            if (demande == null)
            {
                return NotFound();
            }

            return View(demande);
        }

        // POST: Demandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Demandes == null)
            {
                return Problem("Entity set 'KaribuContext.Demandes'  is null.");
            }
            var demande = await _context.Demandes.FindAsync(id);
            if (demande != null)
            {
                _context.Demandes.Remove(demande);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemandeExists(long id)
        {
          return (_context.Demandes?.Any(e => e.IdDemande == id)).GetValueOrDefault();
        }
    }
}
