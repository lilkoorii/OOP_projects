using System;
using System.Net;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace Laba5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BallGet ballGet = new BallGet();
                GymControl gym = new GymControl();
                BallControl balls = new BallControl();
                //Mat matbad = new Mat("Плохой мат", "1234567890123456789012345789067890987654321234567890098765432123456789098765432", "Резина", new Sum(0, 80), 2000);
                Mat mat = new Mat("Мат", "Прямоугольная", "Поролон", new Sum(1, 80), 8700);
                Equipment equip = new Equipment("Инвентарь", "Часть зала", "Спортивный", new Sum(3, 25));
                VolleyBall volleyball = new VolleyBall("Воллейбольный мяч", 100, new Sum(3, 23));
                TennisBall tennisball = new TennisBall("Теннисные мячики", 1000, new Sum(5, 75));
                gym.Add(mat);
                gym.Add(equip);
                gym.Display();
                gym.Count();
                gym.SearchTotal(new Sum(20, 90));
                gym.SearchDensity(8700);
                balls.Add(volleyball);
                balls.Add(tennisball);
                volleyball.StartGetBall(ballGet);
                balls.Display();
                balls.Count();
                balls.SearchTotal(new Sum(5, 50));
                balls.SearchDensity(100);
                //matbad.CheckForException();
            }
            catch (MyException e)
            {
                Console.WriteLine(e.ToString());
                Logger.FileLogger.WriteLog(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.FileLogger.WriteLog(e);
                throw;
            }
            finally
            {
                Console.WriteLine("Программа завершилась!");
            }
        }
    }
}
