using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{   
    class Printer //дополнительный класс Printer c полиморфным методом IAmPrinting.
    {
        public string IAmPrinting(Inventory someobj)
        {
            return someobj.ToString();
        }
        public string IAmPrinting(Bench someobj)
        {
            return someobj.ToString();
        }
        public string IAmPrinting(Bars someobj)
        {
            return someobj.ToString();
        }
    }
}
