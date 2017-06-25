namespace Task02
{
    using System;

    public class Person
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
                Console.WriteLine("Доброе утро, {0}. - сказал {1}", ((Person)p).Name, this.Name);
            }
            else if (((TimeEventArgs)e).time.Hour < 17)
            {
                Console.WriteLine("Добрый день, {0}. - сказал {1}", ((Person)p).Name, this.Name);
            }
            else
            {
                Console.WriteLine("Добрый вечер, {0}. - сказал {1}", ((Person)p).Name, this.Name);
            }
        }

        public void Bye(object p, EventArgs e)
        {
            Console.WriteLine("Пока, {0}. - сказал {1}", ((Person)p).Name, this.Name);
        }
    }
}
