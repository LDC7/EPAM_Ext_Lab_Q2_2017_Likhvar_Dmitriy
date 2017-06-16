namespace Task03
{
    using System;

    class Round : Circle
    {
        public type name = (type)5;

        public Round()
        {
        }

        public Round(double x, double y, double rad) : base(x, y, rad)
        {
        }

        public double Space
        {
            get
            {
                return Math.PI * base.Radius * base.Radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new Exception(Properties.Resources.INCORRECT_SPACE_STRING);
                }

                base.Radius = Math.Sqrt(value / Math.PI);
            }
        }

        public override void Print()
        {
            Console.WriteLine("Круг x = {0} y = {1} Радиус = {2} Длина = {3:0.00} Площадь = {4:0.00}", this.X, this.Y, this.Radius, this.Length, this.Space);
        }
    }
}
