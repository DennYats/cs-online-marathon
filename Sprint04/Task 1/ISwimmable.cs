using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint04.Task_1
{
    interface ISwimmable
    {
        void Swim()
        {
            Console.WriteLine("I can swim!");
        }
    }

    interface IFlyable
    {
        public int MaxHeight { get { return 0; } }
        void Fly() => Console.WriteLine($"I can fly at {MaxHeight} meters height!");
    }

    interface IRunnable
    {
        public int MaxSpeed { get { return 0; } }
        void Run() => Console.WriteLine($"I can run up to {MaxSpeed} kilometers per hour!");
    }

    interface IAnimal
    {
        public int LifeDuration { get { return 0; } }
        void Voice() => Console.WriteLine($"No voice!");
        void ShowInfo() => Console.WriteLine($"I am a {this.GetType()} and I live approximately {LifeDuration} years.");
    }

    class Cat : IAnimal, IRunnable
    {
        int maxSpeed;
        int lifeDuration;

        public int MaxSpeed
        {
            get { return this.maxSpeed; }
            set { this.maxSpeed = value; }
        }
        public int LifeDuration
        {
            get { return this.lifeDuration; }
            set { this.lifeDuration = value; }
        }
        public void Voice() => Console.WriteLine("Meow!");
    }

    class Eagle : IAnimal, IFlyable
    {
        int maxHeight;
        int lifeDuration;

        public int MaxHeight
        {
            get { return this.maxHeight; }
            set { this.maxHeight = value; }
        }
        public int LifeDuration
        {
            get { return this.lifeDuration; }
            set { this.lifeDuration = value; }
        }
    }

    class Shark : IAnimal, ISwimmable
    {
        int lifeDuration;

        public int LifeDuration
        {
            get { return this.lifeDuration; }
            set { this.lifeDuration = value; }
        }
    }
}
