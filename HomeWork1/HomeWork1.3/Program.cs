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
            figures.Add(new Rectangle(3, 4));

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
