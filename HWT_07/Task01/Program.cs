namespace Task01
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /*
    В кругу стоят N человек, пронумерованных от 1 до N. При ведении счета
    по кругу вычёркивается каждый второй человек, пока не останется
    один. Составить программу, моделирующую процесс.
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int n, i, j;

            do
            {
                Console.WriteLine("Введите N: ");
            }
            while (!int.TryParse(Console.ReadLine(), out n) || n < 2);

            List<int> list = new List<int>();
            for (i = 1; i <= n; i++)
            {
                list.Add(i);
                Console.Write("{0} ", i);
            }
            Console.Write("\n");

            while (list.Count > 1)
            {
                for (j = 1; list.Count > j; j++)
                {
                    list.RemoveAt(j);
                }

                list.ForEach(delegate(int l)
                {
                    Console.Write("{0} ", l);
                });
                Console.Write("\n");

                Console.ReadKey();
            }
        }
    }
}
