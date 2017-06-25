namespace Task02
{
    using System;

    public class TimeEventArgs : EventArgs
    {
        public DateTime time;

        public TimeEventArgs(DateTime dt)
        {
            this.time = dt;
        }
    }
}
