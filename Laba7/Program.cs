using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading.Tasks;

namespace Laba7
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            try
            {
                string path = @"C:\Users\Maria\OOP_projects\Laba7\save.txt";

                CollectionType<int> list = new CollectionType<int>();
                CollectionType<short> list1 = new CollectionType<short>();
                CollectionType<string> list2 = new CollectionType<string>();
                CollectionType<Ball> balls = new CollectionType<Ball>();

                Ball a = new Ball("Волейбольный мячик", new DateTime(2012, 05, 12), "Mikasa",  50);
                Ball b = new Ball("Баскетбольный мячик", new DateTime(2020, 05, 12), "Nike",  70);
                Ball c = new Ball("Мячуля", new DateTime(2020 / 10 / 10), "Я больше брендов не знаю(",  20);
                balls.Add(a);
                balls.Add(b);
                balls.Add(c);

                balls.ToFile(path);
                balls.FromFile(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Yaaay");
                Console.ReadKey();
            }

        }
    }
    /*      static class StatisticOperation  //Статический класс с методами
          {
              public static int Sum(this CollectionType<int[]> list1)
              {
                  int sum = 0;
                  for (int i = 0; i <= 4; i++)
                  {
                      sum += list1.element[i];
                  }
                  return sum;
              }
              public static int Dif(this CollectionType<int[]> list1)
              {
                  int max = 1000;
                  int min = 0;
                  for (int i = 0; i < 5; i++)
                  {
                      if (list1.element[i] < max)
                          max = list1.element[i];
                      if (list1.element[i] > min)
                          min = list1.element[i];
                  }
                  int difference = max - min;
                  return difference;
              }
              public static int CharCount(this string str, char c)
              {
                  int counter = 0;
                  for (int i = 0; i < str.Length; i++)
                  {
                      if (str[i] == c)
                          counter++;
                  }
                  return counter;
              }
              public static string Truncation(string text)
              {
                  Console.Write("Укажите длину обрезки строки:");
                  string strlength = Console.ReadLine();
                  int strLength = Convert.ToInt32(strlength);
                  string newText = text.Substring(strLength);
                  return newText;
              }
          }*/
}

