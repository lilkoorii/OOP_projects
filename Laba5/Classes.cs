using System;
using System.Collections.Generic;
using System.Text;

namespace Laba5
{
    public abstract class Gym : IName
    {
        public string Shape { get; set; }
        public Sum Sum;
    }

    public class Equipment : Gym, IMakeGym
    {
        public string Type { get; set; }
        public string Name { get; set; }   

        public Equipment(string name, string shape, string type, Sum sum)
        {
            this.Name = name;
            this.Shape = shape;
            this.Type = type;
            this.Sum = sum;
        }

        public override string ToString()
        {
            return "Тип объекта: " + GetType().Name + "\nНазвание: " + Shape + "\nТип: " + Type + "\nЦена: " + Sum.Dollar + " долларов " + Sum.Cent + " центов\n" + new String('-', 50);
        }

        public void MakeGym(IGymAssembly gymAssembling)
        {
            gymAssembling.StartGetBall(new BallGet());
        }
    }


    public class Mat : Gym, IGymAssembly
    {
        public string Composition { get; set; }
        public int Density { get; set; }
        public string Name { get; set; }
        public Mat(string name, string shape, string composition, Sum sum, int dens)
        {
            this.Name = name;
            this.Shape = shape;
            this.Composition = composition; //состав мата
            this.Sum = sum;
            this.Density = dens;
        }

        public override string ToString()
        {
            return "Тип объекта: " + GetType().Name +"\nНазвание: " + Name + "\nФорма: " + Shape + "\nСостав: " + Composition + "\nЦена: " + Sum.Dollar + " долларов " + Sum.Cent + " центов\nПлотность мата: " + Density + "\n" + new String('-', 50);
        }
        public void StartGetBall(BallGet getBall)
        {
            if (getBall.TryGetting())
                Console.WriteLine("Мат взялся.");
            else Console.WriteLine("Мат не удалось взять - у вас сломана рука :(");
        }

    }


    public abstract class Ball : IGymAssembly, IName
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
            if (obj is Ball && obj != null)
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


    public class TennisBall : Ball, IName
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


    public class VolleyBall : Ball, IName
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


    public class Printer
    {
        public string IAmPrinting(Ball obj)
        {
            if (obj is TennisBall)
            {
                TennisBall c = (TennisBall)obj;
                return "Тип объекта: " + c.GetType().Name + "\nНазвание: " + c.Name + "\nПлотность материала мячика: " + c.Density + "\nКоличество мячиков: " + c.Quantity + "\n" + new String('-', 50);
            }
            if (obj is VolleyBall)
            {
                VolleyBall t = (VolleyBall)obj;
                return "Тип объекта: " + t.GetType().Name + "\nБренд: " + t.Name + "\nПлотность надувания: " + t.Density + "\nКоличество мячиков: " + t.Quantity + "\n" + new String('-', 50);
            }
            if (obj is TennisRacket)
            {
                TennisRacket b = (TennisRacket)obj;
                return "Тип объекта: " + b.GetType().Name + "\nНазвание: " + b.Name + "\nПлотность материала ракеток: " + b.Density + "\nКоличество ракеток: " + b.Quantity + "\n" + new String('-', 50);
            }
            return "Объект не соответствует необходимому типу объекта.";
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
