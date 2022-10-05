using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba4
{
    static class StatisticOperations //Методы для работы с классом
    {
        public static int Sum(Laba3.List<int> list) //Сумма элементов
        {
            var sum1 = list.Sum();
            return sum1;
        }
        public static int Max(Laba3.List<int> list) //Максимальный элемент
        {
            var max= list.Max();
            return max;
        }
        public static int Min(Laba3.List<int> list) //Минимальный эмемент
        {
            var min= list.Min();
            return min;
        }
        public static int Delta(Laba3.List<int> list) //Разница между макс и мин элементами
        {
            return Math.Abs(StatisticOperations.Max(list)) - Math.Abs(StatisticOperations.Min(list));
        }
        public static int Size(Laba3.List<int> list) //Подсчет кол-ва элементов
        {
            return list.Count();
        }
      
    }
}