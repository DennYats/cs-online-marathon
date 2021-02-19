using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Data;
using ShoppingSystem.Models;
using ShoppingSystem.Services;

namespace ShoppingSystem.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts _products;

        public ProductsController(IProducts products)
        {
            _products = products;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _products.GetAllAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                return View(await _products.GetByIdAsync(id));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]

        public async Task<IActionResult> Create([Bind("Id,Name,Price")] Product product)
        {
            try
            {
                await _products.AddAsync(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                return View(await _products.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: Products/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] Product product)
        {
            try
            {
                await _products.EditAsync(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _products.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _products.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }
    }

}
