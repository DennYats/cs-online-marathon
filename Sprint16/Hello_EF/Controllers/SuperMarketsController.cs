using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hello_EF.Models;
using Hello_EF.ViewModels;

namespace Hello_EF.Controllers
{
    public class SuperMarketsController : Controller
    {
        private readonly ShoppingContext _context;
        

        public SuperMarketsController(ShoppingContext context)
        {
            _context = context;
        }

        // GET: SuperMarkets
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 2;
            
            var count = await _context.SuperMarkets.CountAsync();
            var items = await _context.SuperMarkets.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                SuperMarkets = items                
            };

            return View(viewModel);
        }

        // GET: SuperMarkets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superMarket = await _context.SuperMarkets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superMarket == null)
            {
                return NotFound();
            }

            return View(superMarket);
        }

        // GET: SuperMarkets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuperMarkets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address")] SuperMarket superMarket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superMarket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superMarket);
        }

        // GET: SuperMarkets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superMarket = await _context.SuperMarkets.FindAsync(id);
            if (superMarket == null)
            {
                return NotFound();
            }
            return View(superMarket);
        }

        // POST: SuperMarkets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address")] SuperMarket superMarket)
        {
            if (id != superMarket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superMarket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperMarketExists(superMarket.Id))
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
            return View(superMarket);
        }

        // GET: SuperMarkets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superMarket = await _context.SuperMarkets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superMarket == null)
            {
                return NotFound();
            }

            return View(superMarket);
        }

        // POST: SuperMarkets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var superMarket = await _context.SuperMarkets.FindAsync(id);
            _context.SuperMarkets.Remove(superMarket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperMarketExists(int id)
        {
            return _context.SuperMarkets.Any(e => e.Id == id);
        }
    }
}
