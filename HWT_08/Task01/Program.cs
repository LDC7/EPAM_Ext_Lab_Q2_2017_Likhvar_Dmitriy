namespace Task01
{
    using System;
    using System.Text;

    public delegate bool Delegate(string str1, string str2);

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Delegate del = CheckStr;
            string[] strarr = {
                "abv",
                "bvg",
                "abb",
                "tutu",
                "parampampam",
                "chagachaga",
                "bipbip"
            };

            Console.WriteLine(string.Join(" ", strarr));
            SortStr(del, strarr);
            Console.WriteLine(string.Join(" ", strarr));

            Console.ReadKey();
        }

        public static bool CheckStr(string s1, string s2)
        {
            if (s1.Length == s2.Length)
            {
                for (int i = 0; i < s1.Length && i < s2.Length; i++)
                {
                    if (s1[i] > s2[i])
                    {
                        return true;
                    }

                    if (s1[i] < s2[i])
                    {
                        return false;
                    }
                }
            }
            else if (s1.Length > s2.Length)
            {
                return true;
            }

            return false;
        }

        public static void SortStr(Delegate d, string[] arr)
        {
            bool flag = true;
            string buf;

            while (flag)
            {
                flag = false;
                for (int i = 1; i < arr.Length; i++)
                {
                    if (d(arr[i - 1], arr[i]))
                    {
                        buf = arr[i - 1];
                        arr[i - 1] = arr[i];
                        arr[i] = buf;
                        flag = true;
                    }
                }
            }
        }
    }
}
