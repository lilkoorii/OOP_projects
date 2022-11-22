using System;
using System.Collections.Generic;
using System.Text;

namespace Laba5
{
    enum Operations
    {
        Add,
        Delete,
        Display,
        SearchTotal,
        SearchDensity,
        Count
    }
    public struct Sum //структура
    {
        public int Dollar;
        public int Cent;
        public Sum(int dollar, int cent)
        {
            this.Dollar = dollar;
            this.Cent = cent;
        }
    }
}
