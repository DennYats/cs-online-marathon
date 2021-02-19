using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Data;
using ShoppingSystem.Models;
using System.Linq;
using System.Threading.Tasks;
using ShoppingSystem.Services;

namespace ShoppingSystem.Controllers
{
    public class CustomersController : Controller
    {
        // private readonly ShoppingContext context;
        public readonly ICustomers _customers;

        public CustomersController(ICustomers customers)
        {
            _customers = customers;
        }

        // GET: Customers
        public async Task<IActionResult> Index(string searchString, SortState sortOrder = SortState.LastNameAsc)
        {
            var customers = from c in await _customers.GetAllAsync()
                select c;

            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.LastName.Contains(searchString)
                                                 || s.FirstName.Contains(searchString));
            }

            ViewData["LastNameSort"] =
                sortOrder == SortState.LastNameAsc ? SortState.LastNameDesc : SortState.LastNameAsc;
            ViewData["AddressSort"] = sortOrder == SortState.AddressAsc ? SortState.AddressDesc : SortState.AddressAsc;

            customers = sortOrder switch
            {
                SortState.LastNameDesc => customers.OrderByDescending(c => c.LastName),
                SortState.AddressAsc => customers.OrderBy(c => c.Address),
                SortState.AddressDesc => customers.OrderByDescending(c => c.Address),
                _ => customers.OrderBy(c => c.LastName),
            };
            return View(customers);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                return View(await _customers.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,Discount")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customers.AddAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customers.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,Discount")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _customers.EditAsync(customer);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest();
                }
             }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customers.GetByIdAsync(id);
                
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _customers.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
    }
}
