using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sprint07
{
    class Task_3
    {
        public static int ProductWithCondition(List<int> list, Func<int, bool> condition) =>
            list.Where(condition).Count() == 0
            ? 1
            : list.Where(condition).Aggregate((total, next) => total * next);
    }
}