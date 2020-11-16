using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint05.Level_2
{
    public class MyUtils
    {
        public static bool ListDictionaryCompare(List<string> list, Dictionary<string, string> dictionary) =>
            new List<string>(dictionary.Values.OrderBy(o => o).Distinct().ToList())
            .SequenceEqual(list.OrderBy(o => o).Distinct().ToList());
    }
}
