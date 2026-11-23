using ConsoleApp1;

var customers = new InMemoryRepository<Customer>();
customers.Add(new Customer { Name = "Ana", City = "Sofia" });
customers.Add(new Customer { Name = "Ivan", City = "Plovdiv" });
customers.Add(new Customer { Name = "Maria", City = "Sofia" });

var products = new InMemoryRepository<Product>();
products.Add(new Product { Name = "Laptop", Price = 1200m });
products.Add(new Product { Name = "Mouse", Price = 20m });

Console.WriteLine($"Customers: {customers.Count}, products: {products.Count}");
Console.WriteLine(customers.GetById(2)?.Name ?? "not found");
Console.WriteLine(customers.GetById(99)?.Name ?? "not found");

var sofia = customers.Find(c => c.City == "Sofia");
Console.WriteLine($"Sofia: {string.Join(", ", sofia.Select(c => c.Name))}");

Console.WriteLine(products.Remove(1));
Console.WriteLine(products.Remove(1));
Console.WriteLine($"Products left: {string.Join(", ", products.GetAll().Select(p => $"#{p.Id} {p.Name}"))}");