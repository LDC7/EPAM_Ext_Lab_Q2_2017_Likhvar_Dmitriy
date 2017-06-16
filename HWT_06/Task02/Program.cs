namespace Task02
{
    using System;
    using System.Text;

    /*
    Создать класс Ring (кольцо), описываемое координатами центра,
    внешним и внутренним радиусами, а также свойствами, позволяющими
    узнать площадь кольца и суммарную длину внешней и внутренней
    границ кольца. Обеспечить нахождение класса в заведомо корректном
    состоянии.
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            try
            {
                Ring r = new Ring(0, 0, 1, 2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
