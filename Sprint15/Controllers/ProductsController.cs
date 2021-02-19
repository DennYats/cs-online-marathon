using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsValidation.Models;
using ProductsValidation.Services;

namespace ProductsValidation.Controllers
{
    public class ProductsController : Controller
    {
        private List<Product> myProducts;

        public ProductsController(Data data)
        {
            myProducts = data.Products;
        }
        
        public IActionResult Index(int filterId, string filtername)
        {
            return View(myProducts);
        }
        
        public IActionResult View(int id)
        {
            Product prod = myProducts.Find(prod => prod.Id == id);
            if (prod != null)
            {
                return View(prod);
            }

            return View("NotExists");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product prod = myProducts.Find(prod => prod.Id == id);
            if (prod != null)
            {
                return View(prod);
            }

            return View("NotExists");
        } 
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            myProducts[myProducts.FindIndex(prod => prod.Id == product.Id)] = product;

            return RedirectToAction("Index", myProducts);
        }

        [HttpGet]
        public IActionResult EditCategory(Product.Category category)
        {
            var list = myProducts.Where(p => p.Type == category).ToList();
            return View(list);
        }

        [HttpPost]
        public IActionResult EditCategory(List<Product> products)
        {
            for (int i = 0; i < products.Count(); i++)
            {
                myProducts[myProducts.FindIndex(p => p.Id == products.ElementAt(i).Id)] = products.ElementAt(i);
            }

            return RedirectToAction("Index", myProducts);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            myProducts.Add(product);
            return View("View", product);
        }

        public IActionResult Create()
        {
            return View(new Product(){Id = myProducts.Last().Id + 1});
        }

        public IActionResult Delete(int id)
        {
            myProducts.Remove(myProducts.Find(product => product.Id == id));
            return RedirectToAction("Index", myProducts);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult ValidDescription(string name, string description)
        {
            if(name != null)
                if (!description.StartsWith(name) && description.Length > 1 || description.Trim() == name)
                    return Json("Description should start with Name and continue");

            return Json(true);
        }
    }
}
