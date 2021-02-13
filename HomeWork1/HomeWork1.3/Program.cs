using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Figure> figures = new List<Figure>();

            figures.Add(new Circle(5));
            figures.Add(new Circle(10));
            figures.Add(new Rectangle(4, 6));
            figures.Add(new Rectangle(2, 5));
            figures.Add(new Square(4));
            figures.Add(new Square(5));
            figures.Add(new Triangle(4, 6, 4, 5, 8));
            figures.Add(new Triangle(5, 7, 5, 8, 9));
            figures.Add(new Trapezoid(7, 8, 13, 9, 9));
            figures.Add(new Trapezoid(5, 7, 15, 6, 7));

            foreach (var figure in figures)
            {
                figure.GetArea();
                figure.GetPerimeter();
            }

            Figure.Results();

            Console.ReadKey();
        }
    }
}
