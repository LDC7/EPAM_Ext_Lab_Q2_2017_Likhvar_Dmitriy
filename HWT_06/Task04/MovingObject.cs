namespace Task04
{
    public class MovingObject
    {
        public const bool SeeThrow = true;
        public const bool AttackThrow = false;
        public const bool Destroyable = true;
        public double Vx, Vy; //вектор движения
        public int HP;

        public virtual void Attack()
        {
            //стандартная атака для всех движущихся объектов.
        }
    }
}
