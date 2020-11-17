using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Sprint06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /*foreach (float item in ShowPowerRange.PowerRanger(2, 500, 2000))
                Console.WriteLine($"{item}");*/

            //Console.WriteLine(ShowPowerRange.SuperPower(2, 1000));

            /*List<Book> books = new List<Book>()
            {
                new Book("Book 1", "Author 1", 300),
                new Book("Book 2", "Author 2", 300),
                new Book("Book 3", "Author 3", 300),
                new Book("Book 4", "Author 4", 300),
                new Book("Book 5", "Author 5", 300),
                new Book("Book 6", "Author 2", 1100)
            };

            foreach(var i in MyUtils.GetFiltered(books, book => book.Author == "Author 2"))
            {
                Console.WriteLine(i.Author + " " + i.Title + " " + i.PageCount);
            }*/

            /*List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> biglist = new List<int>();

            while (biglist.Count() <= list.Count * list.Count)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    biglist.Add(list.ElementAt(i));
                }
            }

            biglist.ForEach(Console.WriteLine);

            for (int i = 0; i < biglist.Count; i++)
            {
                if (i % 3 == 1)
                {
                    Console.WriteLine($"Elem for leav{biglist.ElementAt(i)}");
                }
            }*/


            OutputUtils.ExitOutput(new CircleOfChildren(new List<string>() { "1", "2", "3", "4", "5"}), 3, 18);

            Console.ReadLine();
        }

        static int func(IEnumerable<int> source)
        {
            var col = source.ToList();
            int c = col.Count(), n = 0;
            while (2 << n <= c)
            {
                Console.WriteLine(col.ElementAt(2 * c - (2 << n)));
                ++n;
            }
            return col.ElementAt(2 * c - (2 << n));
        }
    }
}