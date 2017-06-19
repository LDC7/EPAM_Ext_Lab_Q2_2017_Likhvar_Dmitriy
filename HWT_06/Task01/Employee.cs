namespace Task01
{
    using System;

    public class Employee : User
    {
        private int experience; //лет стажа
        private string post;

        public Employee(string name, string surname, string patronim, string post) : base(name, surname, patronim)
        {
            this.Post = post;
        }


        public int Experience
        {
            get
            {
                if (this.experience > 0)//todo pn нет проверки на возраст
                {
                    return this.experience;
                }

                return 0;
            }

            set
            {
                if (value < 0)
                {
                    throw new Exception(Properties.Resources.INVALID_VALUE_STRING);
                }

                this.experience = value;
            }
        }

        public string Post
        {
            get
            {
                if (this.post.Length < 1)
                {
                    throw new Exception(Properties.Resources.EMPTY_POST_STRING);
                }

                return this.post;
            }

            set
            {
                this.post = value;
            }
        } 
    }
}
