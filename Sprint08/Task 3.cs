using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sprint08
{
    class Task_3
    {
        public static void Tasks()
        {
            int[] sequence_array = new int[10];

            Task[] tasks = new Task[3]
            {
                new Task(() =>
                {
                    for(int i = 0; i < 10; i++)
                        sequence_array[i] = i*i;
                    Console.WriteLine("Calculated!");
                }),
                new Task(() =>
                {
                    for(int i = 0; i < 10; i++)
                        Console.WriteLine(i);
                    Console.WriteLine("Bye!");
                }),
                new Task(() =>
                {
                    for(int i = 0; i < 10; i++)
                        Console.WriteLine(sequence_array[i]);
                    Console.WriteLine("Bye!");
                })
            };
            foreach (var t in tasks)
            {
                t.Start();
                t.Wait();
            }
            Task.WaitAll(tasks);
            Console.WriteLine("Main done!");
        }
    }
}
