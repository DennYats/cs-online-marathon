using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sprint09
{
    partial class CalcAsync
    {
        public async static void PrintSeqAsync(int n) =>
            await Task.Run(() =>
                Console.WriteLine($"Seq[{n}] = {Calc.Seq(n)}"));
    }
}

