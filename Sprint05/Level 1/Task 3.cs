using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint05.Level_1
{
    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public static void TotalPrice(ILookup<string, Product> lookup)
        {
            var price = lookup.Select(a => a);
            foreach (var category in lookup)
            {
                foreach(var item in category)
                {
                    Console.WriteLine(item.Name + " " + item.Price);
                }
                Console.WriteLine(category.Key + " " + category.Sum(s => s.Price));
            }
        }
    }
}