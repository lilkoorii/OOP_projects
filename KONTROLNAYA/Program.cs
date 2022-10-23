using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONTROLNAYA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1;

            str1 = Console.ReadLine();
            char[] ch1 = new char[100];
            ch1 = str1.ToCharArray();
            for(int i=0; i < ch1.Length; i++)
            {
                if (ch1[i] == 'o')
                {
                    ch1[i] = 'a';
                }
                if (ch1[i] == 'd')
                {
                    ch1[i] = 'j';
                }

            }
            for (int i = 0; i < ch1.Length; i++)
            {
                Console.Write(ch1[i]);
                
            }
            int[,] jj =
            {
                { 1, 1, 1, 1, 1, 1, 1, 1},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                {1, 1, 1, 1, 1, 1, 1, 1 },
                {0, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 1, 1, 1, 1, 1, 1, 1},
                {0, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 1, 1, 1, 1, 1, 1, 1},
                { 0, 0, 0, 0, 0, 0, 0, 0}
            };

            int rows = 8;
            int columns = 8;
            Console.WriteLine("Двумерный массив:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (j%2==0)
                    {

                    }
                }
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{jj[i, j]} \t");
                }
                Console.WriteLine();
            }

            var evroopt = new Shop(new[]
            {
                ("milk"), ("bread"), ("juice"), ("rice")
            });
            string firstTovar = evroopt[0];
            Console.WriteLine(firstTovar);
            Shop santa = new Shop(new[]
            {
                ("alcohol"), ("bread"), ("juice"), ("rice")
            });
            string firstItem = santa[0];
            Console.WriteLine(firstItem);
            Console.WriteLine("Одинаковые ли товары в магазинах " + evroopt.Compare(evroopt, santa));
        }
    }
}
