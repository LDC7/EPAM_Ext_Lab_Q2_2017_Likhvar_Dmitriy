﻿namespace Task02
{
    using System;
    using System.Text;

    /*
    Написать программу, описывающую небольшой офис, в котором работают сотрудники – объекты класса Person, обладающие полем имя
    (Name). Каждый из сотрудников содержит пару методов: приветствие сотрудника, пришедшего на работу (принимает в качестве аргументов
    объект сотрудника и время его прихода) и прощание с ним (принимает только объект сотрудника). В зависимости от времени суток,
    приветствие может быть различным: до 12 часов – «Доброе утро», с 12 до 17 – «Добрый день», начиная с 17 часов – «Добрый вечер». Каждый
    раз при входе очередного сотрудника в офис, все пришедшие ранее его приветствуют. При уходе сотрудника домой с ним также прощаются все
    присутствующие. Вызов процедуры приветствия/прощания производить через групповые делегаты. Факт прихода и ухода
    сотрудника отслеживается через генерируемые им события. Событие прихода описывается делегатом, передающим в числе параметров
    наследника EventArgs, явно содержащего поле с временем прихода. Продемонстрировать работу офиса при последовательном приходе и
    уходе сотрудников.
    */

    public delegate bool Delegate(string str1, string str2);

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Person[] princes = { //todo pn православненько
                new Person("Рюрик"),
                new Person("Олег"),
                new Person("Игорь"),
                new Person("Святослав")
            };

            Office rus = new Office();
            rus.Came(princes[0], new DateTime(862, 6, 1, 11, 1, 0));
            rus.Came(princes[1], new DateTime(862, 6, 1, 11, 2, 0));
            rus.Came(princes[2], new DateTime(862, 6, 1, 15, 1, 0));
            rus.Gone(princes[0]);
            rus.Came(princes[3], new DateTime(862, 6, 1, 18, 1, 0));
            rus.Gone(princes[1]);
            rus.Gone(princes[2]);
            rus.Gone(princes[3]);

            Console.ReadKey();
        }
    }
}
