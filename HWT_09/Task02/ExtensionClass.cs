namespace Task02
{
    public static class ExtensionClass
    {
        public static bool PositiveInteger(this string str)
        {
            var enumer = str.GetEnumerator();
            while (enumer.MoveNext())
            {
                if (!char.IsDigit(enumer.Current))//todo pn некорректно работает при 0
                {
                    return false;
                }
            }

            return true;
        }
    }
}
