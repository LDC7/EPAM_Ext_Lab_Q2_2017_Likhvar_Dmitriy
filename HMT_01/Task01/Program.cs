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
        static void Main(string[] args)
        {
            Console.Write("Введите координату x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Введите координату y: ");
            double y = double.Parse(Console.ReadLine());
            Console.Write("Введите букву графика(а-к): ");
            int graphic = Console.Read();

            if (CheckPointEntrance(x, y, (char)graphic))
            {
                Console.WriteLine("Точка (" + x.ToString() + "; " + y.ToString() + ") принадлежит фигуре " + (char)graphic);
            }
            else
            {
                Console.WriteLine("Точка (" + x.ToString() + "; " + y.ToString() + ") не принадлежит фигуре " + (char)graphic);
            }

            Console.ReadKey();
        }

        private static bool CheckPointEntrance(double x, double y, char graphic)
        {
            switch (graphic)
            {
                case 'а':
                    // круг
                    // У StyleCop странные требования:
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
                    // ромб
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
                    if ((y * 3 - 1 <= x + 2) && (((y <= 0) && (x >= 0)) || ((y / 2 <= x + 1.5) && (y <= -1 * x))))
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
