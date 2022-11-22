using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8
{
    class SysUpgr
    {
        public static string Remove(string str)
        {
            str = str.Replace(".", string.Empty);
            str = str.Replace(",", string.Empty);
            str = str.Replace("!", string.Empty);
            str = str.Replace("?", string.Empty);
            return str;
        }


        public static string AddToString(string str)
        {
            return str += "символ";
        }


        public static string RemoveSpace(string str)
        {
            return str.Replace(" ", string.Empty);
        }


        public static string Upper(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                str = str.Replace(str[i], char.ToUpper(str[i]));
            }
            return str;
        }

        public static string Lower(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                str = str.Replace(str[i], char.ToLower(str[i]));
            }
            return str;
        }

        public static void makeATree(int height = 10)
        {
            Random rnd = new Random();
            int numOfSpaces = height;
            int numOfasterix = 1;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < numOfSpaces; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < numOfasterix; j++)
                {
                    if (numOfasterix == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("0 ");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (rnd.Next(1, 25) == 4)
                        {
                            ConsoleColor[] console = new ConsoleColor[4] { ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Yellow, ConsoleColor.Magenta };
                            Console.ForegroundColor = console[rnd.Next(0, 4)];
                            Console.Write("o ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("* ");
                            Console.ResetColor();
                        }
                    }
                }
                Console.WriteLine();
                numOfasterix++;
                numOfSpaces--;
            }
        }
    }
}
