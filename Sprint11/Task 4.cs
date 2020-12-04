using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Sprint11.Task4
{
    public class ReflectorAssembly
    {
        public class LargeBox
        {
            public static void UnPackingBox(string size) =>
                Console.WriteLine($"I am unpacking {size} box.");

            public static void InBox(string size) =>
                Console.WriteLine($"I am in {size} box.");
        }
        public class Box
        {
            public static void UnPackingBox(string size) =>
                Console.WriteLine($"I am unpacking {size} box.");

            public static void InBox(string size) =>
                Console.WriteLine($"I am in {size} box.");
        }
        public class SmallBox
        {
            public static void UnPackingBox(string size) =>
                Console.WriteLine($"I am unpacking {size} box.");

            public static void InBox(string size) =>
                Console.WriteLine($"I am in {size} box.");
        }

        public interface ILookingForBox
        {
            static void LookForBox(string param) { }
        }

        public interface IPackingBox
        {
            static void PackBox(string param) { }
        }

        public static void WriteAssemblies()
        {
            Dictionary<string, string> sizes = new Dictionary<string, string>
            {
                { typeof(LargeBox).Name, "large" },
                { typeof(Box).Name, "middle" },
                { typeof(SmallBox).Name, "small" },
                { typeof(ILookingForBox).Name, "look" },
                { typeof(IPackingBox).Name, "pack" }
            };

            Assembly asm = Assembly.GetCallingAssembly();
            foreach (var t in asm.GetTypes().Except(new Type[] { typeof(Task), typeof(Reflector) }))
            {
                string isType = t.IsClass ? "Class" : 
                                t.IsInterface ? "Interface" :
                                "";
                Console.WriteLine($"{isType}: {t.Name}");

                foreach (var m in t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static))
                {
                    Console.WriteLine($"Method: {m.Name}");
                    if(m.GetParameters().Length == 1)
                        m.Invoke(null, new[] { sizes[t.Name] });
                }
            }
        }
    }
    class Task { }
    class Reflector { }
}
