using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1._1
{
    abstract class Figure
    {
        public const double PI = 3.141;

        public abstract double GetArea();
        public abstract double GetPerimeter();

        public virtual void ShowFigure()
        {
            Console.WriteLine("Current figure");
        }
    }

    class Circle : Figure
    {

        public double Radius { get; set; }
        public Circle() { }
        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return (PI * Math.Pow(Radius, 2));
        }

        public override double GetPerimeter()
        {
            return 2 * PI * Radius;
        }

        public override void ShowFigure()
        {
            base.ShowFigure();
            Console.WriteLine("Circle");
        }
    }

    class Rectangle : Figure
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle() { }
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }
        public override double GetArea()
        {
            return Length * Width;
        }
        public override double GetPerimeter()
        {
            return (Length + Width) * 2;
        }
        public override void ShowFigure()
        {
            base.ShowFigure();
            Console.WriteLine("Rectangle");
        }
    }
}
