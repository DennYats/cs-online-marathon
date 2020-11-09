using System;

namespace Sprint03.Task_5
{
    class EventProgram
    {
        public delegate void EventHandler();
        public event EventHandler Show;

        void Dog() => Console.WriteLine("Dog");
        void Cat() => Console.WriteLine("Cat");
        void Mouse() => Console.WriteLine("Mouse");
        void Elephant() => Console.WriteLine("Elephant");

        public EventProgram()
        {
            Show += Dog;
            Show += Cat;
            Show += Mouse;
            Show += Elephant;
            Show?.Invoke();
        }
    }
}
