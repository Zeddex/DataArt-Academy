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
        public const double PI = 3.141;

        protected static double areaSummary = 0;
        protected static double perimeterSummary = 0;


        public abstract double GetArea();
        public abstract double GetPerimeter();

        public double GetSummaryArea() => areaSummary;
        public double GetSummaryPerimeter() => perimeterSummary;

        static public void Results()
        {
            Console.WriteLine($"Sum of areas = {areaSummary}");
            Console.WriteLine($"Sum of perimeters = {perimeterSummary}");
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
            double area = (PI * Math.Pow(Radius, 2));
            areaSummary += area;
            return area;
        }

        public override double GetPerimeter()
        {
            double perimeter = 2 * PI * Radius;
            perimeterSummary += perimeter;
            return perimeter;
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
            double area = Length * Width;
            areaSummary += area;
            return area;
        }
        public override double GetPerimeter()
        {
            double perimeter = (Length + Width) * 2;
            perimeterSummary += perimeter;
            return perimeter;
        }
    }

    class Square : Figure
    {
        public double SideLength { get; set; }

        public Square() { }
        public Square(double sideLength)
        {
            SideLength = sideLength;
        }
        public override double GetArea()
        {
            double area = Math.Pow(SideLength, 2);
            areaSummary += area;
            return area;
        }
        public override double GetPerimeter()
        {
            double perimeter = SideLength * 4;
            perimeterSummary += perimeter;
            return perimeter;
        }
    }

    class Triangle : Figure
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle() { }
        public Triangle(double baselength, double height, double sideA, double sideB, double sideC)
        {
            Base = baselength;
            Height = height;
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }
        public override double GetArea()
        {
            double area = 0.5 * Base * Height;
            areaSummary += area;
            return area;
        }
        public override double GetPerimeter()
        {
            double perimeter = SideA + SideB + SideC;
            perimeterSummary += perimeter;
            return perimeter;
        }
    }

    class Trapezoid : Figure
    {
        public double Height { get; set; }
        public double TopBase { get; set; }
        public double BottomBase { get; set; }
        public double LeftBase { get; set; }
        public double RightBase { get; set; }

        public Trapezoid() { }
        public Trapezoid(double height, double topBase, double bottomBase, double leftBase, double rightBase)
        {
            Height = height;
            TopBase = topBase;
            BottomBase = bottomBase;
            LeftBase = leftBase;
            RightBase = rightBase;
        }
        public override double GetArea()
        {
            double area = Height * ((TopBase + BottomBase) / 2);
            areaSummary += area;
            return area;
        }
        public override double GetPerimeter()
        {
            double perimeter = TopBase + BottomBase + LeftBase + RightBase;
            perimeterSummary += perimeter;
            return perimeter;
        }
    }
}
