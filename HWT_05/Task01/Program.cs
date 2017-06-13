namespace Task01
{
    using System;
    using System.Text;

    /*
    Написать класс Round, задающий круг с указанными координатами центра, радиусом,
    а также свойствами, позволяющими узнать длину описанной окружности и площадь круга.
    Обеспечить нахождение объекта в заведомо корректном состоянии.
    Написать программу, демонстрирующую использование данного круга.
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Round rnd = new Round();
            Console.WriteLine("Неинициализированный круг:");
            Console.WriteLine("X = {0}", rnd.x);
            Console.WriteLine("Y = {0}", rnd.y);
            Console.WriteLine("R = {0}", rnd.Radius);
            Console.WriteLine("\nИнициализированный круг:");
            rnd = new Round(1, 2, 3);
            Console.WriteLine("X = {0}", rnd.x);
            Console.WriteLine("Y = {0}", rnd.y);
            Console.WriteLine("R = {0}", rnd.Radius);
            Console.WriteLine("Длина окружности = {0}", rnd.Length);
            Console.WriteLine("Площадь круга = {0}", rnd.Space);
            Console.WriteLine("\nПрисвоение некорректного радиуса:");
            rnd.Radius = -100;

            Console.ReadKey();
        }
    }

    public class Round//todo pn лучше чтобы в файле был только один класс. Так проще понимать, с чем имеешь дело.
    {
        public double x = 0, y = 0;//todo pn почему не свойствами?  
        protected double r = 0;//todo pn лучше сделать приватным, потому что это вспомогательное поле и все потомки теоретически должны обращаться к свойству Radius

		public Round()
        {
        }

        public Round(double x, double y, double rad)
        { 
            this.x = x;
            this.y = y;
            this.Radius = rad;
        }

        public virtual double Radius
        {
            get
            {
                if (this.r > 0)
                {
                    return this.r;
                }
                else//todo pn лишний
                {
                    Console.WriteLine(Properties.Resources.UNINITIALIZED_RADIUS_STRING);//todo pn не очень хорошо что-то в лог писать в геттере или сеттере. Лучше создай какой-нибудь класс или метод и туда всю логику записи в лог перемести.
                    return 0;
                }
            }

            set
            {
                if (value > 0)
                {
                    this.r = value;
                }
                else
                {
                    Console.WriteLine(Properties.Resources.INCORRECT_RADIUS_STRING);//todo pn  Лучше выкидывай исключение и где-нибудь на уровень выше перехватывай и обрабатывай его. Помню, что говорил не использовать исключения, но все таки)
				}
            }
        }

        public double Length
        {
            get
            {
                if (this.r > 0)
                {
                    return 2 * Math.PI * this.r;
                }
				else//todo pn лишний
				{
                    Console.WriteLine(Properties.Resources.UNINITIALIZED_RADIUS_STRING);//todo pn тем более у тебя повторяются реакции на исключительные ситуации.
                    return 0;
                }
            }

            set
            {
                if (value > 0)
                {
                    this.r = value / (2 * Math.PI);
                }
                else
                {
                    Console.WriteLine(Properties.Resources.INCORRECT_LENGTH_STRING);
                }
            }
        }

        public double Space
        {
            get
            {
                if (this.r > 0)
                {
                    return Math.PI * this.r * this.r;
                }
				else//todo pn лишний
				{
                    Console.WriteLine(Properties.Resources.UNINITIALIZED_RADIUS_STRING);
                    return 0;
                }
            }

            set
            {
                if (value > 0)
                {
                    this.r = Math.Sqrt(value / Math.PI);
                }
                else
                {
                    Console.WriteLine(Properties.Resources.INCORRECT_SPACE_STRING);
                }
            }
        }
    }
}
