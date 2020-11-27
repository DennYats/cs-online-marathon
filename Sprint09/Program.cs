using System;
using System.Threading.Tasks;
using System.Linq;

namespace Sprint09
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            Task[] tasks = new Task[n];
            for (int i = 0; i < n; i++)
            {
                int j = i;
                tasks[i] = new Task(() => Console.WriteLine(Math.Pow(j, 2)));
            }

            foreach (var t in tasks)
            {
                t.Start();
                t.Wait();
            }

            Console.Read();
        }
    }
}
