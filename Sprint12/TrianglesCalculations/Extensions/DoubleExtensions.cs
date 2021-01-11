using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrianglesCalculations.Extensions
{
    public static class DoubleExtensions
    {
        public static bool EqualInPercentTo(this double value1, double value2, double epsilon)
            => Math.Abs(value1 - value2) < value1 * (epsilon / 100);

        public static bool EqualTo(this double value1, double value2, double epsilon)
           => Math.Abs(value1 - value2) < epsilon;
    }
}
