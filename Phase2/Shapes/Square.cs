using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes;

public class Square : Shape
{
    public double Side { get; }
    public Square(double side): base("Square") => Side = side;

    public override double Perimeter() => 4 * Side;
    public override double Area() => Side * Side;

    public override string ToString() => $"{Name} | Area: {Area():F2} | Perimeter: {Perimeter():F2}, ";
}