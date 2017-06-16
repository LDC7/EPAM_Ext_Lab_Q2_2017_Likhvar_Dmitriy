namespace Task03
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /*
    Напишите заготовку для векторного графического редактора. Полная
    версия редактора должна позволять создавать и выводить на экран
    такие фигуры как: Линия, Окружность, Прямоугольник, Круг, Кольцо.
    Заготовка, для упрощения, должна представлять собой консольное
    приложение с функционалом:
    1. Создать фигуру выбранного типа по произвольным координатам.
    2. Вывести фигуры на экран (для каждой фигуры вывести на консоль её тип и значения параметров).
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            List<Figure> figs = new List<Figure>();
            int n, x, y, r, x2, y2, r2;

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(Properties.Resources.INSERT_STRING); 
                    Console.WriteLine("1: Вывести список фигур");
                    Console.WriteLine("2: Добавить новую фигуру");
                    Console.WriteLine("3: Отчистить список");
                    Console.WriteLine("9: Exit");

                    int.TryParse(Console.ReadLine(), out n);

                    if (n == 9)
                    {
                        break;
                    }

                    if (n == 1)
                    {
                        Console.Clear();
                        x = 1;
                        figs.ForEach(delegate (Figure f)
                        {
                            Console.Write("{0})", x);
                            f.Print();
                            x++;
                        });
                        Console.ReadKey();
                    }

                    if (n == 2)
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine(Properties.Resources.INSERT_STRING);
                            Console.WriteLine("1: Добавить точку");
                            Console.WriteLine("2: Добавить линию");
                            Console.WriteLine("3: Добавить окружность");
                            Console.WriteLine("4: Добавить прямоугольник");
                            Console.WriteLine("5: Добавить круг");
                            Console.WriteLine("6: Добавить кольцо");
                            Console.WriteLine("9: Отмена");

                            int.TryParse(Console.ReadLine(), out n);

                            if (n == 9)
                            {
                                n = 0;
                                break;
                            }

                            switch (n)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Введите x:");
                                    int.TryParse(Console.ReadLine(), out x);
                                    Console.WriteLine("Введите y:");
                                    int.TryParse(Console.ReadLine(), out y);
                                    figs.Add(new Point(x, y));
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Введите x1:");
                                    int.TryParse(Console.ReadLine(), out x);
                                    Console.WriteLine("Введите y1:");
                                    int.TryParse(Console.ReadLine(), out y);
                                    Console.WriteLine("Введите x2:");
                                    int.TryParse(Console.ReadLine(), out x2);
                                    Console.WriteLine("Введите y2:");
                                    int.TryParse(Console.ReadLine(), out y2);
                                    figs.Add(new Line(x, y, x2, y2));
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Введите x:");
                                    int.TryParse(Console.ReadLine(), out x);
                                    Console.WriteLine("Введите y:");
                                    int.TryParse(Console.ReadLine(), out y);
                                    Console.WriteLine("Введите r:");
                                    int.TryParse(Console.ReadLine(), out r);
                                    figs.Add(new Circle(x, y, r));
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("Введите x1:");
                                    int.TryParse(Console.ReadLine(), out x);
                                    Console.WriteLine("Введите y1:");
                                    int.TryParse(Console.ReadLine(), out y);
                                    Console.WriteLine("Введите x2:");
                                    int.TryParse(Console.ReadLine(), out x2);
                                    Console.WriteLine("Введите y2:");
                                    int.TryParse(Console.ReadLine(), out y2);
                                    figs.Add(new Bar(x, y, x2, y2));
                                    break;
                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("Введите x:");
                                    int.TryParse(Console.ReadLine(), out x);
                                    Console.WriteLine("Введите y:");
                                    int.TryParse(Console.ReadLine(), out y);
                                    Console.WriteLine("Введите r:");
                                    int.TryParse(Console.ReadLine(), out r);
                                    figs.Add(new Round(x, y, r));
                                    break;
                                case 6:
                                    Console.Clear();
                                    Console.WriteLine("Введите x:");
                                    int.TryParse(Console.ReadLine(), out x);
                                    Console.WriteLine("Введите y:");
                                    int.TryParse(Console.ReadLine(), out y);
                                    Console.WriteLine("Введите r1:");
                                    int.TryParse(Console.ReadLine(), out r);
                                    Console.WriteLine("Введите r2:");
                                    int.TryParse(Console.ReadLine(), out r2);
                                    figs.Add(new Ring(x, y, r, r2));
                                    break;
                            }
                        }
                    }

                    if (n == 3)
                    {
                        figs.Clear();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }
    }
}
