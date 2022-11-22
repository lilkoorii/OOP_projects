using System;
using System.Collections.Generic;
using System.Text;

namespace Laba5
{
    public abstract class Gym : IName
    {
        public string Shape { get; set; }
        public Sum Sum;
    }
    public partial class GymPerson //partial class (pt.2)
    {
        public void Exercise()
        {
            Console.WriteLine("I am exercising");
        }
    }
}
