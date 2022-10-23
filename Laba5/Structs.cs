using System;
using System.Collections.Generic;
using System.Text;

namespace Laba5
{
    enum Operations
    {
        Add,
        Delete,
        Display = 6,
        SearchTotal,
        SearchDensity,
        Count
    }
    public struct Sum //структура
    {
        public int Dollar;
        public int Cent;
        public Sum(int dollar, int cent)
        {
            this.Dollar = dollar;
            this.Cent = cent;
        }
    }
    public class GymContainer //класс-контейнер для хранения разных типов объектов в виде списка или массива (использовать абстрактный тип данных)
    {
        public List<Gym> gym;
        public GymContainer()
        {
            gym = new List<Gym>();
        }
        public void Delete(int index)
        {
            gym.RemoveAt(index);
        }
        public void Add(Gym item)
        {
            gym.Add(item);
        }
        public void Display()
        {
            foreach (Gym item in gym)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    public class GymWrap : GymContainer //класс-контроллер, который управляет объектом-контейнером
    {
        public void SearchTotal(Sum total)
        {
            int flagSearch = 0;
            Console.WriteLine("\nПоиск экипировки которую можно купить на {0} долларов {1} центов", total.Dollar, total.Cent);
            foreach (Gym item in gym)
            {
                if (item.Sum.Dollar <= total.Dollar)
                {
                    Console.WriteLine("В диапазон входит и стоит {0} дол. и {1} центов снаряд формы {2} ", item.Sum.Dollar, item.Sum.Cent, item.Shape);
                    flagSearch++;
                }
                else if (flagSearch != 0)
                    Console.WriteLine("Такая цена не найдена.");
            }
        }
        public int Count()
        {
            Console.WriteLine("\nКоличество экипировки в спортзале составляет: " + gym.Count);
            return gym.Count;
        }
        public void SearchDensity(int dens)
        {
            for (int i = 0; i < gym.Count; i++)
            {
                if (gym[i] is Mat)
                {
                    Console.WriteLine("\nПлотность " + dens + " имеет мат формы " + gym[i].Shape );
                }
            }
        }
    }

    public class BallContainer //класс-контейнер для хранения разных типов объектов в виде списка или массива (использовать абстрактный тип данных)
    {
        public List<Ball> ball;
        public BallContainer()
        {
            ball = new List<Ball>();
        }
        public void Delete(int index)
        {
            ball.RemoveAt(index);
        }
        public void Add(Ball item)
        {
            ball.Add(item);
        }
        public void Display()
        {
            foreach (Ball item in ball)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    public class BallWrap : BallContainer //класс-контроллер, который управляет объектом-контейнером
    {
        public void SearchTotal(Sum total)
        {
            int flagSearch = 0;
            Console.WriteLine("\nПоиск экипировки которую можно купить на {0} долларов {1} центов", total.Dollar, total.Cent);
            foreach (Ball item in ball)
            {
                if (item.Sum.Dollar <= total.Dollar)
                {
                    Console.WriteLine("В диапазон входит и стоит {0} дол. и {1} центов мячик с названием {2} ", item.Sum.Dollar, item.Sum.Cent, item.Name);
                    flagSearch++;
                }
                else if (flagSearch != 0)
                    Console.WriteLine("Такая цена не найдена.");
            }
        }
        public int Count()
        {
            Console.WriteLine("\nКоличество мячиков в спортзале составляет: " + ball.Count);
            return ball.Count;
        }
        public void SearchDensity(int dens)
        {
            for (int i = 0; i < ball.Count; i++)
            {
                if (ball[i] is VolleyBall)
                {
                    Console.WriteLine("\nПлотность надутия " + dens + " имеет мячик формы " + ball[i].Name );
                }
            }
        }
    }
}
