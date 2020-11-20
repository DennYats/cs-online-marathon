using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sprint07
{
    class Task_1
    {
        public static double EvaluateSumOfElementsOddPositions(double[] inputData) =>
            inputData.Where((value, index) => index % 2 != 0).ToArray().Sum();
    }
}
