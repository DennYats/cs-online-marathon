using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductsWithRouting.Models;
using ProductsWithRouting.Services;

namespace ProductsWithRouting.Controllers
{
    public class ProductsController : Controller
    {
        private List<Product> myProducts;

        public ProductsController(Data data)
        {
            myProducts = data.Products;
        }

        public IActionResult Index(int? filterId, string? filtername)
        {
            var res = View();

            if (filterId == null && filtername == null)
                res = View(myProducts);
            else
                res = View(myProducts.Where(p => p.Id == filterId || p.Name == filtername));

            return res;
        }

        public IActionResult View(int id)
        {
            if (!myProducts.Exists(p => p.Id == id))
            {
                return View("404");
            }
            var product = myProducts.First(p => p.Id == id);
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!myProducts.Exists(p => p.Id == id))
            {
                return View("404");
            }
            var product = myProducts.First(p => p.Id == id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            myProducts[myProducts.FindIndex(p => p.Id == product.Id)] = product;

            return RedirectToAction("Index");
        }

        [Route("[controller]/[action]")]
        [Route("[controller]/new")]
        [HttpGet]
        public IActionResult Create()
        {
            Product product = new Product();
            product.Id = myProducts.Max(p => p.Id) + 1;
            product.Name = string.Empty;
            product.Description = string.Empty;

            return View(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            myProducts.Add(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!myProducts.Exists(p => p.Id == id))
            {
                return View("404");
            }
            myProducts.Remove(myProducts.First(p => p.Id == id));
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
