using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sprint11.Task5
{
    public class ReflectFullClass
    {
        public static void WriteAllInClass(Type type)
        {
            var NameOfType = type.Name;
            Console.WriteLine($"Hello, {NameOfType}!");

            var fields = type.GetFields();
            Console.WriteLine($"There are {fields.Length} fields in {NameOfType}:");
            foreach (var f in fields)
                Console.Write(f.Name + ", ");

            Console.WriteLine();

            
            var properties = type.GetProperties();
            Console.WriteLine($"There are {properties.Length} properties in {NameOfType}:");
            foreach (var p in properties)
                Console.Write(p.Name + ", ");

            Console.WriteLine();

            var methods = type.GetMethods(BindingFlags.DeclaredOnly
                                      | BindingFlags.Instance
                                      | BindingFlags.NonPublic
                                      | BindingFlags.Public
                                      | BindingFlags.Static)
                               .Where(m => !m.IsSpecialName);
            Console.WriteLine($"There are {methods.Count()} methods in {NameOfType}:");
            foreach (var m in methods)
                Console.Write(m.Name + ", ");

            Console.WriteLine();

            var interfaces = type.GetNestedTypes();
            Console.WriteLine($"There are {interfaces.Length} interfaces in {NameOfType}:");
            foreach (var i in interfaces)
                Console.Write(i.Name + ", ");
        }
    }
}
