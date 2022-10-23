using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Laba31
{
    class List
    {
        internal string text;
        internal string text2;
        internal int[] array;
        internal int ID;
        internal string company;
        internal class Developer
        {
            public readonly string Name = "Loschakova Maria Pavlovna";
            public short ID;
            public string Department;
            public List Production = new List(9113, "CoolCompany");   // Объект Production

            public Developer(short iD, string department)
            {
                ID = iD;
                Department = department;
            }
            
        }
       
        //Конструкторы
        public List()
        {
        }

        public List(int[] arr1)
        {
            this.array = arr1;
        }

        public List(int ID, string Company)
        {
            this.ID = ID;
            this.company = Company;
        }
        public List(int[] arr1, string str)
        {
            this.array = arr1;
            this.text = str;
        }

        public List(int[] arr1, string str1, string str2) : this(arr1, str1)
        {
            this.text = str1;
            this.text2 = str2;
        }

        //Методы
        internal void AddString(string v)
        {
            text = v;
        }
        //Операторы
        public static int[] operator !(List list1)
        {
            int[] array = list1.array;
            int[] array2 = new int[5];
            for (int i=0; i<=4; i++)
            {
                array2[i] = array[4-i];
            }
            return array2;
        }

         public static List operator +(List list1, List list2)
         {
            int[] array = new int[10];
            string str1 = list1.text;
            string str2 = list2.text;
            List result = new List(array, str1, str2);
            for (int i=0; i<=4; i++)
            {
                result.array[i] = list1.array[i];
            }
            for (int i = 5; i <= 9; i++)
            {
                result.array[i] = list2.array[i-5];
            }
            for (int i = 0; i <= 9; i++)
            {
                Console.WriteLine(result.array[i]);
            }
            Console.WriteLine(result.text);
            Console.WriteLine(result.text2);
            return result;
         }
        public static bool operator ==(List list1, List list2)
        {
            if ((list1.text == list2.text) && (list1.array == list2.array))
                return true;
            else
                return false;
        }
         public static bool operator !=(List list1, List list2)
         {
             if ((list1.text != list2.text) && (list1.array != list2.array))
                return false;
             else
                 return true;
        }
        public static List operator >(List list1, List list2)
         {
             for (int i = 0; i <= 4; i++)
             {
                list2.array[i] = list1.array[i];
                list2.text = list1.text;
             }
             return list2;
         }
         public static List operator <(List list1, List list2)
         {
            for (int i = 0; i <= 4; i++)
            {
                list1.array[i] = list2.array[i];
            }
            list1.text = list2.text;
            for (int i = 0; i <= 4; i++)
            {
                Console.WriteLine(list1.array[i]);
            }
            Console.WriteLine(list1.text);
            return list1;
        } 
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Hello World";
            int[] arr1 = new int[5] {1, 2, 3, 4, 5};
            List list1 = new List(arr1, str1);
            string str2 = "I love FIT";
            int[] arr2 = new int[5] { 11, 12, 13, 14, 15 };
            List list2 = new List(arr2, str2);
            Console.WriteLine("Перевернутый список 1:");
            int[] res1 = !list1;  //Инверсия списка
            for (int i=0; i<=4; i++)
            {
                Console.WriteLine(res1[i]);
            }
            Console.WriteLine(list1.text);
            bool areEqual = list1 == list2; //Сравнение списков
            Console.WriteLine($"Равны ли списки 1 и 2: {areEqual}");
            Console.WriteLine("Соединенные списки 1 и 2: ");
            List res2 = new List();
            res2 = list1 + list2; //Соединение списков
            char ch = 'l';
            int res5 = StatisticOperation.CharCount(list1.text, ch);
            Console.WriteLine($"Строка для подсчёта символов: {list1.text}");
            Console.WriteLine($"Количество символов 'l': {res5}");
            int res6 = StatisticOperation.Sum(list1);
            Console.WriteLine($"Сумма элементов списка 1: {res6}");
            string res4 = StatisticOperation.Truncation(list1.text);
            Console.WriteLine($"Усеченнная строка списка 1: {res4}");
            Console.WriteLine("Добавление элементов из 2 в 1: ");
            List res3 = new List();
            res3 = list1 < list2; //Добавление элементов из списка 2 в 1
            List.Developer dev1 = new List.Developer(9113, "Web Design");
            Console.WriteLine($"Объект Production: {dev1.Production.ID}, {dev1.Production.company}");
            Console.WriteLine($"Объект класса Developer: {dev1.ID}, {dev1.Department}, {dev1.Name}");
        }
    }
    static class StatisticOperation  //Статический класс с методами
    {
        public static int Sum(this List list1)
        {
            int sum = 0;
            for (int i = 0; i <= 4; i++)
            {
                sum += list1.array[i];
            }
            return sum;
        }
        public static int Dif(this List list1)
        {
            int max = 1000;
            int min = 0;
            for (int i = 0; i < 5; i++)
            {
                if (list1.array[i] < max)
                    max = list1.array[i];
                if (list1.array[i] > min)
                    min = list1.array[i];
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
