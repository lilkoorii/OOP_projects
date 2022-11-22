using System;
using System.Collections.Generic;
using System.Text;

namespace Laba5
{
    internal abstract class GymContainer : Gym //класс-контейнер
    {
        public List<Gym> Gym;
        public GymContainer()
        {
            Gym = new List<Gym>();
        }
        public void Delete(int index)
        {
            Gym.RemoveAt(index);
        }
        public void Add(Gym item)
        {
            Gym.Add(item);
        }
        public void Display()
        {
            foreach (Gym item in Gym)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    internal class GymControl : GymContainer //класс-контроллер, который управляет объектом-контейнером
    {
        public void SearchTotal(Sum total)
        {
            int flagSearch = 0;
            Console.WriteLine("\nПоиск экипировки которую можно купить на {0} долларов {1} центов...", total.Dollar, total.Cent);
            foreach (Gym item in Gym)
            {
                if (item.Sum.Dollar <= total.Dollar && item.Sum.Cent <= total.Cent)
                {
                    Console.WriteLine("В диапазон входит и стоит {0} дол. и {1} центов снаряд с формой {2} ", item.Sum.Dollar, item.Sum.Cent, item.Shape);
                    flagSearch++;
                }
                else if (flagSearch != 0)
                    Console.WriteLine("Эта цена не вписывается в сумму");
            }
        }
        public int Count()
        {
            Console.WriteLine("\nКоличество видов экипировки в спортзале составляет: " + Gym.Count);
            return Gym.Count;
        }
        public void SearchDensity(int dens)
        {
            for (int i = 0; i < Gym.Count; i++)
            {
                if (Gym[i] is Mat)
                {
                    Console.WriteLine("\nПлотность " + dens + " имеет мат формы " + Gym[i].Shape);
                }
            }
        }
    } 

}
