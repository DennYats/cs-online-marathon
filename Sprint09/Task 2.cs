using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sprint09
{
    static partial class CalcAsync
    {
        public async static Task TaskPrintSeqAsync(int n)
        {
            await Task.Run(() =>
                Console.WriteLine($"Seq[{n}] = {Calc.Seq(n)}"));
        }

        public static void PrintStatusIfChanged(this Task task, ref TaskStatus prevStatus)
        {
            if (prevStatus != task.Status)
                Console.WriteLine(task.Status);
            prevStatus = task.Status;
        }

        public static void TrackStatus(this Task task)
        {
            var status = TaskStatus.Created;
            
            while (task.Status != TaskStatus.RanToCompletion && task.Status != TaskStatus.Faulted)
                task.PrintStatusIfChanged(ref status);
        }
    }
}
