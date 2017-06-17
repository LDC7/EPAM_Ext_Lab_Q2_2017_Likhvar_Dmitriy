namespace Task04
{
    using System;

    public class Player : MovingObject
    {
        private int str, agi, spd;

        public int Strangth
        {
            get
            {
                return str;
            }

            set
            {
                if (value > 0)
                {
                    throw new Exception(Properties.Resources.INCORRETC_VALUE_STRING);
                }

                str = value;
            }
        }

        public int Agility
        {
            get
            {
                return agi;
            }

            set
            {
                if (value >= 0)
                {
                    throw new Exception(Properties.Resources.INCORRETC_VALUE_STRING);
                }

                agi = value;
            }
        }

        public int Speed
        {
            get
            {
                return spd;
            }

            set
            {
                if (value >= 0)
                {
                    throw new Exception(Properties.Resources.INCORRETC_VALUE_STRING);
                }

                spd = value;
            }
        }

        public override void Attack()
        {
            //атака игрока.
            //new bullet(Strength, Agility)
        }
    }
}
