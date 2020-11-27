using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint09
{
    partial class CalcAsync
    {
        public async static void PrintSpecificSeqElementsAsync(int[] array)
        {
            List<Task> listOfTasks = new List<Task>();

            Task allTasks = null;

            for (int i = 0; i < array.Length; i++)
            {
                var index = array[i];
                var task = new Task(() => Console.WriteLine($"Seq[{index}] = {Calc.Seq(index)}"));
                listOfTasks.Add(task);
                task.Start();
            }

            try
            {
                allTasks = Task.WhenAll(listOfTasks.ToArray());
                await allTasks;
            }
            catch (Exception ex)
            {
                foreach(var inx in allTasks.Exception.InnerExceptions)
                    Console.WriteLine($"Inner exception: {inx.Message}");
            }
        }
    }
}
