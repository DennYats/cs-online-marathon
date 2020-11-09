using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint04.Task_2
{
    interface IAnimal
    {
        string Name { get; set; }
        void Voice();
        void Feed();
    }

    class Cat : IAnimal
    {
        string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public void Voice() => Console.WriteLine("Mew");
        public void Feed() => Console.WriteLine("I eat mice");
    }

    class Dog : IAnimal
    {
        string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public void Voice() => Console.WriteLine("Woof");
        public void Feed() => Console.WriteLine("I eat meat");
    }
}
