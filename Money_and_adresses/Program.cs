using Money_and_adresses;

var a = Money.Euro(10.50m);
var b = Money.Euro(5.25m);

Console.WriteLine(a + b);
Console.WriteLine(a - b);
Console.WriteLine(a * 3);
Console.WriteLine(a > b);
Console.WriteLine(a == new Money(10.50m, "EUR"));

try { Console.WriteLine(a + new Money(1m, "USD")); }
catch (InvalidOperationException ex) { Console.WriteLine($"Error: {ex.Message}"); }

var home = new Address("Sofia", "Vitosha 1", "1000");
var moved = home with { Street = "Rakovski 5" };
var same = new Address("Sofia", "Vitosha 1", "1000");

Console.WriteLine(home);
Console.WriteLine(moved);
Console.WriteLine(home == moved);
Console.WriteLine(home == same);

var unique = new HashSet<Address> { home, moved, same };
Console.WriteLine($"Unique addresses: {unique.Count}");