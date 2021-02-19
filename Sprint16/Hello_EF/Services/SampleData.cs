using Hello_EF.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hello_EF.Services
{
    public class SampleData
    {
        public static void Initialize(ShoppingContext db)
        {
            Customer den = new Customer { FirstName = "DennY", LastName = "Yats", Address = "Shevchenka, 42", Discount = 100 };
            Customer stas = new Customer { FirstName = "Stas", LastName = "Semenchuk", Address = "Molodijna, 4", Discount = 100 };
            Customer vova = new Customer { FirstName = "Volodymyr", LastName = "Zelensky", Address = "Nezalejnosti, 28", Discount = 100 };

            SuperMarket metro = new SuperMarket { Name = "METRO", Address = "Ostapa Vil'shyny St. 1D" };
            SuperMarket ozzy = new SuperMarket { Name = "OZZY", Address = "14a, Nebesnoyi sotni St" };

            Product cheese = new Product { Name = "Cheese", Price = 30 };
            Product sausage = new Product { Name = "Sausage", Price = 50 };
            Product milk = new Product { Name = "Milk", Price = 15 };

            Order order1 = new Order { Customer = den, SuperMarket = metro, Order_date = DateTime.Today };
            Order order2 = new Order { Customer = stas, SuperMarket = ozzy, Order_date = DateTime.Today };

            OrderDetails order1Details1 = new OrderDetails { Order = order1, Product = cheese, Quantity = 1 };
            OrderDetails order1Details2 = new OrderDetails { Order = order1, Product = sausage, Quantity = 2 };
            OrderDetails order1Details3 = new OrderDetails { Order = order1, Product = milk, Quantity = 1 };
            OrderDetails order2Details1 = new OrderDetails { Order = order2, Product = milk, Quantity = 3 };
            OrderDetails order2Details2 = new OrderDetails { Order = order2, Product = cheese, Quantity = 1 };

            if (!db.Customers.Any()) db.Customers.AddRange(den, stas, vova);
            if (!db.SuperMarkets.Any()) db.SuperMarkets.AddRange(metro, ozzy);
            if (!db.Products.Any()) db.Products.AddRange(cheese, sausage, milk);
            if (!db.Orders.Any()) db.Orders.AddRange(order1, order2);
            if (!db.OrderDetails.Any()) db.OrderDetails.AddRange(order1Details1, order1Details2, order1Details3, order2Details1, order2Details2);

            db.SaveChanges();
        }
    }
}
