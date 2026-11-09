using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes;

public class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }
    public Rectangle(double width, double height): base("Rectangle")
    {
        Width = width;
        Height = height;
    }

    public override double Perimeter() => 2 * (Width + Height);
    public override double Area() => Width * Height;

    public override string ToString() => $"{Name} | Area: {Area():F2} | Perimeter: {Perimeter():F2}";
}