namespace Task02
{
    using System;
    using System.Text;

    /*
    Написать программу, которая удваивает в первой введенной строки все
    символы, принадлежащие второй введенной строке.
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string str1, str2;

            Console.Write("Введите 1 строку: ");
            str1 = Console.ReadLine();
            Console.Write("Введите 2 строку: ");
            str2 = Console.ReadLine();

            for (int i = 0; i < str1.Length; i++)
            {
                Console.Write((str2.IndexOf(str1[i]) > -1) ? "{0}{0}" : "{0}", str1[i]);
            }

            Console.ReadKey();
        }
    }
}
