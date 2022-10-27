using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    internal class Bench : Inventory // Скамейка
    {
        public Inventory inv; // Композиция - Bench содержит объект класса Inventory
        public override bool DoClone()
        {
            return true;
        }
        public int Height;
        public Bench() { }
        public Bench(int height, int gym, int Month)
        {
            this.Height = height;
            this.gymNumber = gym;
            this.Month = Month;
        }
        public sealed override void DoSomething() // переопределение виртуального метода с запечатыванием (sealed)
        {
            Console.WriteLine("Вы вызвали переопределённый запечатанный метод DoSomething. Поздравляем!");
        }
        public override string ToString() //Во всех классах (иерархии) переопределить метод ToString(), который выводит информацию о типе объекта и его текущих значениях.
        {
            return "Скамейка из зала номер " + gymNumber + ", завезённая в зал в " + Month + " месяце имеет высоту " + Height + " см.";
        }
    }
}
