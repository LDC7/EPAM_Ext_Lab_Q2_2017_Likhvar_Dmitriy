using System.Text;

namespace Task01
{
    using System;

    /*
    Написать консольное приложение, которое проверяет
    принадлежность точки заштрихованной области.
    Пользователь вводит координаты точки (x; y) и выбирает
    букву графика(a-к). В консоли должно высветиться сообщение:
    «Точка[(x; y)] принадлежит фигуре[г]».
    */

    public class Program
    {
        static void Main(string[] args)//todo pn хотелось бы, конечно, спрашивать пользователя о том, нужно ли закрывать консоль после прогона метода. 
        {
	        Console.InputEncoding = Encoding.Unicode;//todo pn без явного задания кодировки будет использована кодировка по умолчанию. Машина, на которой я проверяю настроена на английскую культуру, поэтому кириллические символы отображаются в ней как знаки вопроса. Следует учитывать такое специфичное поведение консоли в следующих заданиях :)/
	        Console.OutputEncoding = Encoding.Unicode;

			Console.Write("Введите координату x: ");
            double x;
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.Write("Ошибка!\nВведите координату x: ");
            }

            Console.Write("Введите координату y: ");
            double y;
            while (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.Write("Ошибка!\nВведите координату y: ");
            }

            Console.Write("Введите букву графика(а-к): ");
            int graphic = Console.Read();
            
            if (CheckPointEntrance(x, y, (char)graphic))
            {
                Console.WriteLine("Точка ({0}; {1}) принадлежит фигуре {2}", x, y, (char)graphic);//todo pn у тебя здесь и строкой ниже дублируется большая часть сообщения, лучше условие перенести в WriteLine через оператор "? :".
			}
            else
            {
                Console.WriteLine("Точка ({0}; {1}) не принадлежит фигуре {2}", x, y, (char)graphic);
            }

            Console.ReadKey();
        }

        private static bool CheckPointEntrance(double x, double y, char graphic)
        {
            switch (graphic)
            {
                case 'а':
                    // круг
                    if (1 >= x * x + y * y)
                    {
                        return true;
                    }

                    break;
                case 'б':
                    // окружность
                    if ((1 >= x * x + y * y) && (0.25 <= x * x + y * y))
                    {
                        return true;
                    }

                    break;
                case 'в':
                    // квадрат
                    if ((1 >= x) && (-1 <= x) && (1 >= y) && (-1 <= y))
                    {
                        return true;
                    }

                    break;
                case 'г':
                    // ромб //todo pn неиформативные комментарии здесь и ниже, потому что код разный, а коммент один.
                    if ((y <= x + 1) && (y <= -1 * x + 1) && (y >= x - 1) && (y >= -1 * x - 1))
                    {
                        return true;
                    }

                    break;
                case 'д':
                    // ромб
                    if ((y / 2 <= x + 0.5) && (y / 2 <= -1 * x + 0.5) && (y / 2 >= x - 0.5) && (y / 2 >= -1 * x - 0.5))
                    {
                        return true;
                    }

                    break;
                case 'е':
                    // полукруг и треугольник
                    if ((y * 2 <= x + 2) && (y * 2 >= -1 * x - 2) && ((x <= 0) || (1 >= x * x + y * y)))
                    {
                        return true;
                    }

                    break;
                case 'ж':
                    // треугольник
                    if ((y >= -1) && (y / 2 <= x + 1) && (y / 2 <= -1 * x + 1))
                    {
                        return true;
                    }

                    break;
                case 'з':
                    if (((y <= x) || ((x < 0) && (y <= -1 * x))) && (y >= -2) && (x >= -1) && (x <= 1))
                    {
                        return true;
                    }

                    break;
                case 'и':
                    if ((y * 3 + 3 >= x + 2) && (((y <= 0) && (x >= 0)) || ((y / 2 <= x + 1.5) && (y <= -1 * x))))
                    {
                        return true;
                    }

                    break;
                case 'к':
                    if ((y >= 1) || ((y >= x) && (y - 1 >= -1 * x - 1)))
                    {
                        return true;
                    }

                    break;

                default:
                    Console.WriteLine("Ошибка. График не найден");
                    break;
            }

            return false;
        }
    }
}
