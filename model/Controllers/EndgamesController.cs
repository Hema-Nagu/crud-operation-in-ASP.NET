#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using model.Data;
using model.Models;

namespace model.Controllers
{
    public class EndgamesController : Controller
    {
        private readonly modelContext _context;

        public EndgamesController(modelContext context)
        {
            _context = context;
        }

        // GET: Endgames
        public async Task<IActionResult> Index()
        {
            return View(await _context.Endgames.ToListAsync());
        }

        // GET: Endgames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endgame = await _context.Endgames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endgame == null)
            {
                return NotFound();
            }

            return View(endgame);
        }

        // GET: Endgames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Endgames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NoOfKills")] Endgame endgame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(endgame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(endgame);
        }

        // GET: Endgames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endgame = await _context.Endgames.FindAsync(id);
            if (endgame == null)
            {
                return NotFound();
            }
            return View(endgame);
        }

        // POST: Endgames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NoOfKills")] Endgame endgame)
        {
            if (id != endgame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(endgame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EndgameExists(endgame.Id))
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
            return View(endgame);
        }

        // GET: Endgames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endgame = await _context.Endgames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endgame == null)
            {
                return NotFound();
            }

            return View(endgame);
        }

        // POST: Endgames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var endgame = await _context.Endgames.FindAsync(id);
            _context.Endgames.Remove(endgame);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EndgameExists(int id)
        {
            return _context.Endgames.Any(e => e.Id == id);
        }
    }
}
