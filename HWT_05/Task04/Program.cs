namespace Task03
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /*
    Написать свой собственный класс MyString, описывающий строку как массив символов. Перегрузить для этого класса типовые операции.
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Console.WriteLine("Строка 1:");
            MyString mystr1 = "Abcde";
            Console.WriteLine((string)mystr1);

            Console.WriteLine("Строка 2:");
            char[] chararr = {'f', 'g', 'h', 'i', 'j'};
            MyString mystr2 = new MyString(chararr);
            Console.WriteLine((string)mystr2);

            Console.WriteLine("Сложение строк:");
            MyString mystr3 = mystr1 + mystr2;
            Console.WriteLine((string)mystr3);

            Console.WriteLine("Подстрока:");
            mystr3 = mystr2.MySubString(1, 3);
            Console.WriteLine((string)mystr3);

            Console.WriteLine("Верхний регистр:");
            mystr3.MyToUpperCase();
            Console.WriteLine((string)mystr3);

            Console.WriteLine("Нижний регистр:");
            mystr3.MyToLowerCase();
            Console.WriteLine((string)mystr3);

            Console.WriteLine("Вставить:");
            mystr3.MyInsert(1, ("blabla").ToCharArray());
            Console.WriteLine((string)mystr3);

            Console.WriteLine("Удалить:");
            mystr3.MyRemove(5, 2);
            Console.WriteLine((string)mystr3);

            Console.WriteLine("Поиск символа 'b':");
            Console.WriteLine(mystr3.MyIndexOf('b'));

            Console.WriteLine("Поиск последнего символа 'b':");
            Console.WriteLine(mystr3.MyLastIndexOf('b'));

            Console.WriteLine("Разделение:");
            mystr3 = "str1 str2";
            Console.WriteLine((string)mystr3);
            MyString[] mystrarr = mystr3.MySplit(' ');
            Console.WriteLine((string)mystrarr[0]);
            Console.WriteLine((string)mystrarr[1]);

            Console.ReadKey();
        }
    }

    public class MyString
    {
        private char[] arr;

        public MyString()
        {
        }

        public MyString(string str)
        {
            this.arr = str.ToCharArray();
        }

        public MyString(char[] chararr)
        {
            this.arr = (char[])chararr.Clone();
        }

        public char this[int i]
        {
            get
            {
                return this.arr[i];
            }

            set
            {
                this.arr[i] = value;
            }
        }

        public static MyString operator +(MyString f, MyString s)
        {
            char[] newarr = new char[f.Length + s.Length];
            ((char[])f).CopyTo(newarr, 0);
            ((char[])s).CopyTo(newarr, f.Length);
            return new MyString(newarr);
        }
        
        public static implicit operator MyString(string str)
        {
            return new MyString(str);
        }

        public static implicit operator string(MyString str)
        {
            return new string(str);
        }

        public static implicit operator char[](MyString str)
        {
            return str.arr;
        }

        public MyString MySubString(int index, int len)
        {
            if (index > -1 && len > 0 && index + len <= this.arr.Length)
            {
                char[] newarr = new char[len];
                for (int i = 0; i < len; i++)
                {
                    newarr[i] = this.arr[index + i];
                }

                return new MyString(newarr);
            }
            else
            {
                return string.Empty;
            }
        }

        public MyString[] MySplit(params char[] sep)
        {
            List<MyString> mystringlist = new List<MyString>();
            List<char> charlist = new List<char>();

            for (int i = 0; i < this.arr.Length; i++)
            {
                if (Array.Exists(sep, x => x == this.arr[i]))
                {
                    mystringlist.Add(new MyString(charlist.ToArray()));
                    charlist.Clear();
                }
                else
                {
                    charlist.Add(this.arr[i]);
                }
            }

            if (charlist.Count > 0)
            {
                mystringlist.Add(new MyString(charlist.ToArray()));
            }

            return mystringlist.ToArray();
        }

        public void MyToUpperCase()
        {
            for (int i = 0; i < this.arr.Length; i++)
            {
                if (char.IsLower(this.arr[i]))
                {
                    this.arr[i] = char.ToUpper(this.arr[i]);
                }
            }
        }

        public void MyToLowerCase()
        {
            for (int i = 0; i < this.arr.Length; i++)
            {
                if (char.IsUpper(this.arr[i]))
                {
                    this.arr[i] = char.ToLower(this.arr[i]);
                }
            }
        }

        public void MyInsert(int index, char[] s)
        {
            MyString newstr = this.MySubString(0, index) + new MyString(s) + this.MySubString(index, this.Length - index);
            this.arr = newstr.arr;
        }

        public int MyIndexOf(char c)
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (this.arr[i] == c)
                {
                    return i;
                }
            }

            return -1;
        }

        public int MyLastIndexOf(char c)
        {
            int ind = -1;
            for (int i = 0; i < this.Length; i++)
            {
                if (this.arr[i] == c)
                {
                    ind = i;
                }
            }

            return ind;
        }

        public void MyRemove(int index, int len)
        {
            MyString newstr = this.MySubString(0, index) + this.MySubString(index + len, this.Length - index - len);
            this.arr = newstr.arr;
        }

        public int Length
        {
            get
            {
                return this.arr.Length;
            }
        }        
    }
}
