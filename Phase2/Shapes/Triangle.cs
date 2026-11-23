using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes;

public class Triangle : Shape
{
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public Triangle(double a, double b, double c): base("Triangle")
    {
        if (a + b <= c || a + c <= b || b + c <= a)
            throw new ArgumentException("Invalid triangle sides.");
        A = a; B = b; C = c;
    }

    public override double Perimeter() => A + B + C;

    public override double Area()
    {
        double s = Perimeter() / 2;
        return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
    }

    public override string ToString() => $"{Name} | Area: {Area():F2} | Perimeter: {Perimeter():F2}";
}
