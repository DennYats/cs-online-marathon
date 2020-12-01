using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint10.Task6
{
    interface IFlyable
    {
        void Fly();
    }

    interface IBasking
    {
        void Bask();
    }

    interface IKryaking
    {
        void Krya();
    }

    interface IEating
    {
        void Eat();
    }

    interface IMoving
    {
        void Move();
    }

    class Bird : IFlyable, IEating, IMoving
    {
        public void Fly() => Console.WriteLine("I believe, I can fly");
        public void Eat() => Console.WriteLine("Oh! My corn!");
        public void Move() => Console.WriteLine("I can jump!");
    }

    class Parrot : Bird, IFlyable, IBasking, IKryaking, IEating, IMoving
    {
        public void Fly() => base.Fly();
        public void Bask() => Console.WriteLine("Chuh-Chuh-Chuh...");
        public void Krya() => Console.WriteLine("Krya-Krya-Krya...");
        public void Eat() => Console.WriteLine("Oh! My seeds and fruits!");
        public void Move() => base.Move();
    }

    class Sparrow : IFlyable, IEating, IMoving
    {
        public void Fly() => Console.WriteLine("I believe, I can fly");
        public void Eat() => Console.WriteLine("Oh! My corn!");
        public void Move() => Console.WriteLine("I can jump!");
    }

    class Duck : Bird, IFlyable, IKryaking, IEating, IMoving
    {
        public void Fly() => base.Fly();
        public void Eat() => base.Eat();
        public void Krya() => Console.WriteLine("Krya-Krya!");
        public void Move() => Console.WriteLine("I can swimm!");
    }

    class Cat : IBasking, IEating, IMoving
    {
        public void Move() => Console.WriteLine("I can jump!");
        public void Eat() => Console.WriteLine("Oh! My milk!");
        public void Bask() => Console.WriteLine("Mrrr-Mrrr-Mrrr...");
    }
}
