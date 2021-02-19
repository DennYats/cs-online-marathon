using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Data;
using ShoppingSystem.Models;
using ShoppingSystem.Services;

namespace ShoppingSystem.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrders _orders;

        public OrdersController(IOrders orders)
        {
            _orders = orders;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _orders.GetAllAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                return View(await _orders.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
    		return View();
        }

        // POST: Orders/Create
        
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,SupermarketId,OrderDate")] Order order)
        {
            try
            {
                await _orders.AddAsync(order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                return View(await _orders.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: Orders/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,SupermarketId,OrderDate")] Order order)
        {
            try
            {
                await _orders.EditAsync(order);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _orders.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _orders.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}
