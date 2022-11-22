using System;
using System.Collections.Generic;
using System.Text;

namespace Laba5
{
    public interface IName
    {
        string Shape { get { return Shape; } set { this.Shape = value; } }
    }

    public interface IMakeGym
    {
        public void MakeGym(IGymAssembly gymAssembling); //Gym assembly - создание зала
    }

    public interface IGymAssembly
    {
        public void StartGetBall(BallGet getBall);
        public int Density { get; set; }
    }
}
