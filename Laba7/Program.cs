using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading.Tasks;

namespace Laba7
{
        class GenericType<T> : IFunction<T>
        {
            public T[] array;
            public T element;
            public List<T> collection;

            //Конструкторы
            public GenericType()
            {
                this.array = new T[0];
                this.collection = new List<T>();
                this.element = default(T);
            }
            public GenericType(T element)
            {
                this.array = new T[0];
                this.collection = new List<T>();
                this.element = element;
            }
        //Методы
        public void Add(T element)
        {
            if (element.Equals(0))
            {
                throw new Exception("You cannot add element with a value of 0");
            }
            collection.Add(element);
        }
        public void Show()
        {
            if (collection.Count == 0)
            {
                throw new Exception("Empty collection");
            }
            for (int i = 0; i < collection.Count; i++)
            {
                Console.WriteLine((i + 1) + " element of list: " + collection[i]);
            }
        }
        public void Remove(int pos)
        {
            this.collection.RemoveAt(pos);
        }

        public void ToFile(string path)
        {
            string[] text = new string[collection.Count];
            for (int i = 0; i < collection.Count; i++)
            {
                text[i] = this.collection[i].ToString();
            }
            File.WriteAllLines(path, text);
            Console.WriteLine("Data has been saved to txt file");
        }

        public void FromFile(string path)
        {
            Console.WriteLine(File.ReadAllText(path));
        }
        
    }
    public class List
    {
        private readonly int id;
        private string title;
        private DateTime dateOfSignature; //дата подписи
        private string stringobj;
        private string array;
        private int price;
        public List(string title, DateTime dateOfSignature, string client, string organization, int price)
        {
            id = (int)title.GetHashCode() + (int)dateOfSignature.GetHashCode();
            this.title = title;
            this.dateOfSignature = dateOfSignature;
            this.stringobj = client;
            this.array = organization;
            this.price = price;
        }
        public string stringobject
        {
            get => stringobj;
            set => stringobj = value;

        }

        public string Array
        {
            get => array;
            set => array = value;
        }
        public string Title
        {
            get => title;
            set => title = value;
        }
        public DateTime DateOfSignature
        {
            get => dateOfSignature;
            set => dateOfSignature = value;
        }
        public override string ToString()
        {
            return "-------------------------------------------------------\nTitle: " + Title + "\nDateOfSignature: " + DateOfSignature.ToString("MM/dd/yyyy") + "\nString:  " + stringobject + "\nArray: " + array + "\n-------------------------------------------------------\n";

        }
    }
    internal class Program
    {

        static async Task Main(string[] args)
        {
            try
            {
                string path = @"C:\Users\Maria\OOP_projects\Laba7\save.txt";

                GenericType<int> list = new GenericType<int>();
                GenericType<short> list1 = new GenericType<short>(2);
                GenericType<List> tom = new GenericType<List>();

                List a = new List("Список номер 1", new DateTime(2012, 05, 12), "Cтроковая переменная 1", "аьлылььладльа", 7800);
                List b = new List("Квитанция об оплате", new DateTime(2020, 05, 12), "Каролина Мергель", "Netflix", 49);
                List c = new List("Check", new DateTime(2020 / 10 / 10), "Каролина Мергель", "В мире пультов", 20);
                tom.Add(a);
                tom.Add(b);
                tom.Add(c);

                tom.ToFile(path);
                tom.FromFile(path);
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
        static class StatisticOperation  //Статический класс с методами
        {
            public static int Sum(this GenericType<int[]> list1)
            {
                int sum = 0;
                for (int i = 0; i <= 4; i++)
                {
                    sum += list1.element[i];
                }
                return sum;
            }
            public static int Dif(this GenericType<int[]> list1)
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
        }
    }

