using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> FirstList = new List<string>() { "один", "два", "пользователь", "всё", "ещё", "работает" };
            User user = new User(FirstList);

            List<string> SecList = new List<string>() { "один", "два", "пользователь", "всё", "ещё", "обновляет" };
            User usr = new User(SecList);
            int ver3 = 11;

            user.Show();

            user.UpgradeEvent += (string message) => Console.WriteLine(message); //лямбда-выражения с параметром message

            user.WorkEvent += (string message) => Console.WriteLine(message);


            user.Upgrade(ref ver3);
            user.Show();

            user.Work();
            user.Upgrade(ref ver3);
            user.Show();

            user.Work();
            user.Upgrade(ref ver3);
            user.Show();

            Console.WriteLine("\n---------------------------------------\n");

            string str = "Я пользователь, люблю всякую работную работу и обновлять обновления...";
            Console.WriteLine("\nПользователь решил поработать с вот этой строкой: " + str);
            Func<string, string> A = null;
            A = SysUpgr.Remove;
            Console.WriteLine("\nБез знаков препинания: {0}", A(str));
            A = SysUpgr.AddToString;
            Console.WriteLine("\nДобавление строки: {0}", A(str));
            A = SysUpgr.Upper;
            Console.WriteLine("\nЗаглавные буквы: {0}", str = A(str));
            A = SysUpgr.Lower;
            Console.WriteLine("\nПрописные: {0}", A(str));
            A = SysUpgr.RemoveSpace;    
            Console.WriteLine("\nУдаление пробелов: {0}", str = A(str));

            Console.WriteLine("\nПользователь наработал целую ёлочку!! Введите длину ёлочки!");
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    SysUpgr.makeATree(Int32.Parse(Console.ReadLine()));
                }
                catch
                {
                    Console.WriteLine("!!!АШЫПКА ВВЕДИТЕ ЧИСЛО!!!");
                    Console.ResetColor();
                }
            } while (true);
        }
    }
}
