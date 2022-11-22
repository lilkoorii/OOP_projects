using System;
using System.Collections.Generic;
using System.Text;

namespace Laba5
{
    public class Equipment : Gym, IMakeGym
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public Equipment(string name, string shape, string type, Sum sum)
        {
            this.Name = name;
            this.Shape = shape;
            this.Type = type;
            this.Sum = sum;
        }

        public override string ToString()
        {
            return "Тип объекта: " + GetType().Name + "\nНазвание: " + Shape + "\nТип: " + Type + "\nЦена: " + Sum.Dollar + " долларов " + Sum.Cent + " центов\n" + new String('-', 50);
        }

        public void MakeGym(IGymAssembly gymAssembling)
        {
            gymAssembling.StartGetBall(new BallGet());
        }
    }


}
