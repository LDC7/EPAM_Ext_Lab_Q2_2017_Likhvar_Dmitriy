namespace Task01
{
    using System;

    public static class ExtensionClass
    {
        public static double Sum<T>(this T[] arr) where T : IConvertible
        {
            double sum = 0;
            foreach (T i in arr)
            {
                sum += Convert.ToDouble(i);
            }

            return sum;
        }
    }
}
