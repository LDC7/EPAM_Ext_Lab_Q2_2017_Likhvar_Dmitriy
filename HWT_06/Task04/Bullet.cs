namespace Task04
{
    public class Bullet : MovingObject
    {
        public int Damage;

        public Bullet(int dmg, int spd)
        {
            Damage = dmg;
            //+ вычисление вектора движения с заданой скоростью
        }
    }
}
