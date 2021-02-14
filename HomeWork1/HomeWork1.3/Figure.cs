using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1._3
{
    #region homework1.3
    // Расширить предыдущее решение с добавлением следующих производных классов: Трапеции, Квадрата и Треугольника.
    #endregion
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
            return (Length + Width) * 2;
        }
    }

    class Square : Figure
    {
        public double SideLength { get; }

        public Square(double sideLength)
        {
            if (sideLength > 0)
            {
                SideLength = sideLength;
            }
            else
            {
                throw new ArgumentException("Negative value!");
            }
        }
        public override double GetArea()
        {
            return Math.Pow(SideLength, 2);
        }
        public override double GetPerimeter()
        {
            return SideLength * 4;
        }
    }

    class Triangle : Figure
    {
        public double Base { get; }
        public double Height { get; }
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public Triangle(double baselength, double height, double sideA, double sideB, double sideC)
        {
            if (baselength > 0 && height > 0 && sideA > 0 && sideB > 0 && sideC > 0)
            {
                Base = baselength;
                Height = height;
                SideA = sideA;
                SideB = sideB;
                SideC = sideC;
            }
            else
            {
                throw new ArgumentException("Negative value!");
            }
        }
        public override double GetArea()
        {
            return 0.5 * Base * Height;
        }
        public override double GetPerimeter()
        {
            return SideA + SideB + SideC;
        }
    }

    class Trapezoid : Figure
    {
        public double Height { get; }
        public double TopBase { get; }
        public double BottomBase { get; }
        public double LeftBase { get; }
        public double RightBase { get; }

        public Trapezoid(double height, double topBase, double bottomBase, double leftBase, double rightBase)
        {
            if (height > 0 && topBase > 0 && bottomBase > 0 && leftBase > 0 && rightBase > 0)
            {
                Height = height;
                TopBase = topBase;
                BottomBase = bottomBase;
                LeftBase = leftBase;
                RightBase = rightBase;
            }
            else
            {
                throw new ArgumentException("Negative value!");
            }
        }
        public override double GetArea()
        {
            return Height * ((TopBase + BottomBase) / 2);
        }
        public override double GetPerimeter()
        {
            return TopBase + BottomBase + LeftBase + RightBase;
        }
    }
}
