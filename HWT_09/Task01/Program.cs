namespace Task01
{
    using System;
    using System.Text;

    /*
    Напишите расширяющий метод, который определяет сумму элементов массива.
    */

    public delegate bool Delegate(string str1, string str2);

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            double[] darr = { 1.1, 2, 3, 4, 5, 6, 15.5 };
            Console.WriteLine("Сумма элементов массива равна {0}", darr.Sum());

            Console.ReadKey();
        }
    }
}
