namespace Task03
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DynamicArray<T> : IEnumerable<T>, IEnumerator<T>
    {
        private T[] array;
        private int len = 0;
        private int pos = -1;

        public DynamicArray()
        {
            pos = -1;
            this.array = new T[8];
        }

        public DynamicArray(int n)
        {
            pos = -1;
            this.array = new T[n];
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            pos = -1;
            this.array = new T[1];
            this.AddRange(collection);
        }

        public void Add(T element)
        {
            if (this.len >= this.array.Length)
            {
                T[] newarr = new T[this.array.Length * 2];//todo pn многовато берешь. Т.е. если у тебя массив на 1млн элементов и захотели в него добавить 10, то ты им ещё 1млн подаришь. Не круто. Лучше увеличивать на какое-то не очень большое число. (в принципе, на любое, которое ты вынесешь в константу и которое, если что, можно поправить)
                this.array.CopyTo(newarr, 0);
                this.array = newarr;
            }

            this.array[this.len] = element;
            this.len++;
            pos = -1;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            int count = 0;
            IEnumerator<T> enumer = collection.GetEnumerator();
            while (enumer.MoveNext())
            {
                count++;
            }

            if (this.array.Length < this.len + count + 1)
            {
                T[] newarr = new T[this.len + count + 1];
                this.array.CopyTo(newarr, 0);
                this.array = newarr;
            }

            enumer.Reset();
            for (int i = this.len; enumer.MoveNext(); i++)
            {
                this.array[i] = enumer.Current;
            }
            len += count;
            pos = -1;
        }

        public bool Remove(T element)
        {
            for (int i = 0; i < this.len; i++)
            {
                if (this.array[i].Equals(element))
                {
                    for (int j = i + 1; j < this.len; j++)
                    {
                        this.array[j - 1] = this.array[j];
                    }

                    this.len--;
                    pos = -1;
                    return true;
                }
            }

            return false;
        }

        public bool Insert(T element, int index)
        {
            if (index < 0 || index >= this.array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.len == this.array.Length)
            {
                T[] newarr = new T[this.len + 1];
                this.array.CopyTo(newarr, 0);
                this.array = newarr;
            }

            for (int i = this.len - 1; i > index; i--)
            {
                this.array[i + 1] = this.array[i];
            }

            this.array[index] = element;
            len++;
            pos = -1;

            return true;
        }

        public int Length
        {
            get
            {
                return this.len;
            }
        }

        public int Capacity
        {
            get
            {
                return this.array.Length;
            }
        }

        public bool MoveNext()
        {
            this.pos++;
            return (this.pos < this.Length);
        }

        public void Reset()
        {
            this.pos = -1;
        }

        public T Current
        {
            get
            {
                try
                {
                    return this.array[this.pos];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Dispose()//todo pn а у тебя есть здесь неуправляемые ресурсы? и нужно будет не просто метод с таким именем писать, а реализовывать интерфейс IDisposable.
		{
            //без понятия что здесь должно быть
            pos = -1;
        }

        public T this[int i]
        {
            get
            {
                if (i < 0 || i >= this.len)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.array[i];
            }

            set
            {
                if (i < 0 || i >= this.len)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.array[i] = value;
            }
        }
    }
}
