namespace Task02
{
    using System;
    using System.Text;

    /*
    Написать класс, описывающий треугольник со сторонами a, b, c, и позволяющий осуществить расчёт его площади и периметра.
    Написать программу, демонстрирующую использование данного треугольника.
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Console.WriteLine("Некорректные данные");
            Triangle tri = new Triangle(0, -2, 3, 4, 6);
            Console.WriteLine("\nНесуществующий треугольник:");
            Console.WriteLine("a = {0}", tri[0]);
            Console.WriteLine("b = {0}", tri[1]);
            Console.WriteLine("c = {0}", tri[2]);
            Console.WriteLine("Периметр: {0}", tri.Perimeter);
            Console.WriteLine("Площадь: {0}", tri.Space);

            Console.WriteLine("\nНовый треугольник:");
            tri = new Triangle(2, 2);            
            Console.WriteLine("a = {0}", tri[0]);
            Console.WriteLine("b = {0}", tri[1]);
            Console.WriteLine("c = {0}", tri[2]);
            Console.WriteLine("Периметр: {0}", tri.Perimeter);
            Console.WriteLine("Площадь: {0}", tri.Space);

            Console.ReadKey();
        }
    }

    public class Triangle
    {
        private double[] sides = { 1, 1, 1 };

        public Triangle()
        {
        }
        
        public Triangle(params double[] side)
        {
            if (side.Length != 3)
            {
                Console.WriteLine(Properties.Resources.WRONG_NUMS_OF_PARAMETERS_STRING);
            }

            for (int i = 0; i < 3 && i < side.Length; i++)
            {
                this[i] = side[i];
            }
        }

        public double Space
        {
            get
            {
                double p = (this.sides[0] + this.sides[1] + this.sides[2]) / 2;
                double s = Math.Sqrt(p * (p - this.sides[0]) * (p - this.sides[1]) * (p - this.sides[2]));
                if (s > 0)
                {
                    return s;
                }
                else
                {
                    Console.WriteLine(Properties.Resources.ERROR_STIRNG + Properties.Resources.SPACE_NOT_FOUND_STRING);
                    return 0;
                }
            }
        }

        public double Perimeter
        {
            get
            {
                double p = (this.sides[0] + this.sides[1] + this.sides[2]) / 2;
                double s = Math.Sqrt(p * (p - this.sides[0]) * (p - this.sides[1]) * (p - this.sides[2]));
                if (s > 0)
                {
                    return p * 2;
                }
                else
                {
                    Console.WriteLine(Properties.Resources.ERROR_STIRNG + Properties.Resources.PERIMETER_NOT_FOUND_STRING);
                    return 0;
                }
            }
        }

        public double this[int i]
        {
            get
            {
                return this.sides[i];
            }

            set
            {
                if (value > 0)
                {
                    this.sides[i] = value;
                }
                else
                {
                    Console.WriteLine(Properties.Resources.INCORRECT_VALUE_STRING);
                }
            }
        }
    }
}