using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint02.Task_4
{
    abstract class ChessFigure
    {
        public abstract void Move();
    }
    
    class Bishop : ChessFigure
    {
        public override void Move() => Console.WriteLine("Moves by diagonal!");
    }

    class Rook : ChessFigure
    {
        public override void Move() => Console.WriteLine("Moves straight!");
    }
}
