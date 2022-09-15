using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод-вывод переменных примитивных типов

            bool bo = true;
            Console.WriteLine("Значение булевой переменной bool: " + bo);
            byte by = 12;
            sbyte sb = -12;
            Console.WriteLine("Значения переменной типа byte: " + by + ", переменной типа sbyte: " + sb);
            char ch = 'a';
            decimal de = -650m;
            Console.WriteLine("Символьная переменная: " + ch + ", переменная типа decimal: " + de);
            Console.WriteLine("Пожалуйста, введите значение переменной с плавающей запятой (тип double)");
            double db = Convert.ToDouble(Console.ReadLine());
            float fl = 2.5f;
            Console.WriteLine("Значение переменной типа double " + db + ", переменной типа float: " + fl);
            Console.WriteLine("Пожалуйста, введите целое число (тип integer)");
            int i1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Значение переменной типа integer: " + i1);
            uint i2 = 120;
            long l1 = -1000;
            ulong l2 = 1000;
            short sh1 = -150;
            ushort sh2 = 150;
            Console.WriteLine("Пожалуйста, введите своё имя!");
            string str = Console.ReadLine();
            Console.Write("Добрый вечер, ");
            Console.Write(str);
            Console.WriteLine("!");
            object obj = null;
            dynamic dyn = null;

            // Неявное приведение переменных (implicit)

            l1 = by;
            l2 = i2;
            db = (fl * 2);
            sh1 = sb;
            de = sb;

            // Явное приведение переменных

            by = (byte)i1;
            sh1 = (short)l1;
            fl = (float)db;
            by = (byte)(i1 + 217);
            sh2 = (ushort)(db + fl);

            // Упаковка значимых типов

            object ob1 = i1;
            object ob2 = sh1;
            object ob3 = l1;

            // Распаковка значимых типов

            int in1 = (int)ob1;
            short in2 = (short)ob2;
            long in3 = (long)ob3;

            // Неявная типизация переменной

            var name = "Maria Loschakova"; // Автоматически определена как string
            Type nameType = name.GetType();
            Console.WriteLine("Неявная переменная: " + name + ", тип name: {0}" + nameType);

            // Работа с Nullable переменной

            int? val = null;
            Nullable<int> val2 = null; // Альтернативное определение переменной Nullable
            Console.WriteLine("Вывод переменных Nullable (0 при заданном значении null у числовых типов): ");
            Console.WriteLine(val.GetValueOrDefault());
            Console.WriteLine(val2.GetValueOrDefault());

            /* Ошибка в использовании неявной типизации
                var value = 700;
                var value = "greetings!";
             */

            // Объявление и сравнение строковых литералов

            object a = "hello";
            object b = "hello";
            object c = "Hello";
            object d = "hell";
            System.Console.WriteLine(a == b);
            System.Console.WriteLine(a == c);
            System.Console.WriteLine(a != d);

            // Сцепление (конкатенация) строк

            string word1 = "У порога квартиры ";
            string word2 = "Стоит офицер. ";
            string word3 = "Меня нет дома. ";
            string phrase;
            phrase = String.Concat(word1, word2, word3);
            Console.WriteLine(phrase);

            // Копирование строки

            string str1 = "Я люблю ФИТ";
            string str2 = String.Copy(str1);
            Console.WriteLine(str2);

            // Выделение подстроки

            string phrase1 = "Я люблю ФИТ";
            string SubString = phrase1.Substring(8);
            Console.WriteLine("Подстрока: " + SubString);

            // Разделение строки на слова

            string s = "Солянка - это лучший суп на свете.";
            char[] delims = (" ./;-:,".ToCharArray());
            string[] subs = s.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            foreach (var sub in subs)
            {
                Console.WriteLine($"Слово: {sub}");
            }

            // Вставка подстроки в заданную позицию

            string str5 = "Какой факультет я люблю? ";
            string InString = "ФИТ!";
            string Output = str5.Insert(str5.Length, InString);
            Console.WriteLine(Output);

            // Удаление заданной подстроки

            string str6 = "Нужно удалить последнее слово слово";
            string outstr = str6.Remove(29);
            Console.WriteLine(outstr);

            // Интерполяция строк

            long number = 375291282004;
            Console.WriteLine($"{number:+### ## ### ## ##}"); // +375 29 129 20 04

            // Пустая и null строки

            string s1 = "";
            string s2 = null;
            bool test = string.IsNullOrEmpty(s1);
            bool test2 = string.IsNullOrEmpty(s2);
            Console.WriteLine(test);
            Console.WriteLine(test2);

            // StringBuilder

            var sb1 = new StringBuilder("Здарова, мир!"); // Могут применяться операции Append, Insert, Remove.
            Console.WriteLine(sb1.ToString());

            // Вывод двумерного массива в виде матрицы

            int[,] jj = { { 1, 2, 3 }, { 1, 2, 3 }, { 3, 2, 1 } };

            int rows = jj.GetUpperBound(0) + 1;
            int columns = jj.Length / rows;
            Console.WriteLine("Двумерный массив:");

            for (int pop = 0; pop < rows; pop++)
            {
                for (int kek = 0; kek < columns; kek++)
                {
                    Console.Write($"{jj[pop, kek]} \t");
                }
                Console.WriteLine();
            }

            // Одномерный массив строк

            Console.WriteLine("Массив строк:");
            string[] kk = { "qwerty", "asdfgh", "zxcvbn" };

            Console.WriteLine("Длина массива строк: " + kk.Length);

            foreach (string oop in kk)
            {
                Console.WriteLine(oop);
            }

            kk[1] = "popopop"; // Изменение произвольного элемента

            // Ступенчатый массив вещественных чисел с 3 строками

            int[][] ll = new int[3][];
            ll[0] = new int[] { 1, 2 };
            ll[1] = new int[] { 1, 2, 4 };
            ll[2] = new int[] { 1, 2, 4, 8 };
            Console.WriteLine("Ступенчатый массив:");

            foreach (int[] row1 in ll)
            {
                foreach (int number1 in row1)
                {
                    Console.Write($"{number1} \t");
                }
                Console.WriteLine();
            }



            // Неявно типизированная переменная

            var zz = new object[0];

            // Работа с кортежем

            (int, string, char, string, ulong) tuple = (12, "строка1", 'f', "строка2", 999);
            Console.WriteLine(tuple);                // Вывод всего кортежа
            Console.WriteLine(tuple.Item1);          // Вывод выборочно, элементы 1, 3, 4
            Console.WriteLine(tuple.Item3);
            Console.WriteLine(tuple.Item4);

            // Распаковка кортежа

            (int, int) MyMethod()
            {
                return (4, 5);
            }

            (int row, int col) = MyMethod();

            var val1 = tuple.Item1;

            // Переменная _ ??

            // Сравнение двух кортежей

            var tuple1 = (12, 95994, 1833, 1939303);
            var tuple2 = (3992, 492949, 13, 4929);
            Console.WriteLine("Равны ли кортежи {0} и {1}: {2}", tuple1, tuple2, tuple1.Equals(tuple2));

            // Локальная функция

            int[] array = { 12, 30, 153, 20, 4 };
            string words = "Строка";
            Console.WriteLine(Method(array, words));

            (int, int, int, char) Method(int[] intArray, string stringWord)
            {
                int intArraySum = Sum(intArray);
                int maxElement = intArray.Max();
                int minElement = intArray.Min();
                char firstLetter = stringWord[0];

                return (minElement, maxElement, intArraySum, firstLetter);

                int Sum(int[] xarray)
                {
                    int result = 0;
                    foreach (int number1 in xarray)
                        result += number1;
                    return result;
                }

            }

            // Checked/unchecked (проверка на переполнение)

            int z2 = 2;
            int LocalFunc()
            {
                int z1 = Int32.MaxValue;
                unchecked
                {
                    z1 = z1 + z2;
                    Console.WriteLine(z1);

                }
                return z1;
            }
            int LocalFunc2()
            {
                int z1 = Int32.MaxValue;
                checked
                {
                    z1 = z1 + z2;
                    Console.WriteLine(z1);

                }
                return z1;
            }
            Console.WriteLine(LocalFunc());
            Console.WriteLine(LocalFunc2());
        }
    }
}
