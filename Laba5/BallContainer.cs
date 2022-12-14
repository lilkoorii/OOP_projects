using System;
using System.Collections.Generic;
using System.Text;

namespace Laba5
{
    public class BallContainer //класс-контейнер для хранения разных типов объектов в виде списка
    {
        public List<Balls> ball;
        public BallContainer()
        {
            ball = new List<Balls>();
        }
        public void Delete(int index)
        {
            ball.RemoveAt(index);
        }
        public void Add(Balls item)
        {
            ball.Add(item);
        }
        public void Display()
        {
            foreach (Balls item in ball)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    public class BallControl : BallContainer //класс-контроллер, который управляет объектом-контейнером
    {
        public void SearchTotal(Sum total)
        {
            int flagSearch = 0;
            Console.WriteLine("\nПоиск экипировки которую можно купить на {0} долларов {1} центов...", total.Dollar, total.Cent);
            foreach (Balls item in ball)
            {
                if (item.Sum.Dollar <= total.Dollar && item.Sum.Cent <= total.Cent)
                {
                    Console.WriteLine("В диапазон входит и стоит {0} дол. и {1} центов мячик с названием {2} ", item.Sum.Dollar, item.Sum.Cent, item.Name);
                    flagSearch++;
                }
                else if (flagSearch != 0)
                    Console.WriteLine("Эта цена не вписывается в сумму");
            }
        }
        public int Count()
        {
            Console.WriteLine("\nКоличество наборов мячиков в спортзале составляет: " + ball.Count);
            return ball.Count;
        }
        public void SearchDensity(int dens)
        {
            if (dens<=0)
            {
                throw new SearchDensityException("Ошибка! Неккоректно введена степень надутия для поиска:", dens);
            }
            for (int i = 0; i < ball.Count; i++)
            {
                if (ball[i] is VolleyBall)
                {
                    Console.WriteLine("\nПлотность надутия " + dens + " имеет мячик формы " + ball[i].Name);
                }
            }
        }
    } //класс-контролер
}
