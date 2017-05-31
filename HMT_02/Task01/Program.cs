namespace Task01
{
    using System;

    /*
    Написать программу, которая определяет площадь прямоугольника со сторонами a и b.
    Если пользователь вводит некорректные значения (отрицательные, или 0), должно выдаваться сообщение об ошибке.
    Возможность ввода пользователем строки вида «абвгд», или нецелых чисел игнорировать.
    */

    class Program
    {
        static void Main(string[] args)
        {            
            int a, b;

            Console.Write("Введите сторону a: ");
            while (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
            {
                Console.Write("Некорректное значение!\nВведите сторону a: ");
            }

            Console.Write("Введите сторону b: ");
            while (!int.TryParse(Console.ReadLine(), out b) || b <= 0)
            {
                Console.Write("Некорректное значение!\nВведите сторону b: ");
            }

            Console.WriteLine("Площадь прямоугольника равна {0}", a * b);

            Console.ReadKey();
        }
    }
}
