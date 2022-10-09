using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_Lab3
{
    //Класс - некая абстракция, логическая структура, описывающая поведение и характеристики. Например, машина. Она может ехать, сигналить и т.п.
    //Объект - конкретный экземпляр класса.Например, конкретная ваша машина.
    //Экземпляр класса - это то же, что и объект класса.
    //Класс: фрукт, Объект: киви, банан, манго.
    class Bus
    {
        public int W;
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
            set
            {
                if (value < 1)
                    Console.WriteLine("Пробег должен быть в диапазоне от 1 до 120");
                else
                    Mileage = value;
            }
            get { return Mileage; }
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
    class Program
    {
        static void Main(string[] args)
        {
            Bus[] buses = new Bus[3]; //вызов массива конструкторов

            buses[0] = new Bus("Иванович А.В", 1022) { RouteNumber=22, Brand="МАЗ", ExpluatationYear=2007, Mileage=100500 };
            buses[1] = new Bus("Пацей В.В", 1153, 53) { Brand="БелМаш", ExpluatationYear=2014, Mileage=10000};
            buses[2] = new Bus("Бондарь П.П") { BusNumber=1046, RouteNumber=46, Brand="БелМаш", ExpluatationYear=2011, Mileage=200000 };

            Console.WriteLine("\nБаза данных автобусов: \n");
            foreach (Bus bus in buses)
            {
                Console.WriteLine(bus.ToString());
            }

            Console.WriteLine("\nВведите номер маршрута: ");
            int value = Convert.ToInt32(Console.ReadLine());
            foreach (Bus bus in buses)
            {
                if (bus.RouteNumber==value)
                    Console.WriteLine(bus);

            }

            Console.WriteLine("\nАвтобусы, которые эксплуатируются дольше срока (больше 12 лет): \n");
            var intNumber = buses.Where(x => x.ExpluatationYear < 2010);
            foreach (Bus bus in intNumber)
            {
                Console.WriteLine(bus.ToString());
            }
            Bus.PrintType();
        }
    }
}