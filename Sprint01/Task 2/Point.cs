using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint01.Task_2
{
    class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal int[] GetXYPair() =>
            new int[] { this.x, this.y };

        protected internal double Distance(int x, int y) =>
            Math.Sqrt(Math.Pow(x - this.x, 2) + Math.Pow(y - this.y, 2));

        protected internal double Distance(Point point) =>
            Math.Sqrt(Math.Pow(point.x - this.x, 2) + Math.Pow(point.y - this.y, 2));

        public static explicit operator double (Point point) =>
            Math.Sqrt(Math.Pow(point.x - 0, 2) + Math.Pow(point.y - 0, 2));
    }
}
