using PartB_Sales;
using PartB_Sales.Models;
using Sales.Models;
using System.Globalization;

// Same number format on every PC (1,234.56), so the output matches the PDF
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

string dataDir = Path.Combine(AppContext.BaseDirectory, "Data");
List<Customer> customers = DataLoader.LoadCustomers(Path.Combine(dataDir, "customers.csv"));
List<SaleLine> lines = DataLoader.LoadSales(Path.Combine(dataDir, "sales.csv"));

// ---- Shared helpers, built ONCE ----
Dictionary<int, Customer> customerById = customers.ToDictionary(c => c.Id);
string NameOf(int customerId) => customerById[customerId].Name;

List<SaleLine> lines2026 = lines.Where(l => l.Date.Year == 2026).ToList();

List<OrderSummary> orders = lines
    .GroupBy(l => l.OrderId)
    .Select(g => new OrderSummary(
        OrderId: g.Key,
        Date: g.First().Date,
        CustomerId: g.First().CustomerId,
        Total: g.Sum(l => l.Total),
        LineCount: g.Count()))
    .ToList();

var productStats = lines
    .GroupBy(l => l.Product)
    .Select(g => new { Product = g.Key, Units = g.Sum(l => l.Quantity), Revenue = g.Sum(l => l.Total) })
    .ToList();

var monthly = lines
    .GroupBy(l => l.Date.ToString("yyyy-MM"))
    .Select(g => new { Month = g.Key, Revenue = g.Sum(l => l.Total) })
    .OrderBy(m => m.Month)                 // "yyyy-MM" text sorts chronologically
    .ToList();

// ---- 1 ----
Q(1, "Lines and orders");
Console.WriteLine($"   Lines: {lines.Count}, orders: {lines.Select(l => l.OrderId).Distinct().Count()}");

// ---- 2 ----
Q(2, "Total revenue");
Console.WriteLine($"   {lines.Sum(l => l.Total):N2}");

// ---- 3 ----
Q(3, "Revenue in 2026");
Console.WriteLine($"   {lines2026.Sum(l => l.Total):N2}");

// ---- 4 ----
Q(4, "Revenue per customer");
var perCustomer = lines
    .GroupBy(l => l.CustomerId)
    .Select(g => new { Name = NameOf(g.Key), Total = g.Sum(l => l.Total) })
    .OrderByDescending(x => x.Total);
foreach (var x in perCustomer)
    Console.WriteLine($"   {x.Name,-16}{x.Total,10:N2}");

// ---- 5 ----
Q(5, "Top 3 products by revenue");
foreach (var p in productStats.OrderByDescending(p => p.Revenue).Take(3))
    Console.WriteLine($"   {p.Product,-11}{p.Revenue,10:N2}  ({p.Units} units)");

// ---- 6 ----
Q(6, "Top 3 products by units");
var byUnits = productStats
    .OrderByDescending(p => p.Units)
    .ThenBy(p => p.Product, StringComparer.Ordinal)
    .Take(3);
foreach (var p in byUnits)
    Console.WriteLine($"   {p.Product,-11}{p.Units,4}");

// ---- 7 ----
Q(7, "Revenue per category");
var perCategory = lines
    .GroupBy(l => l.Category)
    .Select(g => new { Category = g.Key, Revenue = g.Sum(l => l.Total) })
    .OrderByDescending(c => c.Revenue);
foreach (var c in perCategory)
    Console.WriteLine($"   {c.Category,-12}{c.Revenue,10:N2}");

// ---- 8 ----
Q(8, "Monthly totals");
foreach (var m in monthly)
    Console.WriteLine($"   {m.Month}  {m.Revenue,10:N2}");

// ---- 9 ----
Q(9, "Customers with no orders in 2026");
HashSet<int> buyers2026 = lines2026.Select(l => l.CustomerId).ToHashSet();
var inactive = customers.Where(c => !buyers2026.Contains(c.Id)).Select(c => c.Name);
Console.WriteLine($"   {string.Join(", ", inactive)}");

// ---- 10 ----
Q(10, "Average order value");
decimal avgOrder = Math.Round(orders.Average(o => o.Total), 2, MidpointRounding.AwayFromZero);
Console.WriteLine($"   {avgOrder:N2}");

// ---- 11 ----
Q(11, "Largest order");
OrderSummary largest = orders.MaxBy(o => o.Total)!;
Console.WriteLine($"   Order {largest.OrderId}, {NameOf(largest.CustomerId)}, {largest.Total:N2}");

// ---- 12 ----
Q(12, "Orders with more than 2 lines");
Console.WriteLine($"   {string.Join(", ", orders.Where(o => o.LineCount > 2).Select(o => o.OrderId))}");

// ---- 13 ----
Q(13, "Orders per city");
var perCity = orders
    .Join(customers, o => o.CustomerId, c => c.Id, (o, c) => c.City)
    .GroupBy(city => city)
    .Select(g => new { City = g.Key, Orders = g.Count() })
    .OrderByDescending(x => x.Orders)
    .ThenBy(x => x.City, StringComparer.Ordinal);
foreach (var x in perCity)
    Console.WriteLine($"   {x.City,-8}{x.Orders,3}");

// ---- 14 ----
Q(14, "Laptop buyers");
var laptopBuyers = lines
    .Where(l => l.Product == "Laptop")
    .Select(l => NameOf(l.CustomerId))
    .Distinct()
    .Order(StringComparer.Ordinal);
Console.WriteLine($"   {string.Join(", ", laptopBuyers)}");

// ---- 15 ----
Q(15, "Customers with 2+ categories");
var multiCategory = lines
    .GroupBy(l => l.CustomerId)
    .Select(g => new { Name = NameOf(g.Key), Categories = g.Select(l => l.Category).Distinct().Count() })
    .Where(x => x.Categories >= 2)
    .OrderByDescending(x => x.Categories)
    .ThenBy(x => x.Name, StringComparer.Ordinal);
foreach (var x in multiCategory)
    Console.WriteLine($"   {x.Name,-16}{x.Categories,2}");

// ---- 16 ----
Q(16, "First and last order per customer");
var history = lines
    .GroupBy(l => l.CustomerId)
    .Select(g => new
    {
        Name = NameOf(g.Key),
        First = g.Min(l => l.Date),
        Last = g.Max(l => l.Date),
        Orders = g.Select(l => l.OrderId).Distinct().Count()
    })
    .OrderBy(x => x.Name, StringComparer.Ordinal);
foreach (var x in history)
    Console.WriteLine($"   {x.Name,-16}{x.First:yyyy-MM-dd}  {x.Last:yyyy-MM-dd}{x.Orders,3}");

// ---- 17 ----
Q(17, "Best month");
var best = monthly.MaxBy(m => m.Revenue)!;
Console.WriteLine($"   {best.Month} with {best.Revenue:N2}");

// ---- 18 ----
Q(18, "Sold in 2026, not in 2025");
var products2025 = lines.Where(l => l.Date.Year == 2025).Select(l => l.Product);
var newProducts = lines2026.Select(l => l.Product).Except(products2025);
Console.WriteLine($"   {string.Join(", ", newProducts)}");

// ---- 19 ----
Q(19, "Electronics share of 2026 revenue");
decimal electronics2026 = lines2026.Where(l => l.Category == "Electronics").Sum(l => l.Total);
decimal total2026 = lines2026.Sum(l => l.Total);
decimal share = Math.Round(electronics2026 * 100 / total2026, 2, MidpointRounding.AwayFromZero);
Console.WriteLine($"   {share:F2} % ({electronics2026:N2} of {total2026:N2})");

// ---- 20 ----
Q(20, "Page 2 of orders (page size 5)");
const int pageSize = 5;
int page = 2;
var pageIds = orders
    .OrderBy(o => o.Date)
    .ThenBy(o => o.OrderId)
    .Skip((page - 1) * pageSize)
    .Take(pageSize)
    .Select(o => o.OrderId);
Console.WriteLine($"   {string.Join(", ", pageIds)}");

// ---- helper ----
static void Q(int number, string title)
{
    if (number > 1) Console.WriteLine();
    Console.WriteLine($"{number}. {title}");
}