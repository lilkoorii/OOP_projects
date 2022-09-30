using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Bus
{
    public string Name = "Undefined";
    public int BusNumber;
    public int RouteNumber;
    public string BrandName = "Undefined";
    public byte Year;
    public int Mileage;

    public void AgePrint()
    {
        Console.WriteLine("Возраст автобуса: {0}", (2022 - Year));
    }
}

namespace Laba2
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
