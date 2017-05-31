namespace Task04
{
    using System;

    /*
    Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее «изображение», состоящее из N треугольников.
    */

    class Program
    {
        static void Main(string[] args)
        {
            int n;

            Console.Write("Введите N: ");
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.Write("Некорректное значение!\nВведите N: ");
            }

            for (int k = 1; k <= n; k++)
            {
                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        Console.Write(' ');
                    }

                    for (int j = 0; j < ((2 * i) + 1); j++)
                    {
                        Console.Write('*');
                    }

                    Console.Write('\n');
                }
            }

            Console.ReadKey();
        }
    }
}
