namespace Task02
{
    using System;

    public class Person : IConsole
    {
        public string Name;

        public Person(string name)
        {
            this.Name = name;
        }

        public void Hello(object p, EventArgs e)
        {
            if (((TimeEventArgs)e).time.Hour < 12)
            {
                Print("Доброе утро, {0}. - сказал {1}", ((Person)p).Name, this.Name);
            }
            else if (((TimeEventArgs)e).time.Hour < 17)
            {
                Print("Добрый день, {0}. - сказал {1}", ((Person)p).Name, this.Name);
            }
            else
            {
                Print("Добрый вечер, {0}. - сказал {1}", ((Person)p).Name, this.Name);
            }
        }

        public void Bye(object p, EventArgs e)
        {
            Print("Пока, {0}. - сказал {1}", ((Person)p).Name, this.Name);
        }

        public void Coming()
        {
            Print("*** Пришёл {0}!", this.Name);
        }

        public void Leaving()
        {
            Print("*** {0} ушёл!", this.Name);
        }      

        public void Print(string format, params string[] strs)
        {
            Console.WriteLine(format, strs);
        }
    }
}
