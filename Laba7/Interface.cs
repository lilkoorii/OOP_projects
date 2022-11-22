using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba7
{
    internal interface IFunction<T>
    {
        void Add(T element);
        void Remove(int pos);
        void Show();
    }
}
