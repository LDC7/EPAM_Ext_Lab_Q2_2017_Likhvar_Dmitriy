namespace Task03
{
    using System;
    using System.Text;
    using System.Diagnostics;

    /*
    Проведите сравнительный анализ скорости работы классов String и
    StringBuilder для операции сложения строк
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string str;
            StringBuilder sb;
            Stopwatch sw = new Stopwatch();
            int n;

            for (int i = 0; i < 10; i++)
            {
                str = string.Empty;
                sb = new StringBuilder();

                n = (i + 1) * 10;

                Console.Write("{0:000}) \t", n);
                                
                sw.Restart();

                for (int j = 0; j < n; j++)
                {
                    str += "*";
                }

                sw.Stop();
                Console.Write("{0} \t", sw.Elapsed);

                sw.Restart();

                for (int j = 0; j < n; j++)
                {
                    sb.Append("*");
                }

                sw.Stop();
                Console.Write("{0}\n", sw.Elapsed);
            }

            Console.ReadKey();
        }
    }
}
