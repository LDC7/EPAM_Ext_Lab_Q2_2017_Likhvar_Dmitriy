namespace Task01
{
    using System;
    using System.Text;

    /*
    На основе класса User (см. задание 3 из предыдущей темы), создать
    класс Employee, описывающий сотрудника фирмы. В дополнение к
    полям пользователя добавить поля «стаж работы» и «должность».
    Обеспечить нахождение класса в заведомо корректном состоянии.
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            try
            {
                Employee emp = new Employee("Ivan", "Ivanov", "Ivanovich", "Doge of Nameburg");
                //нет задачи демонстрировать работу класса                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
            }

            Console.ReadKey();
        }
    }
}
