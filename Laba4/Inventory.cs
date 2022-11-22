using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4
{
    internal abstract class Inventory //Абстрактный класс
    {
        public Ball Ball1; // Композиция - Inventory содержит объект класса Ball
        public int GymNumber; // Номер зала
        public int Month; // Когда завезли в зал (месяц 1-12)

        public Inventory() { }

        protected Inventory(int gym, int month)
        {
            GymNumber = gym;
            Month = month;
        }
        public override string ToString() //Переопределение метода ToString
        {
            return "Инвентарь зала номер " + GymNumber + ", завезённый в " + Month + " месяце 2021 года.";
        }
        public abstract bool DoClone(); // Одноименный метод
        public virtual void DoSomething() // Виртуальный метод
        {
            Console.WriteLine("Вы вызвали DoSomething. Поздравляем!");
        }
    }
}
