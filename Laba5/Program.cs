using System;

namespace Laba5
{
    /*
    Собрать Детский подарок с определением его веса. Провести
    сортировку конфет в подарке на основе одного из
    параметров. Найти конфету в подарке, соответствующую
    заданному диапазону содержания сахара.
     */

    /*
     Подготовить Спортзал. Снарядов должно быть
    фиксированное количество в пределах выделенной суммы
    денег. Провести сортировку инвентаря в Спортзале по
    одному из параметров. Найти снаряды, соответствующие
    заданному диапазону цены
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            BallGet ballGet = new BallGet();
            GymWrap gym = new GymWrap();
            BallWrap balls = new BallWrap();
            Mat mat = new Mat("Мат", "Прямоугольная", "Поролон", new Sum(1, 80), 8700);
            Equipment equip = new Equipment("Инвентарь", "Часть зала", "Спортивный", new Sum(3, 25));
            VolleyBall volleyball = new VolleyBall("Воллейбольный мяч", 100, new Sum(3, 23));
            TennisBall tennisball = new TennisBall("Теннисные мячики", 1000, new Sum(5, 75));
            gym.Add(mat);
            gym.Add(equip);
            gym.Display();
            gym.Count();
            gym.SearchTotal(new Sum(100, 50));
            gym.SearchDensity(8700);
            balls.Add(volleyball);
            balls.Add(tennisball);
            volleyball.StartGetBall(ballGet);
            balls.Display();
            balls.Count();
            balls.SearchTotal(new Sum(100, 50));
            balls.SearchDensity(100);
        }
    }
}
