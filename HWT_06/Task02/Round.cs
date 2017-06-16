namespace Task02
{
    using System;

    public class Round
    {
        public double X = 0, Y = 0; //не свойствами, т.к. геттер и сеттер по умолчанию.
        private double r = 0;

        public Round()
        {
        }

        public Round(double x, double y, double rad)
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

        public double Space
        {
            get
            {
                if (this.r <= 0)
                {
                    throw new Exception(Properties.Resources.UNINITIALIZED_RADIUS_STRING);
                }

                return Math.PI * this.r * this.r;
            }

            set
            {
                if (value <= 0)
                {
                    throw new Exception(Properties.Resources.INCORRECT_SPACE_STRING);
                }

                this.r = Math.Sqrt(value / Math.PI);
            }
        }
    }
}
