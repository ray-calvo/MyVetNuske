using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyVetNuske.Web.Data;
using MyVetNuske.Web.Data.Entities;

namespace MyVetNuske.Web.Controllers
{
    public class RaceTypesController : Controller
    {
        private readonly DataContext _context;

        public RaceTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: RaceTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RaceTypes.ToListAsync());
        }

        // GET: RaceTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceType = await _context.RaceTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raceType == null)
            {
                return NotFound();
            }

            return View(raceType);
        }

        // GET: RaceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RaceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] RaceType raceType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raceType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raceType);
        }

        // GET: RaceTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceType = await _context.RaceTypes.FindAsync(id);
            if (raceType == null)
            {
                return NotFound();
            }
            return View(raceType);
        }

        // POST: RaceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] RaceType raceType)
        {
            if (id != raceType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raceType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceTypeExists(raceType.Id))
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
            return View(raceType);
        }

        // GET: RaceTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceType = await _context.RaceTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raceType == null)
            {
                return NotFound();
            }

            return View(raceType);
        }

        // POST: RaceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raceType = await _context.RaceTypes.FindAsync(id);
            _context.RaceTypes.Remove(raceType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaceTypeExists(int id)
        {
            return _context.RaceTypes.Any(e => e.Id == id);
        }
    }
}
