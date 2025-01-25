using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFCRUD.DAL;

namespace EFCRUD.Controllers
{
    public class ilYonetimiController : Controller
    {
        private readonly DbefcrudContext _context;

        public ilYonetimiController()
        {
            _context = new DbefcrudContext();
        }

        // GET: ilYonetimi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Illers.ToListAsync());
        }

        // GET: ilYonetimi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iller = await _context.Illers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iller == null)
            {
                return NotFound();
            }

            return View(iller);
        }

        // GET: ilYonetimi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ilYonetimi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sehir")] Iller iller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iller);
        }

        // GET: ilYonetimi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iller = await _context.Illers.FindAsync(id);
            if (iller == null)
            {
                return NotFound();
            }
            return View(iller);
        }

        // POST: ilYonetimi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sehir")] Iller iller)
        {
            if (id != iller.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IllerExists(iller.Id))
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
            return View(iller);
        }

        // GET: ilYonetimi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iller = await _context.Illers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iller == null)
            {
                return NotFound();
            }

            return View(iller);
        }

        // POST: ilYonetimi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iller = await _context.Illers.FindAsync(id);
            if (iller != null)
            {
                _context.Illers.Remove(iller);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IllerExists(int id)
        {
            return _context.Illers.Any(e => e.Id == id);
        }
    }
}
