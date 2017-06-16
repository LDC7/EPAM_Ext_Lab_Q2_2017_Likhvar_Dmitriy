namespace Task02
{
    public class Ring
    {
        private double x, y;
        private Round inner;
        private Round outer;

        public Ring(double x, double y, double rad1, double rad2)
        {
            if (rad1 < rad2)
            {
                this.inner = new Round(x, y, rad1);
                this.outer = new Round(x, y, rad2);
            }
            else
            {
                this.inner = new Round(x, y, rad2);
                this.outer = new Round(x, y, rad1);
            }

            this.x = x;
            this.y = y;
        }

        public double InnerRadius
        {
            get
            {
                return this.inner.Radius;
            }

            set
            {
                this.inner.Radius = value;
            }
        }

        public double OuterRadius
        {
            get
            {
                return this.outer.Radius;
            }

            set
            {
                this.outer.Radius = value;
            }
        }

        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.inner.X = value;
                this.outer.X = value;
                this.x = value;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.inner.Y = value;
                this.outer.Y = value;
                this.y = value;
            }
        }

        public double Space
        {
            get
            {
                return this.outer.Space - this.inner.Space;
            }
        }

        public double LengthSum
        {
            get
            {
                return this.outer.Length + this.inner.Length;
            }
        }
    }
}
