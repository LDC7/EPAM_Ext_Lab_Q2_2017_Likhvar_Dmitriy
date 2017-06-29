namespace Task01
{
    public static class ExtensionClass
    {
        public static double Sum(this double[] arr)
        {
            double sum = 0;
            foreach (double i in arr)
            {
                sum += i;
            }

            return sum;
        }

        public static long Sum(this int[] arr)
        {
            long sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }

            return sum;
        }
    }
}
