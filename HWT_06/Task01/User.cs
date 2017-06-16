namespace Task01
{
    using System;

    public class User
    {
        private const int NameIndex = 0;
        private const int SurnameIndex = 1;
        private const int PatronimIndex = 2;

        private string[] name = new string[3];
        private int? years;
        private DateTime? birth;        
        
        public User(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public User(string name, string surname, string patronim)
        {
            this.Name = name;
            this.Surname = surname;
            this.Patronim = patronim;
        }

        public User(string name, string surname, string patronim, int old)
        {
            this.Name = name;
            this.Surname = surname;
            this.Patronim = patronim;
            this.Old = old;
        }

        public User(string name, string surname, string patronim, DateTime birthday)
        {
            this.Name = name;
            this.Surname = surname;
            this.Patronim = patronim;
            this.Birthday = birthday;
        }

        public string Name
        {
            get
            {
                return this.name[NameIndex];
            }

            set
            {
                if (value != string.Empty)
                {
                    this.name[NameIndex] = value;
                }
            }
        }

        public string Surname
        {
            get
            {
                return this.name[SurnameIndex];
            }

            set
            {
                if (value != string.Empty)
                {
                    this.name[SurnameIndex] = value;
                }
            }
        }

        public string Patronim
        {
            get
            {
                return this.name[PatronimIndex];
            }

            set
            {
                this.name[PatronimIndex] = value;
            }
        }

        public int Old
        {
            get
            {
                if (!this.years.HasValue)
                {
                    throw new Exception(Properties.Resources.AGE_NOT_SPICIFIED_STRING);
                }

                return (int)this.years;
            }

            set
            {
                if (value > -1)
                {
                    this.years = value;
                    this.birth = DateTime.Today.AddYears(-1 * value);
                }
            }
        }

        public DateTime Birthday
        {
            get
            {
                if (!this.birth.HasValue)
                {
                    throw new Exception(Properties.Resources.BIRTHDAY_NOT_SPICIFIED_STRING);
                }

                return (DateTime)this.birth;
            }

            set
            {
                this.birth = value;
                this.years = value.Year - DateTime.Today.Year;
            }
        }

        public string Fullname
        {
            get
            {
                return string.Format("{0} {1} {2}", this.Name, this.Surname, this.Patronim);
            }
        }
    }
}
