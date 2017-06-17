namespace Task04
{
    public class Block : GameObject
    {
        public const bool SeeThrow = false;
        public const bool AttackThrow = false;
        public const bool Destroyable = true;
    }

    public class Stone : Block
    {
        public const bool SeeThrow = false;
        public const bool AttackThrow = false;
        public const bool Destroyable = false;
    }

    public class Tree : Block
    {
        public const bool SeeThrow = true;
        public const bool AttackThrow = false;
        public const bool Destroyable = false;
    }

    public class Wall : Block
    {
        public const bool SeeThrow = false;
        public const bool AttackThrow = false;
        public const bool Destroyable = true;
    }
}
