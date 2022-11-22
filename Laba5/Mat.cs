using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Laba5
{
    public class Mat : Gym, IGymAssembly
    {
        public string Composition { get; set; }
        public int Density { get; set; }
        public string Name { get; set; }
        private string _shape;
        public new string Shape
        {
            get
            {
                return _shape;
            }
            set
            {
                if (value.Length < 1 || value.Length > 20)
                {
                    throw new ShapeException("Ошибка! Неккоректно введена форма:", Shape);
                }
                else _shape = value;
            }
        }
        public Mat(string name, string shape, string composition, Sum sum, int dens)
        {
            this.Name = name;
            this.Shape = shape;
            base.Shape = shape;
            this.Composition = composition; //состав мата
            this.Sum = sum;
            this.Density = dens;
        }
        public override string ToString()
        {
            return "Тип объекта: " + GetType().Name + "\nНазвание: " + Name + "\nФорма: " + Shape + "\nСостав: " + Composition + "\nЦена: " + Sum.Dollar + " долларов " + Sum.Cent + " центов\nПлотность мата: " + Density + "\n" + new String('-', 50);
        }
        public void StartGetBall(BallGet getBall)
        {
            if (getBall.TryGetting())
                Console.WriteLine("Мат взялся.");
            else Console.WriteLine("Мат не удалось взять - у вас сломана рука :(");
        }
        /*public void CheckForException()
        {
            if (this.Shape.Length < 1 || this.Shape.Length > 20)
            {
                throw new ShapeException("Ошибка! Неккоректно введена форма:", Shape);
                Console.WriteLine("Ошибка ShapeException.");
            }
        } */

    }
    public partial class GymPerson //partial class (pt.1)
    {
        public void Move()
        {
            Console.WriteLine("I am moving");
        }
    }

}
