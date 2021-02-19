using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Products.Controllers
{
    public class TasksController : Controller
    {
        private List<string> listOfMarkets = new List<string> { "WellMart", "Silpo", "ATB", "Furshet", "Metro" };
        private Dictionary<string, int> shoppingList = new Dictionary<string, int>
            {
                { "Milk", 2 },
                { "Bread", 2 },
                { "Cake", 1 },
                { "Ice Cream", 5 },
                { "Cola", 10 }
            };

        [HttpGet]
        public IActionResult SprintTasks()
        {
            ViewData["Title"] = nameof(SprintTasks);
            return View();
        }

        [HttpGet]
        public IActionResult Greetings()
        {
            ViewBag.Greeting =
                DateTime.Now.Hour < 12 ? "Good Morning" :
                DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18 ? "Good Afternoon"
                : "Good Evening";
            ViewBag.Date = DateTime.Now;

            ViewData["Title"] = nameof(Greetings);
            return View();
        }

        [HttpGet]
        public IActionResult ProductInfo()
        {
            ViewData["Title"] = nameof(ProductInfo);
            return View();
        }

        [HttpGet]
        public IActionResult SuperMarkets()
        {
            ViewBag.Markets = listOfMarkets;

            ViewData["Title"] = nameof(SuperMarkets);
            return View();
        }

        [HttpGet]
        public IActionResult ShoppingList()
        {
            ViewData["Title"] = nameof(ShoppingList);
            return View(shoppingList);
        }

        [HttpGet]
        public IActionResult ShoppingCart()
        {
            ViewBag.Markets = listOfMarkets;
            ViewBag.Products = shoppingList.Keys;
            ViewData["Title"] = nameof(ShoppingCart);
            return View();
        }

        [HttpPost]
        public IActionResult ShoppingCart(string fullname, string address, string date)
        {
            //Request.Form["Markets"]
            //Request.Form["Markets"]
            return Content($"Your products will be shipped {date} at: {address}. Bon appetite, {fullname}");
        }
    }
}
