using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba11
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
}
