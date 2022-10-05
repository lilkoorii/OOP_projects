using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    // Класс узла односв. списка
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    public class List<T> : IEnumerable<T>  // Односвязный список
    {
        Node<T> head; // Головной/первый элемент
        Node<T> tail; // Последний/хвостовой элемент
        int count;  // Кол-во элементов в списке

        // добавление элемента
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }
        // удаление элемента
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        // очистка списка
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        // содержит ли список элемент
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        // добвление в начало
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
        // реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public void Print(List<int> list)
        {
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
        }
        public static List<T> operator !(List<T> list1)
        {
            List<T> result = new List<T>();   //list1.Reverse() - не конвертируется в Laba3.List<T>
            result.head = list1.tail;
            result.tail = list1.head;
            return result;
        }
        public static List<T> operator +(List<T> list1, List<T> list2)
        {
            List<T> result = new List<T>();  //list1.Concat(list2) - не конвертируется в List<T>
            result.head = list1.head;
            result.tail = list2.tail;
            return result;
        }
        public static bool operator !=(List<T> list1, List<T> list2)
        {
            return list1.head != list2.head;
        }
        public static bool operator ==(List<T> list1, List<T> list2)
        {
            return list1.Equals(list2);
        }
        public class Date // Вложенный класс Date (дата создания)
        {
            public DateTime time;
            public Date()
            {
                this.time = new DateTime(2022, 10, 2, 14, 30, 0);
            }
            public void showDate()
            {
                Console.WriteLine("Дата создания: " + time);
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            list1.Add(24);
            list1.Add(56);
            list1.Add(89);
            list2.Add(12);
            list2.Add(70);
            list2.Add(34);
            Console.WriteLine("\nЭлементы списка 1:");
            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nЭлементы списка 2:");
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }
           Console.WriteLine("\nИнверсия списка 1:");
            //var result1 = !list1;
            var result1 =list1.Reverse();
            foreach (int item in result1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nОбъединение списков:");
            //var result2 = list1 + list2;
            var result2 =list1.Concat(list2);
            foreach (int item in result2)
            {
                Console.WriteLine(item);
            } 
            Console.WriteLine("\nСравнение списков:");
            Console.WriteLine(list1 == list2);
            Laba3.List<int>.Date date = new Laba3.List<int>.Date();
            date.showDate();
            Console.WriteLine("\nСумма элементов 1-го списка:");
            Console.WriteLine(Laba4.StatisticOperations.Sum(list1));
            Console.WriteLine("\nМакс. элемент 2-го списка:");
            Console.WriteLine(Laba4.StatisticOperations.Max(list2));
            Console.WriteLine("\nМин. элемент 1-го списка:");
            Console.WriteLine(Laba4.StatisticOperations.Min(list1));
            Console.WriteLine("\nРазница между макс. и мин. (1 список):");
            Console.WriteLine(Laba4.StatisticOperations.Delta(list1));

        }
    }
}
