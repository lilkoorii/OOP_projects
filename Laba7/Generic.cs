using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba7
{
    class CollectionType<T> : IFunction<T> //обобщённый тип
    {
        public T[] array;
        public T element;
        public List<T> collection;

        //Конструкторы
        public CollectionType()
        {
            this.array = new T[0];
            this.collection = new List<T>();
            this.element = default(T);
        }
        public CollectionType(T element)
        {
            this.array = new T[0];
            this.collection = new List<T>();
            this.element = element;
        }
        //Методы
        public void Add(T element) //where T : Ball - ограничение на добавление только мячиков
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
}
