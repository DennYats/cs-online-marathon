using System.Collections.Generic;
using System.Linq;

namespace Sprint03.Task_4
{
    public static class IListExtensions
    {
        public static List<int> IncreaseWith(this List<int> list, int x)
        {
            for (var i = 0; i < list.Count; i++)
                list[i] += x;
            return list;
        }
    }

    public static class IEnumerableExtensions
    {
        public static string ToString<T>(this List<T> list) =>
            "[" + string.Join(", ", list) + "]";
    }
}
