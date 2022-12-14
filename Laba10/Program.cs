using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int n = 7; //3-9
            Console.WriteLine($"Months with str lengths {n}:");
            IEnumerable<string> result = from t in months
                                         where t.Length == n
                                         select t;
            foreach (string month in result) Console.WriteLine("- " + month);
            Console.WriteLine($"Summer and winter months:");
            IEnumerable<string> wintsum = from t in months
                                          where t == "January" || t == "February" || t == "June" || t == "July" || t == "August" || t == "December"
                                          select t;
            foreach (string month in wintsum) Console.WriteLine("- " + month);
            Console.WriteLine($"Alphabet order:");
            IEnumerable<string> alp = from t in months
                                      orderby t
                                      select t;
            foreach (string month in alp) Console.WriteLine("- " + month);
            Console.WriteLine($"Count 'u' and length>=4:" + months.Count(t => t.Contains('u') && t.Length >= 4));
            Console.WriteLine("------------------------------------------");
            List<Bus> buses = new List<Bus>() { new Bus("Водитель 1", 1022, 22, "МАЗ", 2000, 1000000),
                                                   new Bus("Водитель 2", 1153, 53, "Икарус", 2004, 120000),
                                                   new Bus("Водитель 3", 1230, 40, "МинскТранс", 2010, 120000),
                                                   new Bus("Водитель 4", 8790, 53, "ВАЗ", 2005, 50000),
                                                   new Bus("Водитель 5", 5567, 70, "Икарус", 2004, 120000),
                                                   new Bus("Водитель 6", 9238, 37, "УАЗ", 2001, 500000),
                                                   new Bus("Водитель 7", 5134, 62, "ГАЗ", 2003, 120000),
                                                   new Bus("Водитель 8", 3398, 20, "Икарус", 2012, 120000),
                                                   new Bus("Водитель 9", 7897, 22, "МАЗ", 2001, 120000),
                                                   new Bus("Водитель 10", 1090, 22, "БелАЗ", 2017, 120000) };

            /*var lst0 = buses.Where(p => p != null)
                .OrderBy(p => p.BusNumber)
                .ToList()
                .Select(p => p);*/
            //var lst0 = from p in buses where p.Mileage < 120000 select p;
            //Console.Write("Enter route:");
            Console.WriteLine($"Автобусы маршрута 22: ");
            int routeNumber = 22;//Console.ReadLine();
            var lst1 = from bus in buses where bus.RouteNumber == routeNumber select bus;
            foreach (var bus in lst1) bus.Info();
            //Console.Write("Enter expluatation period:");
            int expPeriod = 10;//int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine($"Автобусы которые долго эксплуатируются: ");
            var lst2 = from bus in buses where (2022 - bus.ExpluatationYear) > expPeriod select bus;
            foreach (var bus in lst2) bus.Info();
            Console.WriteLine($"Самый маленький пробег: {(from bus in buses select bus.Mileage).Min()}");
            Console.WriteLine($"Два последних с самым большим пробегом: ");
            var lst3 = buses
                .OrderByDescending(p => p.Mileage)
                .Take(2)
                .Select(p => p);
            foreach (var p in lst3) Console.WriteLine("- " + p.Mileage);
            Console.WriteLine($"Упорядочивание по номеру:");
            var sortBuses = buses.OrderBy(p => p.BusNumber).Select(p => p);
            foreach (var bus in sortBuses) Console.WriteLine("- " + bus.BusNumber);

            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine("Own request:"); // проекция авт. с годом экспл меньше 2010, упорядочить, затем по убыв, выбрать водителей с буквой "е"
            var own = buses
                .Where(p => p.ExpluatationYear < 2010)
                .OrderBy(p => p.ExpluatationYear)
                .Where(p => p.Name.Contains('е'))
                .Reverse()
                .Select(p => p);
            foreach (var bus in own) Console.WriteLine("- " + bus.Name);

            Console.WriteLine("---------------------------------------------------");



            List<Owner> owners = new List<Owner>() { new Owner("Я", 1000000) };

            var res = buses.Join(owners, //внутр. список
                         p => p.Mileage, //внутр ключ
                         o => o.Mileage, //внеш ключ
                         (p, o) => new { Owner = o.Name, Bus = p.BusNumber, Producer = p.Brand }); // результат

            foreach (var item in res)
                Console.WriteLine($"{item.Owner} купил автобус номер {item.Bus} от бренда {item.Producer}");
            Console.ReadKey();
        }
    }
}
