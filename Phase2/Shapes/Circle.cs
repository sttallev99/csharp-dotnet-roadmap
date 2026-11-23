using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes;

public class Circle : Shape
{ 
    public int Radius { get; }

    public Circle(int radius) : base("Circle")
    {
        if(radius <= 0)
            throw new ArgumentException("Radius must be greater than 0");
        Radius = radius;
    }

    public override double Area() => Math.PI * Radius * Radius;

    public override double Perimeter() => 2 * Math.PI * Radius;

    public override string ToString() => $"{Name} | Area: {Area():F2} | Perimeter: {Perimeter():F2}";
}

