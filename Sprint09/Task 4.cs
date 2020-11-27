using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Sprint09
{
    partial class CalcAsync
    {
        public async static IAsyncEnumerable<(int, int)> SeqStreamAsync(int n)
        {
            for(int i = 1; i <= n; i++)
                yield return (i, await Task.Run(() => Calc.Seq(i)));
        }

        public async static void PrintStream(IAsyncEnumerable<(int, int)> tuple)
        {
            await foreach(var t in tuple)
                Console.WriteLine($"Seq[{t.Item1}] = {t.Item2}");
        }
    }
}
