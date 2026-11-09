using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes;

public abstract class Shape
{
    public string Name { get; private set; }

    protected Shape(string name)
    {
        Name = name;
    }

    public abstract double Area();

    public abstract double Perimeter();
}
