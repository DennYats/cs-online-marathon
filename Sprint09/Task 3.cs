using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sprint09
{
    partial class CalcAsync
    {
        public async static Task<int> SeqAsync(int n)
        {
            return await Task.Run(() => Calc.Seq(n));
        }

        public async static void PrintSeqElementsConsequentlyAsync(int quant)
        {
            for(int i = 1; i <= quant; i++)
            {
                int res = await SeqAsync(i);
                await Task.Run(() => Console.WriteLine($"Seq[{i}] = {res}"));
            }
        }

        public async static void PrintSeqElementsInParallelAsync(int quant)
        {
            Task<int[]> task = Task.WhenAll(GetSeqAsyncTasks(quant));
            for (int i = 0; i < quant; i++)
                await Task.Run(() => Console.WriteLine($"Seq[{i + 1}] = {task.Result[i]}"));
        }

        public static Task<int>[] GetSeqAsyncTasks(int n)
        {
            Task<int>[] tasks = new Task<int>[n];
            for (int i = 0; i < n; i++)
                tasks[i] = SeqAsync(i + 1);

            return tasks;
        }
    }
}









































