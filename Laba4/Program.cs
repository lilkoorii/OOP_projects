//Инвентарь, Скамейка, Брусья, Мяч, Маты, 
//Баскетбольный мяч, Теннис.

using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace Laba4
{
    class Program
    {
        static void Main(string[] args)
        {
            Bench bench = new Bench(100, 837362, 6); //int Height, int GymNumber, int Month
            Ball ball = new Ball("Mikasa", 374564, 7, "жёлтого в полоску"); //string Brand, int GymNumber, int Month, string Color
            BasketBall basketBall = new BasketBall("Nike", 792955, 8, "средних"); //string Brand, int GymNumber, int Month, string basketType
            Bars bars = new Bars(100, 385762, 9); //int personWeight, int GymNumber, int Month
            Tennis tennisBall = new Tennis(3, "настольного", 100247, 10, "Wilson"); //int Number, string tennisType, int GymNumber, int Month, string Brand

            Console.WriteLine(bench.ToString());
            Console.WriteLine(ball.ToString());
            Console.WriteLine(basketBall.ToString());
            basketBall.Pull();
            Console.WriteLine(bars.ToString());
            Console.WriteLine(tennisBall.ToString());

            List<Inventory> list = new List<Inventory> { new Bench(180, 837362, 6), new Bars(160, 385762, 9) };
            Ball ball1 = new Ball();
            Tennis? tennis = ball1 as Tennis;
            if (ball1 is Tennis tennis1)
            {
                Console.WriteLine(tennis1.tennisType);
            }
            else
            {
                Console.WriteLine("Преобразование не допустимо");
            }
            if (tennis == null)
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
                Console.WriteLine(tennis.tennisType);
            }

            Printer printer = new Printer();
            foreach (Inventory v in list)
            {
                Console.WriteLine(printer.IAmPrinting(v));
            }
            bench.DoSomething(); //Вызов sealed метода
            UserClass user = new UserClass();
            UserClass2 user2 = new UserClass2();
            Console.WriteLine(user.DoClone());
            Console.WriteLine(user2.DoClone());
        }
    }
}
