using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint05.Level_2
{
    class Task_3
    {
        public static Dictionary<string, List<string>> ReverseNotebook(Dictionary<string, string> phonesToNames) =>
            ((Lookup<string, string>)phonesToNames.ToLookup(p => p.Value ?? "", p => p.Key))
            .ToDictionary(p => p.Key, p => p.ToList());
    }
}
