namespace Task03
{
    using System;

    public class Bar : Figure
    {
        public type name = (type)4;
        private Point p1, p2, p3, p4;

        public Bar(double x1, double y1, double x2, double y2)
        {
            if (x1 >= x2 || y1 >= y2)
            {
                throw new Exception(Properties.Resources.INVALID_PARAMETERS_STRING);//todo pn здесь лучше бы было создать наследника от Exception или использовать ArgumentException (или что-то типа этого)
            }

            p1 = new Point(x1, y1);
            p2 = new Point(x2, y1);
            p3 = new Point(x2, y2);
            p4 = new Point(x1, y2);
        }

        public double Perimeter
        {
            get
            {
                return Math.Abs(this.p1.X - this.p2.X) * 2 + Math.Abs(this.p1.Y - this.p2.Y) * 2;
            }
        }

        public double Space
        {
            get
            {
                return Math.Abs(this.p1.X - this.p2.X) * Math.Abs(this.p1.Y - this.p2.Y);
            }
        }

        public override void Print()
        {
            Console.WriteLine("Прямоугольник Периметр = {0} Площадь = {1}", this.Perimeter, this.Space);
        }
    }
}
