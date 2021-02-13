using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1._1
{
    #region homework1.1
    // Создать абстрактный базовый класс Фигура с методами вычисления площади и периметра.
    // Создать производные классы: Прямоугольника и Круга со своими функциями площади и периметра.
    // Самостоятельно определить, какие поля необходимы, какие из них можно задать в базовом классе, а какие в производных.
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Figure circle1 = new Circle(10);
            Figure rectangle1 = new Rectangle(5, 3);

            circle1.ShowFigure();
            Console.WriteLine(circle1.GetArea());
            Console.WriteLine(circle1.GetPerimeter());

            rectangle1.ShowFigure();
            Console.WriteLine(rectangle1.GetArea());
            Console.WriteLine(rectangle1.GetPerimeter());

            Console.ReadKey();
        }
    }
}
