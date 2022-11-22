using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
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
            this.GymNumber = gym;
            this.Month = Month;
            this.Color = Color; // Цвет мяча (синего, желтого...)
        }
        public override string ToString()
        {
            return "Мячик " + Color + " цвета из зала номер " + GymNumber + ", завезенный в " + Month + " месяце выпущен брендом " + Brand;
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
            this.GymNumber = gym;
            this.Month = Month;
            this.basketType = basket; // Для маленьких, средних, больших корзин...
        }
        public override string ToString()
        {
            return "Баскетбольный мяч для " + basketType + " корзин из зала номер" + GymNumber + ", завезённый в зал в " + Month + " месяце был выпущен брендом " + Brand;
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

        public Tennis(string str1) { tennisType = str1; }
        public Tennis(int Number, string tennisType, int gym, int Month, string brand)
        {
            this.Number = Number;
            this.tennisType = tennisType;
            this.GymNumber = gym;
            this.Month = Month;
            this.Brand = brand;
        }
        public override string ToString()
        {
            return "Теннисный набор бренда " + Brand + " из зала номер " + GymNumber + ", завезённый в " + Month + " месяце содержит ракетки для " + tennisType + " тенниса и имеет в комплекте " + Number + " мячика/ов";
        }
    }
}
