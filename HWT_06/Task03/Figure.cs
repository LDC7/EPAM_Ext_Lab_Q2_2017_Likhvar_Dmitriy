namespace Task03
{
    using System;

    public class Figure
    {
        public type name;

        public enum type //осталось от первоначальной версии... не требуется
        {
            Point = 1,
            Line,
            Circle,
            Bar,
            Round,
            Ring
        }

        public virtual void Print()
        {
            Console.WriteLine(Properties.Resources.UNDEFINED_FIGURE_STRING);
        }
    }
}
