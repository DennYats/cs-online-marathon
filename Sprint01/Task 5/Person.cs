using System;

namespace Sprint01.Task_5
{
    public class Person
    {
        protected int yearOfBirth;
        protected string name;
        protected string healthInfo;

        public Person(int yearOfBirth, string name, string healthInfo)
        {
            this.yearOfBirth = yearOfBirth;
            this.name = name;
            this.healthInfo = healthInfo;
        }

        public string GetHealthStatus() { return name + ": " + yearOfBirth + ". " + healthInfo; }
    }

    public class Child : Person
    {

        private string childIDNumber;

        public Child(int yearOfBirth, string name, string healthInfo, string childIDNumber)
            : base(yearOfBirth, name, healthInfo) => this.childIDNumber = childIDNumber;

        public override string ToString() => $"{this.name} {childIDNumber}";
    }

    public class Adult : Person
    {
        private string passportNumber;

        public Adult(int yearOfBirth, string name, string healthInfo, string passportNumber)
            : base(yearOfBirth, name, healthInfo)
        {
            this.passportNumber = passportNumber;
        }

        public override string ToString()
        {
            return $"{this.name} {passportNumber}";
        }
    }
}
