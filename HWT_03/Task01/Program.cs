namespace Task01
{
    using System;
    using System.Text;

    /*
    Написать программу, которая генерирует случайным образом элементы массива (число элементов в массиве и их тип определяются разработчиком),
    определяет для него максимальное и минимальное значения, сортирует массив и выводит полученный результат на экран.
    Примечание: LINQ запросы и готовые функции языка (Sort, Max и т.д.) использовать в данном задании запрещается.
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Random rand = new Random();

            // "число элементов в массиве и их тип определяются разработчиком"
            // А если я хочу массив из одного элемента типа bool?

            double[] mas = new double[rand.Next(5, 10)]; 
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rand.NextDouble() * rand.Next(1, 50);
            }

            Console.WriteLine("Массив из {0} элементов:", mas.Length);
            PrintArr(mas);

            Console.WriteLine("\nМаксимальное значение: {0}", MyMax(mas));
            Console.WriteLine("Минимальное значение:  {0}\n", MyMin(mas));

            MySort(mas);
            // Как упростить запись?
            // Console.WriteLine(SORTED_ARRAY_STRING);
            Console.WriteLine(Properties.Resources.SORTED_ARRAY_STRING);
            PrintArr(mas);

            Console.ReadKey();
        }

        private static T MyMax<T>(T[] arr) where T : IComparable<T>
        {
            T max = arr[0];
            for (int j = 1; j < arr.Length; j++)
            {
                if (arr[j].CompareTo(max) > 0)
                {
                    max = arr[j];
                }
            }

            return max;
        }

        private static T MyMin<T>(T[] arr) where T : IComparable<T>
        {
            T min = arr[0];
            for (int j = 1; j < arr.Length; j++)
            {
                if (arr[j].CompareTo(min) < 0)
                {
                    min = arr[j];
                }
            }

            return min;
        }

        // min to max
        private static void MySort<T>(T[] arr) where T : IComparable<T>
        {
            T x;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i].CompareTo(arr[j]) > 0)
                    {
                        x = arr[i];
                        arr[i] = arr[j];
                        arr[j] = x;
                    }
                }
            }
        }

        private static void PrintArr<T>(T[] arr)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                Console.WriteLine(arr[j]);
            }
        }
    }
}
