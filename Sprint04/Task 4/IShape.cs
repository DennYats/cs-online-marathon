using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Sprint04.Task_4
{
    public interface IShape : ICloneable
    {
        double Area() => 0;
    }

    public class Rectangle : IShape
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Area() => Length * Width;

        object ICloneable.Clone() => this.MemberwiseClone();
    }

    public class Trapezoid : IShape
    {
        public double Length1 { get; set; }
        public double Length2 { get; set; }
        public double Width { get; set; }
        public double Area() => (Length1 + Length2) / 2 * Width;

        object ICloneable.Clone() => this.MemberwiseClone();
    }

    public class Room<T> : ICloneable, IComparable
        where T : IShape
    {
        public double Height { get; set; }
        public T Floor { get; set; }
        public double Volume() => Height * Floor.Area();
        public object Clone() => new Room<T> { Height = this.Height, Floor = (T)this.Floor.Clone() };

        public int CompareTo(object o)
        {
            Room<T> r = o as Room<T>;
            if (r != null)
                return this.Floor.Area().CompareTo(r.Floor.Area());
            else
                throw new Exception("Impossible to compare");
        }
    }

    public class RoomComparerByVolume<T> : System.Collections.Generic.IComparer<Room<T>>
        where T : IShape
    {
        public int Compare(Room<T> r1, Room<T> r2)
        {
            if (r1.Volume() > r2.Volume())
                return 1;
            else if (r1.Volume() < r2.Volume())
                return -1;
            else
                return 0;
        }
    }
}
