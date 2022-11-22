using System;
using System.Collections.Generic;
using System.Text;

namespace Laba5
{
    public class Printer
    {
        public string IAmPrinting(Balls obj)
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

}
