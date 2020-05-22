using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using market;

namespace market.Controllers
{
    public class MarketsController : Controller
    {
        private readonly MarketDb1Context _context;

        public MarketsController(MarketDb1Context context)
        {
            _context = context;
        }

        // GET: Markets
        public async Task<IActionResult> Index()
        {
            var marketDb1Context = _context.Markets.Include(m => m.Category);
            return View(await marketDb1Context.ToListAsync());
        }

        // GET: Markets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markets = await _context.Markets
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (markets == null)
            {
                return NotFound();
            }

            return View(markets);
        }

        // GET: Markets/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Markets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CategoryId")] Markets markets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(markets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", markets.CategoryId);
            return View(markets);
        }

        // GET: Markets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markets = await _context.Markets.FindAsync(id);
            if (markets == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", markets.CategoryId);
            return View(markets);
        }

        // POST: Markets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CategoryId")] Markets markets)
        {
            if (id != markets.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(markets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarketsExists(markets.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", markets.CategoryId);
            return View(markets);
        }

        // GET: Markets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markets = await _context.Markets
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (markets == null)
            {
                return NotFound();
            }

            return View(markets);
        }

        // POST: Markets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var markets = await _context.Markets.FindAsync(id);
            _context.Markets.Remove(markets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarketsExists(int id)
        {
            return _context.Markets.Any(e => e.Id == id);
        }
    }
}
