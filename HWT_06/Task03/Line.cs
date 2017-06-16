namespace Task03
{
    using System;

    public class Line : Figure
    {
        public type name = (type)2;
        public Point Point1;
        public Point Point2;

        public Line(Point p1, Point p2)
        {
            this.Point1 = p1;
            this.Point2 = p2;
        }

        public Line(double x1, double y1, double x2, double y2)
        {
            this.Point1 = new Point(x1, y1);
            this.Point2 = new Point(x2, y2);
        }

        public double Length
        {
            get
            {
                return Math.Sqrt(Math.Pow(this.Point1.X - this.Point2.X, 2) + Math.Pow(this.Point1.Y - this.Point2.Y, 2));
            }
        }

        public override void Print()
        {
            Console.WriteLine("Линия x1 = {0} y1 = {1} x2 = {2} y2 = {3} Длина = {4:0.00}", this.Point1.X, this.Point1.Y, this.Point2.X, this.Point2.Y, this.Length);
        }
    }
}
