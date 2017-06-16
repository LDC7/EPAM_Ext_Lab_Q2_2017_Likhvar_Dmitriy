namespace Task03
{
    using System;

    public class Point : Figure
    {
        public type name = (type)1;
        public double X, Y;

        public Point()
        {
        }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override void Print()
        {
            Console.WriteLine("Точка x = {0} y = {1}", X, Y);
        }
    }
}
