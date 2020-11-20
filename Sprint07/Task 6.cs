using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Sprint07
{
    class Student
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public string GroupName { get; set; }
    }

    class Group
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Popularity { get; set; }
    }

    class Task_6
    {
        public static string CreateGroups(List<Student> students, List<Group> groups)
        {
            var json = groups.GroupJoin(
                students,
                gr => gr.Name,
                st => st.GroupName,
                (group, students) => new
                {
                    group = group.Name,
                    description = group.Description,
                    rating = students.Average(x => x.Rating),
                    students = students.Select(student => new
                    {
                        FullName = student.Name,
                        AvgMark = student.Rating
                    })
                });

            return JsonSerializer.Serialize(json, new JsonSerializerOptions
            {
                WriteIndented = true,
                IgnoreNullValues = true
            });
        }
    }
}