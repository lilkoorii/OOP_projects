using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba7
{
    public class Ball //польз. класс
    {
        private readonly int id;
        private string title;
        private DateTime dateOfGetting; //дата завоза мячика
        private string stringobj;
        private int price;
        public Ball(string title, DateTime dateOfGetting, string brand, int price)
        {
            id = (int)title.GetHashCode() + (int)dateOfGetting.GetHashCode();
            this.title = title;
            this.dateOfGetting = dateOfGetting;
            this.stringobj = brand;
            this.price = price;
        }
        public string stringobject
        {
            get => stringobj;
            set => stringobj = value;

        }
        public string Title
        {
            get => title;
            set => title = value;
        }
        public DateTime DateOfGetting
        {
            get => dateOfGetting;
            set => dateOfGetting = value;
        }
        public override string ToString()
        {
            return "-------------------------------------------------------\nНазвание: " + Title + "\nДата завоза мячика: " + DateOfGetting.ToString("MM/dd/yyyy") + "\nБренд мячика:  " + stringobject + "\n-------------------------------------------------------\n";

        }
    }
}
