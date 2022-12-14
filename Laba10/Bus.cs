using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba10
{
    class Bus
    {
        public string Name // Публичный член класса
        {
            get; private set;
        }

        public short BusNumber
        {
            get; set;
        }

        public int RouteNumber
        {
            get; set;
        }

        public string Brand
        {
            get; set;
        }
        public short ExpluatationYear
        {
            get; set;
        }

        public int Mileage      //Логика при установлении значения свойства Mileage
        {
            get; set;
        }

        static string Type;
        static Bus()            // Статический конструктор
        {
            Type = "Автобус";
        }
        public Bus(string name) { Name = name; }            // Конструкторы
        public Bus(string n, short m)
        {
            Name = n;
            BusNumber = m;
            RouteNumber = 22;
            Brand = "МАЗ";
            ExpluatationYear = 2007;
            Mileage = 100500;
        }
        public Bus(string n, short m, int c)
        {
            this.Name = n;
            this.BusNumber = m;
            this.RouteNumber = c;
        }
        public Bus(string name, short bus, int route, string brand, short year, int mileage)
        {
            Name = name;
            BusNumber = bus;
            RouteNumber = route;
            Brand = brand;
            ExpluatationYear = year;
            Mileage = mileage;
        }
        public override string ToString()
        {
            return string.Format("Водитель: {0} Номер автобуса: {1} Номер маршрута: {2} Бренд: {3} Год начала экспл.: {4} Пробег: {5}", Name, BusNumber, RouteNumber, Brand, ExpluatationYear, Mileage);
        }

        static internal void PrintType()
        {
            Console.WriteLine("Метод PrintType");
        }
        public void Info()
        {
            Console.WriteLine();
            Console.WriteLine("Имя водителя: " + Name);
            Console.WriteLine("Номер автобуса: " + BusNumber);
            Console.WriteLine("Номер маршрута: " + RouteNumber);
            Console.WriteLine("Производитель: " + Brand);
            Console.WriteLine("Год начала эксплуатации: " + ExpluatationYear);
            Console.WriteLine("Пробег: " + Mileage + " километриков");
        }
    }

    public partial class Works
    {
        partial void Read();
        public void DoSomething()
        {
            Read();
        }
    }
    public partial class Works
    {
        partial void Read()
        {
            Console.WriteLine("Этот автобус сейчас в эксплуатации\n");
        }
    }

    public class Owner
    {
        public string Name { get; set; }
        public int Mileage { get; set; }
        public Owner(string Name, int Mileage)
        {
            this.Name = Name;
            this.Mileage = Mileage;
        }
    }
}
