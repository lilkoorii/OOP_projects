using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba11
{
    public interface Show
    {
        void Show();
    }
    public class Test : Show
    {
        public string name;
        public Type a = typeof(Int32);
        public Test(string name)
        {
            this.name = name;
        }
        public Test()
        {
            this.name = null;
        }
        public void Show()
        {
            Console.WriteLine(name);
        }
        public void ToConsole(List<string> arr)
        {
            foreach (string str in arr)
            {
                Console.WriteLine(str);
            }
        }
        public override string ToString()
        {
            return "Object of class Test with name " + name;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string test = "Laba11.Test";
            Reflector.Name();
            Reflector.ToFile(Reflector.GetConstructor("Laba11.Test"));
            Reflector.ToFile(Reflector.Pub("Laba11.Test"));
            Reflector.ToFile(Reflector.Field("Laba11.Test"));
            Reflector.ToFile(Reflector.Interface("Laba11.Test"));
            Reflector.ToFile(Reflector.MethodForType("Laba11.Test", "Int32"));
            Reflector.Invoke("Laba11.Test", "ToConsole");
            Console.ReadKey();
        }
    }
}
