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
    public class OwnerMarketsController : Controller
    {
        private readonly MarketDb1Context _context;

        public OwnerMarketsController(MarketDb1Context context)
        {
            _context = context;
        }

        // GET: OwnerMarkets
        public async Task<IActionResult> Index()
        {
            var marketDb1Context = _context.OwnerMarket.Include(o => o.Market).Include(o => o.Owner);
            return View(await marketDb1Context.ToListAsync());
        }

        // GET: OwnerMarkets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerMarket = await _context.OwnerMarket
                .Include(o => o.Market)
                .Include(o => o.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ownerMarket == null)
            {
                return NotFound();
            }

            return View(ownerMarket);
        }

        // GET: OwnerMarkets/Create
        public IActionResult Create()
        {
            ViewData["MarketId"] = new SelectList(_context.Markets, "Id", "Name");
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Name");
            return View();
        }

        // POST: OwnerMarkets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OwnerId,MarketId")] OwnerMarket ownerMarket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ownerMarket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarketId"] = new SelectList(_context.Markets, "Id", "Name", ownerMarket.MarketId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Name", ownerMarket.OwnerId);
            return View(ownerMarket);
        }

        // GET: OwnerMarkets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerMarket = await _context.OwnerMarket.FindAsync(id);
            if (ownerMarket == null)
            {
                return NotFound();
            }
            ViewData["MarketId"] = new SelectList(_context.Markets, "Id", "Name", ownerMarket.MarketId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Name", ownerMarket.OwnerId);
            return View(ownerMarket);
        }

        // POST: OwnerMarkets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OwnerId,MarketId")] OwnerMarket ownerMarket)
        {
            if (id != ownerMarket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ownerMarket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerMarketExists(ownerMarket.Id))
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
            ViewData["MarketId"] = new SelectList(_context.Markets, "Id", "Name", ownerMarket.MarketId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Name", ownerMarket.OwnerId);
            return View(ownerMarket);
        }

        // GET: OwnerMarkets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerMarket = await _context.OwnerMarket
                .Include(o => o.Market)
                .Include(o => o.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ownerMarket == null)
            {
                return NotFound();
            }

            return View(ownerMarket);
        }

        // POST: OwnerMarkets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ownerMarket = await _context.OwnerMarket.FindAsync(id);
            _context.OwnerMarket.Remove(ownerMarket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerMarketExists(int id)
        {
            return _context.OwnerMarket.Any(e => e.Id == id);
        }
    }
}
