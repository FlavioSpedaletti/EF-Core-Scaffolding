using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using teste.Data;
using teste.Models;

namespace teste.Controllers
{
    public class UFsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UFsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UFs
        public async Task<IActionResult> Index()
        {
            return View(await _context.UF.ToListAsync());
        }

        // GET: UFs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uF = await _context.UF
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uF == null)
            {
                return NotFound();
            }

            return View(uF);
        }

        // GET: UFs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UFs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] UF uF)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uF);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uF);
        }

        // GET: UFs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uF = await _context.UF.FindAsync(id);
            if (uF == null)
            {
                return NotFound();
            }
            return View(uF);
        }

        // POST: UFs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] UF uF)
        {
            if (id != uF.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uF);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UFExists(uF.Id))
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
            return View(uF);
        }

        // GET: UFs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uF = await _context.UF
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uF == null)
            {
                return NotFound();
            }

            return View(uF);
        }

        // POST: UFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uF = await _context.UF.FindAsync(id);
            _context.UF.Remove(uF);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UFExists(int id)
        {
            return _context.UF.Any(e => e.Id == id);
        }
    }
}
