namespace Task02
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /*
    Задан английский текст. Выделить отдельные слова и для каждого
    посчитать частоту встречаемости. Слова, отличающиеся регистром,
    считать одинаковыми. В качестве разделителей считать пробел и точку.
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string str;
            char[] sep = { '.', ' ' };
            //str = Console.ReadLine();
            str = "First.Second.second third first. fourthfirst first";

            List<string> list = new List<string>(str.Split(sep, StringSplitOptions.RemoveEmptyEntries));
            str = str.ToLower();
            List<string> buf = new List<string>(str.Split(sep, StringSplitOptions.RemoveEmptyEntries));

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("{0} \t\t\t {1}", list[i], (buf.FindAll(s => buf[i].Equals(s))).Count);
            }

            Console.ReadKey();
        }
    }
}
