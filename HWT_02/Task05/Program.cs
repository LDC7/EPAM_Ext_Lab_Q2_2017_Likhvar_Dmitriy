namespace Task05
{
    using System;

    /*
    Если выписать все натуральные числа меньше 10, кратные 3, или 5, то получим 3, 5, 6 и 9.
    Сумма этих чисел будет равна 23.
    Напишите программу, которая выводит на экран сумму всех чисел меньше 1000, кратных 3, или 5.
    */

    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            for (int i = 3; i < 1000; i += 3)
            {
                sum += i;
            }

            for (int i = 5; i < 1000; i += 5)
            {
                if (i % 3 != 0) sum += i;
            }

            Console.WriteLine(sum.ToString());
            Console.ReadKey();
        }
    }
}
