using System.Text;

namespace Task06
{
    using System;
    using System.Linq;
    /*
    Для выделения текстовой надписи можно использовать выделение жирным, курсивом и подчёркиванием.
    Предложите способ хранения информации о выделении надписи и напишите программу,
    которая позволяет назначать и удалять текстовой надписи выделение.
    */

    class Program //todo pn очень круто сделал, молодец!
    {
        enum Types
        {
            bold = 1,
            italic,
            underline
        }

        static void Main(string[] args)
        {
	        Console.InputEncoding = Encoding.Unicode;
	        Console.OutputEncoding = Encoding.Unicode;

			int n;
            bool[] flags = new bool[3];

            while (true)
            {
                Console.Clear();
                Console.Write("Параметры: {0}", flags.All(f => f == false) ? "None" : string.Empty);
                for (int i = 0; i < 3; i++)
                {
                    if (flags[i])
                    {
                        Console.Write("{0} ", (Types)(i + 1));
                    }
                }

                Console.WriteLine("\nВведите:");
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("\t\t{0}: {1}", i + 1, (Types)(i + 1));
                }

                Console.WriteLine("\t\t4: Clear");
                Console.WriteLine("\t\t5: Exit");

                int.TryParse(Console.ReadLine(), out n);

                if (n == 5)
                {
                    break;
                }

                if (n > 0 && n < 4)
                {
                    flags[n - 1] = !flags[n - 1];
                }

                if (n == 4)
                {
                    flags[0] = false;
                    flags[1] = false;
                    flags[2] = false;
                }
            }
        }
    }
}
