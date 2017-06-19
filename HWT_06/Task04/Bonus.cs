namespace Task04
{
    public class Bonus : GameObject
    {
        public const bool SeeThrow = true;//todo pn аналогично
        public const bool AttackThrow = true;
        public const bool Destroyable = false;

        public virtual void Effect(Player p)
        {
        }
    }

    public class Chicken : Bonus
    {
        public override void Effect(Player p)
        {
            p.Strangth += 10;
        }
    }

    public class Apple : Bonus
    {
        public override void Effect(Player p)
        {
            p.Agility += 10;
        }
    }

    public class Cheery : Bonus
    {
        public override void Effect(Player p)
        {
            p.Speed += 10;
        }
    }
}
