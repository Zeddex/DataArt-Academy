using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1._2
{
    abstract class Figure
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    class Circle : Figure
    {

        public double Radius { get; }
        public Circle(double radius)
        {
            if (radius > 0)
            {
                Radius = radius;
            }
            else
            {
                throw new ArgumentException("Negative value!");
            }
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    class Rectangle : Figure
    {
        public double Length { get; }
        public double Width { get; }

        public Rectangle(double length, double width)
        {
            if (length > 0 && width > 0)
            {
                Length = length;
                Width = width;
            }

            else
            {
                throw new ArgumentException("Negative value!");
            }
        }
        public override double GetArea()
        {
            return Length * Width;
        }
        public override double GetPerimeter()
        {
            return Length + Width * 2;
        }
    }
}