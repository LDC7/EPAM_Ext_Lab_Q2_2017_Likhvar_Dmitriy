﻿namespace Task02
{
    using System;

    /*
    Дано число h.
    Выяснить корни уравнения ax^2+bx+c=0
    Выводить промежуточные данные.
    */

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите h: ");
            double h = double.Parse(Console.ReadLine());

            double a = Math.Sqrt((Math.Abs(Math.Sin(8 * h)) + 17) / ((1 - Math.Sin(4 * h) * Math.Cos(h * h + 18)) * (1 - Math.Sin(4 * h) * Math.Cos(h * h + 18))));
            Console.WriteLine("a = " + a.ToString());
            double b = 1 - Math.Sqrt(3 / (3 + Math.Abs(Math.Tan(a * h * h) - Math.Sin(a * h))));
            Console.WriteLine("b = " + b.ToString());
            double c = (a * h * h * Math.Sin(b * h)) + (b * h * h * h * Math.Cos(a * h));
            Console.WriteLine("c = " + c.ToString());

            // дискрименант
            double d = b * b - 4 * a * c;
            Console.WriteLine("D = " + d.ToString());

            if (d >= 0)
            {
                double root1 = (-1 * b + Math.Sqrt(d)) / (2 * a);
                double root2 = (-1 * b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("Корни уравнения: " + root1.ToString() + " и " + root2.ToString());
            }
            else
            {
                Console.WriteLine("Дискрименант отрицательный. Корни не действительные.");
            }

            Console.ReadKey();
        }
    }
}
