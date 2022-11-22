using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8
{
    internal class User
    {
        public delegate void List(string message);
        public event List UpgradeEvent;
        public event List WorkEvent;
        public List<string> list;
        public User(List<string> list)
        {
            this.list = list;
        }
        public void Upgrade(ref int ver3)
        {
            list.RemoveAt(0);
            int ver1 = 1;
            int ver2 = 0;
            ver3 += 1;
            Console.WriteLine(string.Format("Обновлённая версия: {0}.{1}.{2}", ver1, ver2, ver3));
            UpgradeEvent?.Invoke("Произошло повышение пользователя!");
        }

        public void Work()
        {
            list = list.OrderBy(x => Guid.NewGuid().ToString()).ToList();
            WorkEvent?.Invoke("Пользователь усердно работоет.........");

        }
        public void Show()
        {
            foreach (string str in list)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
        }
    }
}
