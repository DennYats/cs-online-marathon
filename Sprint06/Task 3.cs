using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint06
{
    class ShowPower
    {
        public static IEnumerable<float> SuperPower(float number, float degree)
        {
            float result = 1;
            if (number == 0) yield return 0;
            else if (degree == 0) yield return 1;
            else if (degree > 0)
            {
                for (int i = 0; i < degree; i++)
                {
                    yield return result *= number;
                }
            }
            else if (degree < 0)
            {
                for (int i = 0; i > degree; i--)
                {
                    yield return result /= number;
                }
            }
        }
    }
}
