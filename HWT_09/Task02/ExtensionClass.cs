namespace Task02
{
    public static class ExtensionClass
    {
        public static bool PositiveInteger(this string str)
        {
            bool isNil = true;
            var enumer = str.GetEnumerator();
            while (enumer.MoveNext())
            {
                if (!char.IsDigit(enumer.Current))//todo pn некорректно работает при 0
                {
                    return false;
                }
                if (enumer.Current != '0')
                {
                    isNil = false;
                }
            }

            if(isNil)
            {
                return false;
            }

            return true;
        }
    }
}
