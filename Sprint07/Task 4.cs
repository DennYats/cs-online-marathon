using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint07
{
    class Task_4
    {
        public static string GetWord(string input, string seed)
        {
            string longestWord = input.Split(' ')
                                 .Aggregate(seed, (longest, next) =>
                                    next.Length > longest.Length ? next : longest,
                                 inp => inp.ToLower());

            return  longestWord.Contains('a')
                    ? longestWord.Substring(longestWord.IndexOf('a'))
                    : "";
        }
    }
}
