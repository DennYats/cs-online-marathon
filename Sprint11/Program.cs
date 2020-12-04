using Sprint11.Task1;
using Sprint11.Task2;
using System;
using System.Collections.Generic;
using static Sprint11.Task4.ReflectorAssembly;

namespace Sprint11
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> sizes = new Dictionary<string, string>
            {
                { typeof(LargeBox).Name, "large" },
                { typeof(Box).Name, "middle" },
                { typeof(SmallBox).Name, "small" }
            };

            foreach(var i in sizes)
                Console.WriteLine(i.Key + " " + i.Value);

            Console.Read();
        }
    }
}
