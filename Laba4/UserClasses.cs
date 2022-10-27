using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{   // Одноименные методы
    abstract class BaseClone : ICloneable
    {
        public abstract bool DoClone();
    }

    class UserClass : BaseClone, ICloneable // Определение DoClone()
    {
        public override bool DoClone()
        {
            return true;
        }
    }
    class UserClass2 : BaseClone, ICloneable //Другое определение DoClone
    {
        public override bool DoClone()
        {
            return false;
        }
    }
}
