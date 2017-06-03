namespace Task03
{
    using System;
    using System.Text;

    /*
    Написать программу, которая определяет сумму неотрицательных элементов в одномерном массиве.
    Число элементов в массиве и их тип определяются разработчиком.
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Random rand = new Random();

            double[] arr = new double[rand.Next(5, 10)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                arr[i] = rand.NextDouble() * rand.Next(-50, 50);
            }

            Console.WriteLine("Массив из {0} элементов:", arr.Length);
            PrintArr(arr);
            
            Console.WriteLine("Сумма позитивных элементов равна: {0}", PositiveSum(arr));

            Console.ReadKey();
        }

        private static void PrintArr<T>(T[] arr)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                Console.WriteLine(arr[j]);
            }
        }

        private static T PositiveSum<T>(T[] arr) where T : IComparable<T>
        {
            dynamic sum = 0;
            dynamic d = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(d) > 0)
                {
                    sum += arr[i];
                }
            }

            return sum;
        }
    }
}
