using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sprint11.Task2
{
    public class ReflectMethod
    {
        public static class Methods
        {
            public static void Hello(string parameter) =>
                Console.WriteLine($"Hello:parameter={parameter}");
            public static void Welcome(string parameter) =>
                Console.WriteLine($"Welcome:parameter={parameter}");
            public static void Bye(string parameter) =>
                Console.WriteLine($"Bye:parameter={parameter}");
        }

        public static void InvokeMethod(string[] array)
        {
            foreach (var method in typeof(Methods).GetMethods(BindingFlags.DeclaredOnly
                                                            | BindingFlags.Public
                                                            | BindingFlags.Static))
                for(int i = 0; i < array.Length; i++)
                    method.Invoke(typeof(Methods), new[] { array[i] });
        }
    }
}
