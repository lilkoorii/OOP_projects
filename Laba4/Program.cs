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
            //Inventory pastry = new Inventory(); // Новый инвентарь
            Bench bench = new Bench(100, 837362, 6); //int Height, int gymNumber, int Month
            Ball ball = new Ball("Mikasa", 374564, 7, "жёлтого в полоску"); //string Brand, int gymNumber, int Month, string Color
            BasketBall basketBall = new BasketBall("Nike", 792955, 8, "средних"); //string Brand, int gymNumber, int Month, string basketType
            Bars bars = new Bars(100, 385762, 9); //int personWeight, int gymNumber, int Month
            Tennis tennisBall = new Tennis(3, "настольного", 100247, 10, "Wilson"); //int Number, string tennisType, int gymNumber, int Month, string Brand

            //Console.WriteLine(pastry.ToString());
            Console.WriteLine(bench.ToString());
            Console.WriteLine(ball.ToString());
            Console.WriteLine(basketBall.ToString());
            basketBall.Pull();
            Console.WriteLine(bars.ToString());
            Console.WriteLine(tennisBall.ToString());

            List<Inventory> list = new List<Inventory> { new Bench(180, 837362, 6), new Bars(160, 385762, 9) };

            Printer printer = new Printer();
            foreach (Inventory v in list)
            {
                Console.WriteLine(printer.IAmPrinting(v));
            }

            bench.DoSomething(); //Вызов sealed метода
        }
    }
}
