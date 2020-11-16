using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint05.Level_3
{
    class Student
    {
        public int Id { get; }
        public string Name { get; }

        public Student(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public static HashSet<Student> GetCommonStudents(List<Student> list1, List<Student> list2)
        {
            HashSet<Student> h1 = new HashSet<Student>(list1);
            HashSet<Student> h2 = new HashSet<Student>(list2);

            h1.IntersectWith(h2);

            return h1;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Student student = (Student)obj;
            return this.Id == student.Id && this.Name == student.Name;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() + (this.Name ?? "").GetHashCode() * 17;
        }
    }
}