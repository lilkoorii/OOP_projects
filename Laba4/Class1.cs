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

        protected Inventory() { }

        protected Inventory(int gym, int month)
        {
            gymNumber = gym;
            Month = month;
        }
        /*
        При наследовании нередко возникает необходимость изменить в классе-наследнике
        функционал метода, который был унаследован от базового класса. В этом случае
        класс-наследник может переопределять методы и свойства базового класса.
        
        Те методы и свойства, которые мы хотим сделать доступными для переопределения,
        в базовом классе помечается модификатором virtual. Такие методы и свойства называют виртуальными.
        А чтобы переопределить метод в классе-наследнике, этот метод определяется с модификатором override.
        Переопределенный метод в классе-наследнике должен иметь тот же набор параметров, что и виртуальный
        метод в базовом классе.
        */
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
    interface ICloneable // Интерфейс
    {
        bool DoClone(); // Одноименный метод DoClone()
    }
    abstract class BaseClone
    {
        public abstract bool DoClone();
    }

    class UserClass : BaseClone, ICloneable // Определение DoClone()
    {
        public override bool DoClone()
        {
            throw new NotImplementedException();
        }
    }
    public class Bench : Inventory
    {
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
        public sealed override void DoSomething() // Виртуальный метод
        {
            Console.WriteLine("Вы вызвали переопределённый запечатанный метод DoSomething. Поздравляем!");
        }
        public override string ToString() //Во всех классах (иерархии) переопределить метод ToString(), который выводит информацию о типе объекта и его текущих значениях.
        {
            return "Скамейка из зала номер " + gymNumber + ", завезённая в зал в " + Month + " месяце имеет высоту " + Height + " см.";
        }
    }

    class Bars : Inventory
    {
        public override bool DoClone()
        {
            return true;
        }
        public int personWeight;
        public Bars() { }
        public Bars(int weight, int gym, int Month)
        {
            this.personWeight = weight;
            this.gymNumber = gym;
            this.Month = Month;
        }
        public override string ToString()
        {
            return "Брусья, выдерживающие вес " + personWeight + "кг из зала номер " + gymNumber + ", завезены в зал в " + Month + " месяце.";
        }
    }
    class Ball : Inventory
    {
        public override bool DoClone()
        {
            return true;
        }
        public string Color;
        public string Brand;
        public Ball() { }
        public Ball(string brand, int gym, int Month, string Color)
        {
            this.Brand = brand;
            this.gymNumber = gym;
            this.Month = Month;
            this.Color = Color; // Цвет мяча (синего, желтого...)
        }
        public override string ToString()
        {
            return "Мячик " + Color + " цвета из зала номер " + gymNumber + ", завезенный в " + Month + " месяце выпущен брендом " + Brand;
        }
    }
    class BasketBall : Ball
    {
        public void Pull()
        {
            Console.WriteLine("Вы взяли из корзины баскетбольный мяч");
        }
        public override bool DoClone()
        {
            return true;
        }
        public string basketType;
        public BasketBall() { }
        public BasketBall(string brand, int gym, int Month, string basket)
        {
            this.Brand = brand;
            this.gymNumber = gym;
            this.Month = Month;
            this.basketType = basket; // Для маленьких, средних, больших корзин...
        }
        public override string ToString()
        {
            return "Баскетбольный мяч для " + basketType + " корзин из зала номер" + gymNumber + ", завезённый в зал в " + Month + " месяце был выпущен брендом " + Brand;
        }
    }
    sealed class Tennis : Ball // Sealed класс
    {
        public override bool DoClone()
        {
            return false;
        }
        public int Number;
        public string tennisType;
        public Tennis() { }
        public Tennis(int Number, string tennisType, int gym, int Month, string brand)
        {
            this.Number = Number;
            this.tennisType = tennisType;
            this.gymNumber = gym;
            this.Month = Month;
            this.Brand = brand;
        }
        public override string ToString()
        {
            return "Теннисный набор бренда " + Brand + " из зала номер " + gymNumber + ", завезённый в " + Month + " месяце содержит ракетки для " + tennisType + " тенниса и имеет в комплекте " + Number + " мячика/ов";
        }
    }
    
    /*Формальным параметром метода должна быть ссылка на абстрактный класс или наиболее
    общий интерфейс в вашей иерархии классов.В методе iIAmPrinting
    определите тип объекта и вызовите ToString(). В демонстрационной
    программе создайте массив, содержащий ссылки на разнотипные объекты
    ваших классов по иерархии, а также объект класса Printer и последовательно
    вызовите его метод IAmPrinting со всеми ссылками в качестве аргументов.*/
    class Printer //дополнительный класс Printer c полиморфным методом IAmPrinting(SomeAbstractClassorInterface someobj).
    {
        public string IAmPrinting(Inventory someobj)
        {
            return someobj.ToString();
        }
        public string IAmPrinting(Bench someobj)
        {
            return someobj.ToString();
        }
        public string IAmPrinting(Bars someobj)
        {
            return someobj.ToString();
        }
    }
}
