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
    public class WebResource<T> : IList<T> where T : User
    {
        public ConcurrentDictionary<int, T> users = new ConcurrentDictionary<int, T>();
        public Dictionary<int, T> dict = new Dictionary<int, T>();
        public readonly IList<T> _list = new List<T>();
        public IEnumerator<T> GetEnumerator() //имплементация IEnumerable для корректной имплементации методов IList<T>
        {
            return _list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public bool IsReadOnly
        {
            get { return _list.IsReadOnly; }
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public T this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }
        public void Show()  //методы коллекции
        {
            foreach (var item in users)
            {
                Console.WriteLine(item);
            }
        }
        public void ShowDict()
        {
            foreach (KeyValuePair<int, T> element in dict)
                Console.WriteLine("Ключ: {0}\t\tЗначение: {1}", element.Key, element.Value);
        }
        public void Remove(int numb)
        {
            for (int i = 0; numb > 0; i++)
            {
                if (dict.ContainsKey(i))
                {
                    dict.Remove(i);
                    numb--;
                }
            }
        }
    }
    public class User
    {
        public string Name;

        public User(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
    class Program
    {
        public static void Ch(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Collection changed with action " + e.Action);
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
            Console.WriteLine("Attempt to add: " + web.users.TryAdd(4, frth));
            Console.WriteLine("\n------after attempt to add----");
            web.Show();
            Console.WriteLine("\n---------after frst elem-------");
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
            Console.WriteLine("\n---------deleted elem by key-------");
            Dict.ShowDict();
            Dict.Remove(2);
            Console.WriteLine("\n---------deleted 2 elems with the smallest keys-------");
            Dict.ShowDict();
            Console.WriteLine("\n------------------------------------------------------");
            Console.WriteLine("if contains key '4':" + Dict.dict.ContainsKey(4));
            Console.WriteLine("if contains key '6':" + Dict.dict.ContainsKey(6));


            ObservableCollection<int> obs = new ObservableCollection<int>(); //наблюдаемая коллекция
            obs.CollectionChanged += Ch;
            obs.Add(5);
            obs.Remove(5);

            Console.ReadKey();
        }
    }
}