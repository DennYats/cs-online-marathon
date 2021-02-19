using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Data;
using ShoppingSystem.Models;
using ShoppingSystem.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSystem.Controllers
{
    public class SupermarketsController : Controller
    {
        private readonly ISupermarkets _supermarkets;

        public SupermarketsController(ISupermarkets supermarkets)
        {
            _supermarkets = supermarkets;
        }

        // GET: Supermarkets
        public async Task<IActionResult> Index()
        {
            return View(await _supermarkets.GetAllAsync());
        }

        // GET: Supermarkets/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                return View(await _supermarkets.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: Supermarkets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supermarkets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address")] Supermarket supermarket)
        {
            if (ModelState.IsValid)
            {
                await _supermarkets.AddAsync(supermarket);
                return RedirectToAction(nameof(Index));
            }
            return View(supermarket);
        }

        // GET: Supermarkets/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                return View(await _supermarkets.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: Supermarkets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address")] Supermarket supermarket)
        {
            try
            {
                await _supermarkets.EditAsync(supermarket);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Supermarkets/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _supermarkets.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Supermarkets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _supermarkets.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
