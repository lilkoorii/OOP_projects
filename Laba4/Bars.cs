using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    class Bars : Inventory  //Брусья
    {
        public override bool DoClone()
        {
            return true;
        }
        public int personWeight;
        public Bars() { }
        public Bars(int weight, int gym, int Month)
        {
            this.personWeight = weight;
            this.GymNumber = gym;
            this.Month = Month;
        }
        public override string ToString()
        {
            return "Брусья, выдерживающие вес " + personWeight + "кг из зала номер " + GymNumber + ", завезены в зал в " + Month + " месяце.";
        }
    }
}
