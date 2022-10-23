using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONTROLNAYA
{
    public class Shop : ICompare
    {
        public int quantity = 5;
        int[] arr;
        string[] tovary;
        public Shop(string[] tovar) => tovary = tovar;
        // индексатор
        public string this[int index]
        {
            get => tovary[index];
            set => tovary[index] = value;
        }

        public bool Compare(Shop shop1, Shop shop2)
        {
                if (shop1.tovary[1] == shop2.tovary[1])
                    return true;
                else return false;
        }
        public Shop(string str1, string str2)
        {
            tovary[0] = str1;
            tovary[1] = str2;
        }
        public Shop(string str1, string str2, string str3, string str4, string str5)
        {
            tovary[0] = str1;
            tovary[1] = str2;
            tovary[2] = str3;   
            tovary[3] = str4;
            tovary[4] = str5;   
        }
    }

    interface ICompare
    {
        bool Compare(Shop shop1, Shop shop2);
    }

}
