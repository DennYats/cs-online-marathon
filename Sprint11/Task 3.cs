using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sprint11.Task3
{
    public class ReflectProperties
    {
        public class TestProperties
        {
            public string FirstName { get; set; }
            internal string LastName { get; set; }
            protected int Age { get; set; }
            private string PhoneNumber { get; set; }
        }

        public static void WriteProperties()
        {
            foreach(var property in typeof(TestProperties).GetProperties(BindingFlags.DeclaredOnly
                                                                        | BindingFlags.Instance
                                                                        | BindingFlags.NonPublic
                                                                        | BindingFlags.Public
                                                                        | BindingFlags.Static))
            {
                bool read_write = false;
                if (property.CanRead && property.CanWrite) read_write = true;

                string accessModifier = property.GetSetMethod(true).IsPublic ? "Public" :
                                        property.GetSetMethod(true).IsAssembly ? "Internal" :
                                        property.GetSetMethod(true).IsFamily ? "Protected" :
                                        property.GetSetMethod(true).IsFamilyOrAssembly ? "Protected Internal" :
                                        property.GetSetMethod(true).IsFamilyAndAssembly ? "Private Protected" :
                                        property.GetSetMethod(true).IsPrivate ? "Private" :
                                        "";

                Console.WriteLine($"Property name: {property.Name}");
                Console.WriteLine($"Property type: {property.PropertyType}");
                Console.WriteLine($"Read-Write:    {read_write}");
                Console.WriteLine($"Accessibility level: {accessModifier}");
                Console.WriteLine();
            }
        }
    }
}
