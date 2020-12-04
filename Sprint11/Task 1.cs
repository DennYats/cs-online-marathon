using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Sprint11.Task1
{
    public class ReflectFields
    {
        public static string Name;
        public static int MeasureX;
        public static int MeasureY;
        public static int MeasureZ;

        public static void OutputFields()
        {
            foreach(var field in typeof(ReflectFields).GetFields())
                Console.WriteLine($"{field.Name} ({SimTypeName(field.FieldType)}) = {field.GetValue(null)}");
        }

        static string SimTypeName(Type type)
        {
            Dictionary<Type, string> typeAlias = new Dictionary<Type, string>
            {
                { typeof(string), "string" },
                { typeof(int), "int" }
            };

            if (typeAlias.TryGetValue(type, out string alias))
                return alias;

            return type.Name;
        }
    }
}
