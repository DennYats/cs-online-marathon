using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint06
{
    public class ShowPowerRange
    {
        public static IEnumerable<float> PowerRanger(float degree, float start, float finish)
        {
            if (start > finish || start < 0 || finish < 0) yield return 0;
            else if (degree == 0) yield return 1;
            else if (start > 0 && finish > 0 && degree > 0)
            {
                start = (float)Math.Round(Math.Pow(start, 1.0 / degree));
                    
                while (Math.Pow(start, degree) <= finish)
                {
                    yield return (float)Math.Pow(start, degree);
                    start++;
                }
            }
        }
    }
}