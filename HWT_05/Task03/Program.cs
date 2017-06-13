namespace Task03
{
    using System;
    using System.Text;

    /*
    Написать класс User, описывающий человека (Фамилия, Имя, Отчество, Дата рождения, Возраст).
    Написать программу, демонстрирующую использование этого класса.
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            User man = new User("Иван", "Иванов");
            Console.WriteLine(man.Fullname);

            man = new User("Петя", "Петров", "Петрович");
            Console.WriteLine(man.Fullname + ' ' + man.Old);
            Console.WriteLine(man.Fullname + ' ' + man.Birthday);

            man = new User("Федя", "Фёдоров", "Фёдорович", 10);
            Console.WriteLine(man.Fullname + ' ' + man.Old);
            Console.WriteLine(man.Fullname + ' ' + man.Birthday);

            Console.ReadKey();
        }
    }

    public class User
    {
        private string[] name = new string[3];
        private int? years;
        private DateTime? birth;

        public User(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public User(string name, string surname, string patronim)
        {
            this.Name = name;
            this.Surname = surname;
            this.Patronim = patronim;
        }

        public User(string name, string surname, string patronim, int old)
        {
            this.Name = name;
            this.Surname = surname;
            this.Patronim = patronim;
            this.Old = old;
        }

        public User(string name, string surname, string patronim, DateTime birthday)
        {
            this.Name = name;
            this.Surname = surname;
            this.Patronim = patronim;
            this.Birthday = birthday;
        }

        public string Name
        {
            get
            {
                return this.name[0];//todo pn индекс тоже лучше в константу, мало ли что изменится
            }

            set
            {
                if (value != string.Empty)
                {
                    this.name[0] = value;
                }
            }
        }

        public string Surname
        {
            get
            {
                return this.name[1];
            }

            set
            {
                if (value != string.Empty)
                {
                    this.name[1] = value;
                }
            }
        }

        public string Patronim
        {
            get
            {
                return this.name[2];
            }

            set
            {
                this.name[2] = value;
            }
        }

        public int Old
        {
            get
            {
                if (this.years == null)//todo pn лучше через .HasValue
                {
                    Console.WriteLine(Properties.Resources.AGE_NOT_SPICIFIED_STRING);
                    return -1;                        
                }
				else//todo pn лишний
				{
                    return (int)this.years;
                }
            }

            set
            {
                if (value > -1)
                {
                    this.years = value;
                    this.birth = DateTime.Today.AddYears(-1 * value);
                }
            }
        }

        public DateTime Birthday
        {
            get
            {
                if (this.birth == null)//todo pn лучше через .HasValue
				{
                    Console.WriteLine(Properties.Resources.BIRTHDAY_NOT_SPICIFIED_STRING);
                    return DateTime.Today.AddDays(1);
                }
				else//todo pn лишний
				{
                    return (DateTime)this.birth;
                }
            }

            set
            {
                this.birth = value;
                this.years = value.Year - DateTime.Today.Year;
            }
        }

        public string Fullname
        {
            get
            {
                return this.Name + ' ' + this.Surname + ' ' + this.Patronim;//todo pn атата string.Format, во-первых. Во-вторых, ты соединяешь строки с символами, нафига тебе лишние операции приведения типов?
            }
        }
    }
}
