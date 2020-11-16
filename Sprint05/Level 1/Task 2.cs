using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint05.Level_1
{
    public class MyProgram1
    {
        public static void SearchKeys(Dictionary<string, string> persons)
        {
            var arrayOfKeys = persons.Select(k => k.Key);
            foreach (var i in arrayOfKeys)
                Console.WriteLine(i);
        }

        public static void SearchValues(Dictionary<string, string> persons)
        {
            var arrayOfValues = persons.Select(v => v.Value);
            foreach (var i in arrayOfValues)
                Console.WriteLine(i);
        }

        public static void SearchAdmin(Dictionary<string, string> persons)
        {
            var admin = persons.Where(a => a.Value == "Admin").Select(a => a);
            foreach (var i in admin)
                Console.WriteLine(i.Key + " " + i.Value);
        }
    }
}
