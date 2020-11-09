using Sprint03.Task_4;
using System;
using System.Collections.Generic;

namespace Sprint03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> l = new List<int> { 1, 2, 3, 4, 5 };
            l.IncreaseWith(5);
            Console.WriteLine(l.ToString<int>());
        }
    }
}
