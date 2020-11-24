using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sprint08
{
    class MainThreadProgram
    {
        public static void Sum()
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= 5; i++)
            {
                switch (i)
                {
                    case 1:
                        Console.WriteLine($"Enter the {i}st number:");
                        break;
                    case 2:
                        Console.WriteLine($"Enter the {i}nd number:");
                        break;
                    case 3:
                        Console.WriteLine($"Enter the {i}rd number:");
                        break;
                    default:
                        Console.WriteLine($"Enter the {i}th number:");
                        break;
                }
                list.Add(Convert.ToInt32(Console.ReadLine()));
            }
            Console.WriteLine($"Sum is: {list.Sum()}");
        }

        public static void Product()
        {
            List<int> list = Enumerable.Range(1, 10).ToList();
            Thread.Sleep(10000);
            Console.WriteLine($"Product is: {list.Aggregate((x, y) => x * y)}");
        }

        public static (Thread, Thread) Calculator()
        {
            Thread sumThread = new Thread(Sum);
            Thread productThread = new Thread(Product);

            sumThread.Start();
            productThread.Start();

            return (sumThread, productThread);
        }
    }
}
