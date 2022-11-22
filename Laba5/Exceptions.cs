using System;
using System.Collections.Generic;
using System.Text;

namespace Laba5
{
    public class MyException : System.Exception
    {
        public string ErrorClass { get; set; }
        public MyException(string message, string errorClass) : base(message) //наследуем message от System.Exception
        {
            this.ErrorClass = errorClass;
        }
    }
    public class TotalException : MyException
    {
        public int Dollar { get; set; }
        public int Cent { get; set; }
        public TotalException(string message, int errorDollar, int errorCent) : base(message, "Ошибка код 1: некорректная цена!\n") //наследуем message и errorClass от MyException
        {
            this.Dollar = errorDollar;
            this.Cent = errorCent;
        }
    }
    public class CentException : MyException
    {
        public int Cent { get; set; }
        public CentException(string message, int errorCent) : base(message, "Ошибка код 2: некорректное кол-во центов!\n")
        {
            this.Cent = errorCent;
        }
    }
    public class SearchDensityException : MyException
    {
        public int Density { get; set; }
        public SearchDensityException(string message, int errorDensity) : base(message, "Ошибка код 3: некорректный ввод степени надутия для поиска!\n")
        {
            this.Density = errorDensity;
        }
    }
    public class ShapeException : MyException
    {
        public string Shape { get; set; }
        public ShapeException(string message, string errorShape) : base(message, "Ошибка код 4: некорректная форма!\n")
        {
            this.Shape = errorShape;
        }
    }
}
