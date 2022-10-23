using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class Card : IPlus, IMinus
    {
        private int _month;
        public int Month
        {
            internal set
            {
                if (value < 0 || value > 12)
                    Console.WriteLine("Месяц должен быть в диапазоне 1-12");
                else
                    _month = Month;
            }
            get
            { return _month; }
        }
        int Year
        {
            get;
        } = 2022;
        public double Balance { get; set; }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public void MakeTransaction()
        {
            Random rnd = new Random();
            Balance += rnd.Next(0, 10000);
            Console.WriteLine("Ваш баланс теперь составляет " + Balance);
        }
        public void MakeTransactionMinus()
        {
            Random rnd = new Random();
            Balance -= rnd.Next(0, 10000);
            Console.WriteLine("Ваш баланс теперь составляет " + Balance);
        }
    }
    interface IPlus
    {
        void MakeTransaction();
    }
    interface IMinus
    {
        void MakeTransactionMinus();
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            short srt;
            Console.WriteLine(short.MaxValue+1);
            string[] array = new string[12] { "Декабрь", "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь" };
            Card card = new Card();
            card.Balance = 1000000;
            card.Month = 10;
            card.MakeTransaction();

        }
    }
}
