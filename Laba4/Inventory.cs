using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4
{
    public abstract class Inventory //Абстрактный класс
    {
        public int gymNumber; // Номер зала
        public int Month; // Когда завезли в зал (месяц 1-12)

        public Inventory() { }

        protected Inventory(int gym, int month)
        {
            gymNumber = gym;
            Month = month;
        }
        public override string ToString() //Переопределение метода ToString
        {
            return "Инвентарь зала номер " + gymNumber + ", завезённый в " + Month + " месяце 2021 года.";
        }
        public abstract bool DoClone(); // Одноименный метод
        public virtual void DoSomething() // Виртуальный метод
        {
            Console.WriteLine("Вы вызвали DoSomething. Поздравляем!");
        }
    }
}
