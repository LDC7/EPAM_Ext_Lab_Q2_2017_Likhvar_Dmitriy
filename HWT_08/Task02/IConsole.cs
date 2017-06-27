namespace Task02
{
    using System;

    public interface IConsole
    {
        void Print(string format, params string[] strs);
    }
}
