namespace Task03
{
    using System;

    class Circle : Figure
    {
        public type name = (type)3;
        public double X = 0, Y = 0;
        private double r = 0;

        public Circle()
        {
        }

        public Circle(double x, double y, double rad)
        {
            this.X = x;
            this.Y = y;
            this.Radius = rad;
        }

        public virtual double Radius
        {
            get
            {
                if (this.r <= 0)
                {
                    throw new Exception(Properties.Resources.UNINITIALIZED_RADIUS_STRING);
                }

                return this.r;
            }

            set
            {
                if (value <= 0)
                {
                    throw new Exception(Properties.Resources.INCORRECT_RADIUS_STRING);
                }

                this.r = value;
            }
        }

        public double Length
        {
            get
            {
                if (this.r <= 0)
                {
                    throw new Exception(Properties.Resources.UNINITIALIZED_RADIUS_STRING);
                }

                return 2 * Math.PI * this.r;
            }

            set
            {
                if (value <= 0)
                {
                    throw new Exception(Properties.Resources.INCORRECT_LENGTH_STRING);
                }

                this.r = value / (2 * Math.PI);
            }
        }

        public override void Print()
        {
            Console.WriteLine("Окружность x = {0} y = {1} Радиус = {2} Длина = {3:0.00}", this.X, this.Y, this.Radius, this.Length);
        }
    }
}
