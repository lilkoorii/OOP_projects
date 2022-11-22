using System;
using System.Collections.Generic;
using System.Text;

namespace Laba5
{
    public abstract class Balls : IGymAssembly, IName  //Balls
    {
        public Sum Sum;
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Density { get; set; }

        public virtual void StartGetBall(BallGet getBall)
        {
            if (getBall.TryGetting())
                Console.WriteLine("Вы взяли мячик!");
            else Console.WriteLine("Мячик не взялся, потому что спортзал закрыт.");
        }
        public override bool Equals(object obj)
        {
            if (obj is Balls && obj != null)
            {
                return this.GetType() == obj.GetType();
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 10654;
        }
    }

    public class TennisBall : Balls, IName  //TennisBall
    {
        public TennisBall(string name, int dens, Sum sum)
        {
            this.Quantity = 5;
            this.Name = name;
            this.Density = dens;
            this.Sum = sum;
        }

        public override void StartGetBall(BallGet getBall) //запуск взятия мячика
        {
            if (getBall.TryGetting())
                Console.WriteLine("Мячик удалось взять, можно играть в теннис.");
            else Console.WriteLine("Корзина для теннисных мячиков внезапно исчезла, никакого тенниса пока что.");
        }

        public override string ToString()
        {
            return "Тип объекта: " + GetType().Name + "\nНазвание: " + Name + "\nПлотность материала мячика: " + Density + "\nКоличество шариков: " + Quantity + "\n" + new String('-', 50);
        }
    }

    public class VolleyBall : Balls, IName  //VolleyBall
    {
        public VolleyBall(string name, int dens, Sum sum)
        {
            this.Quantity = 4;
            this.Name = name;
            this.Density = dens;
            this.Sum = sum;
        }
        public override void StartGetBall(BallGet getBall)
        {
            if (getBall.TryGetting())
                Console.WriteLine("Ура!!! У вас теперь есть воллейбольный мячик!\n");
            else Console.WriteLine("Мячики закончились, воллейбол нынче популярный.\n");
        }
        public override string ToString()
        {
            return "Тип объекта: " + GetType().Name + "\nНазвание: " + Name + "\nПлотность надувания: " + Density + "\nКоличество мячиков: " + Quantity + "\n" + new String('-', 50);
        }
    }

    public class TennisRacket : TennisBall, IName
    {
        public string Brand { get; set; }
        public TennisRacket(string name, int dens, string brand, Sum sum) : base(name, dens, sum)
        {
            this.Quantity = 2;
            this.Brand = brand;
        }
    }

    public class BallGet //взять мячик
    {
        public bool TryGetting()
        {
            var rand = new Random();
            bool result = rand.Next(2) == 1;
            Console.WriteLine("\nПопытка взять мячик: " + result);
            return result;
        }
    }
}
