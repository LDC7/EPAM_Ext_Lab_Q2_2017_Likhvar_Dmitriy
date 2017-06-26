namespace Task02
{
    using System;
    using System.Collections.Generic;

    public class Office
    {
        private List<Person> list = new List<Person>();

        private event EventHandler Hello;
        private event EventHandler Bye;

        public void Came(Person p, DateTime dt)
        {
            Console.WriteLine("*** Пришёл {0}!", p.Name);//todo pn так, в отдельном классе не должно быть зависимостей от других классов (в твоём случае от класса вывода данных)
            OnCame(p, dt);
            list.Add(p);
            Hello += p.Hello;
            Bye += p.Bye;
        }

        public void Gone(Person p)
        {
            Console.WriteLine("*** {0} ушёл!", p.Name);            
            Hello -= p.Hello;
            Bye -= p.Bye;
            OnGone(p);
            list.Remove(p);
        }

        protected void OnCame(Person p, DateTime dt)
        {
            if (Hello != null)
            {
                Hello.Invoke(p, new TimeEventArgs(dt));
            }
        }

        protected void OnGone(Person p)
        {
            if (Bye != null)
            {
                Bye.Invoke(p, EventArgs.Empty);
            }
        }
    }
}
