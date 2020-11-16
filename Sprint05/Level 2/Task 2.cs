using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint05.Level_2
{
    class Task_2
    {
        public static Lookup<string, string> CreateNotebook(Dictionary<string, string> phonesToNames) =>
            (Lookup<string, string>)phonesToNames.ToLookup(p => p.Value ?? "", p => p.Key);
    }
}
