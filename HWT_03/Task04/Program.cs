namespace Task03
{
    using System;
    using System.Text;

    /*
    Элемент двумерного массива считается стоящим на чётной позиции,
    если сумма номеров его позиций по обеим размерностям является чётным числом (например, [1,1] – чётная позиция, а [1,2] - нет).
    Определить сумму элементов массива, стоящих на чётных позициях.
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Random rand = new Random();

            double[,] arr = new double[rand.Next(3, 6), rand.Next(3, 6)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.NextDouble() * rand.Next(1, 25);
                }
            }

            Console.WriteLine("Массив из {0} элементов:", arr.Length);
            PrintArr(arr);

            Console.WriteLine("Сумма элементов на чётных позициях равна: {0:0.00}", EvenSum(arr));//todo pn ты как бы не генерируешь отрицательные элементы массива

            Console.ReadKey();
        }

        private static void PrintArr<T>(T[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0:0.00} \t", arr[i, j]);
                }

                Console.Write('\n');
            }
        }

        private static T EvenSum<T>(T[,] arr) where T : IComparable<T>
        {
            dynamic sum = 0;
            dynamic d = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += arr[i, j];
                    }
                }
            }

            return sum;
        }
    }
}
