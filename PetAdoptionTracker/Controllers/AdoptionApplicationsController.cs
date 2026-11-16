using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetAdoptionTracker.Data;
using PetAdoptionTracker.Data.Models;

namespace PetAdoptionTracker.Controllers
{
    public class AdoptionApplicationsController : Controller
    {
        private readonly AdoptionDbContext _context;

        public AdoptionApplicationsController(AdoptionDbContext context)
        {
            _context = context;
        }

        // GET: AdoptionApplications
        public async Task<IActionResult> Index()
        {
            var adoptionDbContext = _context.AdoptionApplications.Include(a => a.Adopter).Include(a => a.Pet);
            return View(await adoptionDbContext.ToListAsync());
        }

        // GET: AdoptionApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionApplication = await _context.AdoptionApplications
                .Include(a => a.Adopter)
                .Include(a => a.Pet)
                .FirstOrDefaultAsync(m => m.AdoptionApplicationId == id);
            if (adoptionApplication == null)
            {
                return NotFound();
            }

            return View(adoptionApplication);
        }

        // GET: AdoptionApplications/Create
        public IActionResult Create()
        {
            ViewData["AdopterId"] = new SelectList(_context.Adopters, "AdopterId", "Email");
            ViewData["PetId"] = new SelectList(_context.Pets, "PetId", "Name");
            return View();
        }

        // POST: AdoptionApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdoptionApplicationId,PetId,AdopterId,ApplicationDate,Status")] AdoptionApplication adoptionApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adoptionApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdopterId"] = new SelectList(_context.Adopters, "AdopterId", "Email", adoptionApplication.AdopterId);
            ViewData["PetId"] = new SelectList(_context.Pets, "PetId", "Name", adoptionApplication.PetId);
            return View(adoptionApplication);
        }

        // GET: AdoptionApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionApplication = await _context.AdoptionApplications.FindAsync(id);
            if (adoptionApplication == null)
            {
                return NotFound();
            }
            ViewData["AdopterId"] = new SelectList(_context.Adopters, "AdopterId", "Email", adoptionApplication.AdopterId);
            ViewData["PetId"] = new SelectList(_context.Pets, "PetId", "Name", adoptionApplication.PetId);
            return View(adoptionApplication);
        }

        // POST: AdoptionApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdoptionApplicationId,PetId,AdopterId,ApplicationDate,Status")] AdoptionApplication adoptionApplication)
        {
            if (id != adoptionApplication.AdoptionApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adoptionApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptionApplicationExists(adoptionApplication.AdoptionApplicationId))
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
            ViewData["AdopterId"] = new SelectList(_context.Adopters, "AdopterId", "Email", adoptionApplication.AdopterId);
            ViewData["PetId"] = new SelectList(_context.Pets, "PetId", "Name", adoptionApplication.PetId);
            return View(adoptionApplication);
        }

        // GET: AdoptionApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionApplication = await _context.AdoptionApplications
                .Include(a => a.Adopter)
                .Include(a => a.Pet)
                .FirstOrDefaultAsync(m => m.AdoptionApplicationId == id);
            if (adoptionApplication == null)
            {
                return NotFound();
            }

            return View(adoptionApplication);
        }

        // POST: AdoptionApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adoptionApplication = await _context.AdoptionApplications.FindAsync(id);
            if (adoptionApplication != null)
            {
                _context.AdoptionApplications.Remove(adoptionApplication);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdoptionApplicationExists(int id)
        {
            return _context.AdoptionApplications.Any(e => e.AdoptionApplicationId == id);
        }
    }
}
