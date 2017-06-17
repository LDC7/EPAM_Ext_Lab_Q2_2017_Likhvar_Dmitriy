namespace Task04
{
    public class Monster : MovingObject
    {
        public bool Triggered;

        public override void Attack()
        {
            //атака монстра по умолчанию
        }

        public virtual void Moving()
        {
            //движение монстра по умолчанию
        }
    }

    public class Monster1 : Monster
    {
        public override void Attack()
        {
            //атака монстра 1
        }

        public override void Moving()
        {
            //движение 1 монстра
        }
    }

    public class Monster2 : Monster
    {
        public override void Attack()
        {
            //атака монстра 2
        }

        public override void Moving()
        {
            //движение 2 монстра
        }
    }
}