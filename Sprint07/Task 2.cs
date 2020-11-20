using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint07
{
    class Task_2
    {
        public static double EvaluateAggregate(double[] inputData, Func<double, double, double> aggregate, Func<double, int, bool> predicate) =>
            inputData.Where(predicate).Aggregate(aggregate);
    }
}