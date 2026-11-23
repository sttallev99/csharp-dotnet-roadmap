using Shipping;

List<Item> items =
[
    new("Laptop", 2.5m, ItemTags.Fragile),
    new("Milk", 1m, ItemTags.Perishable),
    new("Fridge", 60m, ItemTags.Heavy | ItemTags.Fragile),
    new("Book", 0.5m, ItemTags.None)
];

foreach (var item in items)
    Console.WriteLine($"{item.Name,-8}{item.Tags,-16}{ShippingCalculator.Cost(item),8:N2}");

var fragile = items.Where(i => i.Tags.HasFlag(ItemTags.Fragile)).Select(i => i.Name);
Console.WriteLine($"Fragile: {string.Join(", ", fragile)}");

var shipment = new Shipment(items[0]);
shipment.Pack();
shipment.Ship();
Console.WriteLine($"Status: {shipment.Status}");

try { shipment.Cancel(); }
catch (InvalidOperationException ex) { Console.WriteLine($"Error: {ex.Message}"); }

shipment.Deliver();
Console.WriteLine($"Status: {shipment.Status}");

try { shipment.Pack(); }
catch (InvalidOperationException ex) { Console.WriteLine($"Error: {ex.Message}"); }