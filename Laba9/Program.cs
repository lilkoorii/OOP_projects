using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Laba9
{
    class Program
    {
        public static void Ch(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Коллекция изменилась с действием " + e.Action);
        }
        static void Main(string[] args)
        {
            //Веб-ресурс
            User frst = new User("First User");
            User scnd = new User("Second User");
            User thrd = new User("Third User");
            User frth = new User("Fourth User");
            User ffth = new User("Fifth User");

            WebResource<User> web = new WebResource<User>();

            web.users.TryAdd(1, frst);
            web.users.TryAdd(2, scnd);
            web.users.GetOrAdd(3, thrd);
            //web.players.CompleteAdding();
            web.Show();
            Console.WriteLine("Попытка дбавления: " + web.users.TryAdd(4, frth));
            Console.WriteLine("\n------после попытки добавления:----");
            web.Show();
            web.users.Clear();

            Console.WriteLine("\n------------------------------");
            WebResource<User> Dict = new WebResource<User>(); //Словарь - вторая коллекция
            Dict.dict.Add(1, frst);
            Dict.dict.Add(2, scnd);
            Dict.dict.Add(3, thrd);
            Dict.dict.Add(5, ffth);
            Dict.dict.Add(4, frth);
            Dict.ShowDict();
            Dict.dict.Remove(1);
            Console.WriteLine("\n---------удалили элемент с ключом 1-------");
            Dict.ShowDict();
            Dict.Remove(2);
            Console.WriteLine("\n---------удалили 2 элемента с наименьшими ключами-------");
            Dict.ShowDict();
            Console.WriteLine("\n------------------------------------------------------");
            Console.WriteLine("Содержит ли ключ '4':" + Dict.dict.ContainsKey(4));
            Console.WriteLine("Содержит ли ключ '6':" + Dict.dict.ContainsKey(6));

            WebResource<User> list = new WebResource<User>(); //коллекция List
            list.list.Add(frst);
            list.list.Add(scnd);
            list.list.Add(thrd);
            list.list.Add(frth);
            list.ShowList();


            ObservableCollection<int> obs = new ObservableCollection<int>(); //наблюдаемая коллекция
            obs.CollectionChanged += Ch;
            obs.Add(5);
            obs.Remove(5);

            Console.ReadKey();
        }
    }
}