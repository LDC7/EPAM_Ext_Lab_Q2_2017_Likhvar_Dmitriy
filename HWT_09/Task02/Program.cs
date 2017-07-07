namespace Task02
{
    using System;
    using System.Text;

    /*
    Напишите расширяющий метод, который определяет, является ли строка положительным целым числом. Методы Parse и TryParse не использовать.
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string str = "255";
            Console.WriteLine("{0} is PositiveInteger - {1}", str, str.PositiveInteger());
            str = "abv";
            Console.WriteLine("{0} is PositiveInteger - {1}", str, str.PositiveInteger());
            str = "-";
            Console.WriteLine("{0} is PositiveInteger - {1}", str, str.PositiveInteger());
            str = "-1";
            Console.WriteLine("{0} is PositiveInteger - {1}", str, str.PositiveInteger());
            str = "0";
            Console.WriteLine("{0} is PositiveInteger - {1}", str, str.PositiveInteger());

            Console.ReadKey();
        }
    }
}
