using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Laba13
{

    [Serializable]
    public abstract class Bus
    {
        public readonly int id;
        public string type;
        public DateTime dateOfExpluatation;
        public string driver;
        public string brand;
        public Bus() { }
        public Bus(string type, DateTime dateOfExpluatation, string driver, string brand)
        {
            id = (int)type.GetHashCode() + (int)dateOfExpluatation.GetHashCode();
            this.type = type;
            this.dateOfExpluatation = dateOfExpluatation;
            this.driver = driver;
            this.brand = brand;
        }

        public string Type
        {
            get => type;
            set => type = value;
        }
        public DateTime DateOfExpluatation
        {
            get => dateOfExpluatation;
            set => dateOfExpluatation = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            return this.Type == ((Bus)obj).Type;
        }
        public override int GetHashCode()
        {
            int hash = 47, d = 32;
            string a = Convert.ToString(Type);
            hash = string.IsNullOrEmpty(a) ? 0 : Type.GetHashCode();
            hash = (hash * 47) + d.GetHashCode();
            return hash;
        }
        public abstract void Info();
        virtual public int GetTotalPrice() { return 0; }
    }
    [Serializable]
    [XmlRoot]
    public class BusRoot : Bus
    {
        //[NonSerialized]
        public int totalPrice;
        public BusRoot() { }
        public BusRoot(string type, DateTime dateOfExpluatation, string driver, string brand, int totalPrice)
               : base(type, dateOfExpluatation, driver, brand)
        {
            this.totalPrice = totalPrice;
        }
        public string ToString()
        {
            return Type + " " + DateOfExpluatation.ToString("MM/dd/yyyy") + " " + driver + " " + brand + " " + totalPrice + "\n--------------------------------------\n";
        }
        public override void Info()
        {
            Console.WriteLine("-----------" + Type + "-----------\n" + "Дата эксплуатации: " + DateOfExpluatation.ToString("MM/dd/yyyy") + "\n" + "Водитель: " + driver + "\n" + "Бренд: " + brand + "\n" + "Итоговая стоимость: " + totalPrice);
        }
        override public int GetTotalPrice()
        {
            return totalPrice;
        }

    }

}