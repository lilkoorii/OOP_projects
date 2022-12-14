using System;
using System.Collections.Concurrent;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba9
{
    public class WebResource<T> : IList<T> where T : User
    {
        public ConcurrentDictionary<int, T> users = new ConcurrentDictionary<int, T>();
        public Dictionary<int, T> dict = new Dictionary<int, T>();
        public readonly IList<T> list = new List<T>();
        public IEnumerator<T> GetEnumerator() //реализация IEnumerable и IEnumerator
        {
            return list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(T item)
        {
            list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return list.Remove(item);
        }

        public int Count
        {
            get { return list.Count; }
        }

        public bool IsReadOnly
        {
            get { return list.IsReadOnly; }
        }

        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        public T this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }
        public void Show()  //методы коллекции ConcurrentDictionary
        {
            foreach (var item in users)
            {
                Console.WriteLine(item);
            }
        }
        public void ShowList()  //методы коллекции ConcurrentDictionary
        {
            foreach (var item in list)
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
}
