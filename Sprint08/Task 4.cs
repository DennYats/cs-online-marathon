using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sprint08
{
    class MyProgram
    {
        static object locker = new object();
        public static void Counter(int x)
        {
            Thread FactorialThread = new Thread(new ParameterizedThreadStart(Factorial));
            FactorialThread.Start(x);

            Thread FibonacciThread = new Thread(new ParameterizedThreadStart(Fibonacci));
            FibonacciThread.Start(x);
        }

        private static void Factorial(object x)
        {
            lock (locker)
            {
                int res = 1;
                int number = (int)x;
                for (int i = 1; i <= number; i++)
                {
                    res *= i;
                }
                Console.WriteLine($"Factorial is: {res}");
            }
        }

        private static void Fibonacci(object x)
        {
            lock (locker)
            {
                int number = (int)x;
                int p = 0;
                int q = 1;
                for (int i = 0; i < number; i++)
                {
                    int temp = p;
                    p = q;
                    q = temp + q;
                }
                Console.WriteLine($"Fibbonaci number is: {p}");
            }
        }

        private static int FibonacciSeries(int n)
        {
            if (n == 0) return 0; //To return the first Fibonacci number   
            if (n == 1) return 1; //To return the second Fibonacci number   
            return (FibonacciSeries(n - 1) + FibonacciSeries(n - 2));
        }
    }
}
