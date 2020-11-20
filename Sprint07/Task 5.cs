using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sprint07
{
    class Department
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Worker Manager { get; set; }

        public Department() { }

        public Department(string Name, int Id, Worker Manager)
        {
            this.Name = Name;
            this.Id = Id;
            this.Manager = Manager;
        }
    }

    class Worker
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonPropertyName("Full name")]
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public Department Department { get; set; }

        public Worker() { }

        public Worker(string Name, decimal Salary, Department department)
        {
            this.Name = Name;
            this.Salary = Salary;
            this.Department = department;
        }

        public string Serialize() =>
            JsonSerializer.Serialize<Worker>(this, new JsonSerializerOptions { WriteIndented = true, IgnoreNullValues = true });

        public static Worker Deserialize(string param) =>
            JsonSerializer.Deserialize<Worker>(param);
    }
}
