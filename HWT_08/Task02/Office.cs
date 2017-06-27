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
            p.Coming();
            OnCame(p, dt);
            list.Add(p);
            Hello += p.Hello;
            Bye += p.Bye;
        }

        public void Gone(Person p)
        {
            p.Leaving();       
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
