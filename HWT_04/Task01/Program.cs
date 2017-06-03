namespace Task01
{
    using System;
    using System.Text;

    /*
    Написать программу, которая определяет среднюю длину слова во
    введенной текстовой строке. Учесть, что символы пунктуации на длину
    слов влиять не должны. Регулярные выражения не использовать. И не
    пытайтесь прописать все ручками. Используйте стандартные методы
    класса String.
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string str;
            int len = 0;
            int num = 0;

            Console.WriteLine("Введите строку:");
            str = Console.ReadLine();
            
            for (int i = 0; i < str.Length; i++)
            {
                // IsSepearator(',') возвращает false, поэтому добавил IsPunctuation
                if (char.IsSeparator(str[i]) || char.IsPunctuation(str[i]))
                {
                    if (i > 0)
                    {
                        len += i;
                        num++;
                    }

                    str = str.Remove(0, i + 1);
                    i = -1;                    
                }
            }

            if (str.Length > 0)
            {
                len += str.Length;
                num++;
            }

            Console.WriteLine("В строке {0} слов. Средняя длина слова равна {1:0.00}", num, (double)len / num);

            Console.ReadKey();
        }
    }
}
