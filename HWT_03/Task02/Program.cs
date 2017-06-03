namespace Task02
{
    using System;
    using System.Text;

    /*
    Написать программу, которая заменяет все положительные элементы в трёхмерном массиве на нули.
    Число элементов в массиве и их тип определяются разработчиком.
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Random rand = new Random();

            double[,,] arr = new double[rand.Next(3, 6), rand.Next(3, 6), rand.Next(3, 6)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        arr[i, j, k] = rand.NextDouble() * rand.Next(-50, 50);
                    }
                }
            }

            Console.WriteLine("Массив из {0} элементов:", arr.Length);
            PrintArr(arr);

            PositiveTo0(arr);
            Console.WriteLine("Изменённый массив:");
            PrintArr(arr);

            Console.ReadKey();
        }

        private static void PrintArr<T>(T[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        Console.Write("{0:0.0} \t", arr[i, j, k]);
                    }

                    Console.Write('\n');
                }

                Console.Write('\n');
            }
        }

        private static void PositiveTo0<T>(T[,,] arr) where T : IComparable<T>
        {
            dynamic d = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        if (arr[i, j, k].CompareTo(d) > 0)
                        {
                            arr[i, j, k] = d;
                        }
                    }
                }
            }
        }
    }
}
