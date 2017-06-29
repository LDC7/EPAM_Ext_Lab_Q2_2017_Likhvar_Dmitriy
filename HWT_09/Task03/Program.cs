namespace Task03
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using System.Linq;

    /*
    Написать методы поиска элемента в массиве (например, поиск всех положительных элементов в массиве) в виде:
    1. Метода, реализующего поиск напрямую;
    2. Метода, которому условие поиска передаётся через делегат;
    3. Метода, которому условие поиска передаётся через делегат в виде анонимного метода;
    4. Метода, которому условие поиска передаётся через делегат в виде лямбда-выражения;
    5. LINQ-выражения
    */

    public delegate bool PositiveInt(int i);

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int[] arr = new int[101];
            int[] buf;
            Stopwatch sw = new Stopwatch();
            Random r = new Random();
            PositiveInt deleg = PositiveIntMeth;
            List<long>[] res = new List<long>[5];
            
            for (int i = 0; i < 5; i++)
            {
                res[i] = new List<long>();
            }

            for (int i = 0; i < 90; i++)
            {
                arr[i] = r.Next(-5, 5);
            }

            Console.Write("#  \tПрям.Поиск. \tДелегат \tАнон. \tЛямбда \tLINQ\n");
            for (int i = 0; i < 11; i++)
            {
                Console.Write("{0}) \t", i);

                //Прям.Поиск
                sw.Restart();
                buf = PositiveElements(arr);
                sw.Stop();
                Console.Write("{0} \t\t", sw.ElapsedTicks);
                res[0].Add(sw.ElapsedTicks);

                //Делегат
                sw.Restart();
                buf = PositiveElements(arr, deleg);
                sw.Stop();
                Console.Write("{0} \t\t", sw.ElapsedTicks);
                res[1].Add(sw.ElapsedTicks);

                //Анонимный делегат
                sw.Restart();
                buf = PositiveElements(
                    arr,
                    delegate(int j)
                    {
                        return j > 0;
                    });
                sw.Stop();
                Console.Write("{0} \t", sw.ElapsedTicks);
                res[2].Add(sw.ElapsedTicks);

                //Лямбда
                sw.Restart();
                buf = PositiveElements(arr, j => j > 0);
                sw.Stop();
                Console.Write("{0} \t", sw.ElapsedTicks);
                res[3].Add(sw.ElapsedTicks);

                //LINQ
                sw.Restart();
                buf = PositiveElementsLINQ(arr);
                sw.Stop();
                Console.Write("{0} \t", sw.ElapsedTicks);
                res[4].Add(sw.ElapsedTicks);

                Console.WriteLine();
            }
            
            for (int i = 0; i < 5; i++)
            {
                res[i].Sort();
            }

            Console.Write("Медианы {0} \t\t{1} \t\t{2} \t{3} \t{4}\n", res[0][5], res[1][5], res[2][5], res[3][5], res[4][5]);

            Console.ReadKey();
        }

        public static int[] PositiveElements(int[] arr)
        {
            List<int> list = new List<int>();

            foreach (int i in arr)
            {
                if (i > 0)
                {
                    list.Add(i);
                }
            }

            return list.ToArray();
        }

        public static int[] PositiveElements(int[] arr, PositiveInt condition)
        {
            List<int> list = new List<int>();

            foreach (int i in arr)
            {
                if (condition(i))
                {
                    list.Add(i);
                }
            }

            return list.ToArray();
        }

        public static int[] PositiveElementsLINQ(int[] arr)
        {
            var result = from i in arr
                         where i > 0
                         select i;

            return result.ToArray();
        }

        public static bool PositiveIntMeth(int i)
        {
            return i > 0;
        }
    }
}
