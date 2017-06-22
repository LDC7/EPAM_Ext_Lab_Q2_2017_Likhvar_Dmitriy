namespace Task03
{
    using System;
    using System.Text;

    /*
    На базе обычного массива (коллекции .NET не использовать) реализовать свой собственный класс DynamicArray, представляющий
    собой массив с запасом. Класс должен содержать:
    1. Конструктор без параметров (создается массив емкостью 8 элементов).
    2. Конструктор с 1 целочисленным параметром (создается массив заданной емкости).
    3. Конструктор, который в качестве параметра принимает коллекцию, реализующую интерфейс IEnumerable, создает массив нужного
    размера и копирует в него все элементы из коллекции.
    4. Метод Add, добавляющий в конец массива один элемент. При нехватке места для добавления элемента емкость массива должна расширяться в 2 раза.
    5. Метод AddRange, добавляющий в конец массива содержимое коллекции, реализующей интерфейс IEnumerable. Обратите
    внимание, метод должен корректно учитывать число элементов в коллекции с тем, чтобы при необходимости расширения массива
    делать это только один раз вне зависимости от числа элементов в добавляемой коллекции.
    6. Метод Remove, удаляющий из коллекции указанный элемент. Метод должен возвращать true, если удаление прошло успешно и
    false в противном случае. При удалении элементов реальная емкость массива не должна уменьшаться.
    7. Метод Insert, позволяющий добавить элемент в произвольную позицию массива (обратите внимание, может потребоваться
    расширить массив). Метод должен возвращать true, если добавление прошло успешно и false в противном случае. При
    выходе за границу массива должно генерироваться исключение ArgumentOutOfRangeException.
    8. Свойство Length – получение длины массива.
    9. Свойство Capacity – получение реальной длины массива.
    10. Методы, реализующие интерфейсы IEnumerable и IEnumerator.
    11. Индексатор, позволяющий работать с элементом с указанным номером. При выходе за границу массива должно генерироваться
    исключение ArgumentOutOfRangeException.
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            DynamicArray<int> darr = new DynamicArray<int>();
            Console.WriteLine("Длина {0}", darr.Length);
            Console.WriteLine("Длина массива {0}", darr.Capacity);

            darr = new DynamicArray<int>(5);
            Console.WriteLine("Длина массива {0}", darr.Capacity);

            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            darr = new DynamicArray<int>(arr);
            Console.WriteLine("Длина {0}", darr.Length);
            Console.WriteLine("Длина массива {0}", darr.Capacity);

            Console.WriteLine("Последний элемент: {0}", darr[darr.Length - 1]);
            darr.Add(8);
            Console.WriteLine("Последний элемент: {0}", darr[darr.Length - 1]);

            PrintIntDynArr(darr);
            darr.Remove(3);
            PrintIntDynArr(darr);

            PrintIntDynArr(darr);
            darr.Insert(5, 2);
            PrintIntDynArr(darr);

            Console.WriteLine("Первый элемент: {0}", darr[0]);
            Console.ReadKey();
        }

        public static void PrintIntDynArr(DynamicArray<int> arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i);
            }
            Console.Write("\n");
        }
    }
}
