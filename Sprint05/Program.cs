using Sprint05.Level_3;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprint05
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            List<Student> list1 = new List<Student>()
            {
                new Student(1, "Ivan"),
                new Student(2, "Petro"),
                new Student(3, "Stepan"),
                new Student(5, null)
            };

            List<Student> list2 = new List<Student>()
            {
                new Student(1, "Ivan"),
                new Student(3, "Stepan"),
                new Student(4, "Andriy"),
                new Student(5, null)
            };

            List<int> list22 = new List<int>()
            {
                1, 2, 3
            };
            List<int> list33 = new List<int>()
            {
                1, 3, 4
            };

            var list4 = list1.Intersect(list2).ToList();

            /*foreach (Student student in list4)
                Console.WriteLine(student.Id + " " + student.Name);*/

            Student.GetCommonStudents(list1, list2);

            Console.ReadLine();
        }
    }
}
