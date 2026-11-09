using Shapes;

List<Shape> shapes =
[
 new Circle(2),
 new Rectangle(3, 4),
 new Square(5),
 new Triangle(3, 4, 5)
];
foreach (var s in shapes.OrderByDescending(s => s.Area()))
    Console.WriteLine(s);
Console.WriteLine($"Total area: {shapes.Sum(s => s.Area()):F2}");
Console.WriteLine($"Largest: {shapes.MaxBy(s => s.Area())!.Name}");
try { new Triangle(1, 2, 10); }
catch (ArgumentException ex) { Console.WriteLine($"Error: {ex.Message}"); }
