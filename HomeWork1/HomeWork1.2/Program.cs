using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1._2
{
    #region homework1.2
    // Дана коллекция фигур, известно, что они не пересекаются между собой.
    // Необходимо найти суммарную площадь и периметр всех фигур в коллекции.
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            double sumArea = 0;
            double sumPerimeter = 0;

            List<Figure> figures = new List<Figure>();

            figures.Add(new Circle(5));
            figures.Add(new Circle(10));
            figures.Add(new Rectangle(4, 6));
            figures.Add(new Rectangle(2, 5));
            figures.Add(new Rectangle(3, 4));

            foreach (var figure in figures)
            {
                sumArea += figure.GetArea();
                sumPerimeter += figure.GetPerimeter();
            }

            Console.WriteLine($"Sum of areas = {sumArea}");
            Console.WriteLine($"Sum of perimeters = {sumPerimeter}");

            Console.ReadKey();
        }
    }
}
