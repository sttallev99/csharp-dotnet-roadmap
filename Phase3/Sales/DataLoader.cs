using PartB_Sales.Models;
using Sales.Models;
using System.Globalization;

namespace PartB_Sales;

public static class DataLoader
{
    private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

    public static List<Customer> LoadCustomers(string path) =>
        ReadRows(path)
            .Select(p => new Customer(int.Parse(p[0], Inv), p[1], p[2]))
            .ToList();

    public static List<SaleLine> LoadSales(string path) =>
        ReadRows(path)
            .Select(p => new SaleLine(
                OrderId: int.Parse(p[0], Inv),
                Date: DateOnly.ParseExact(p[1], "yyyy-MM-dd", Inv),
                CustomerId: int.Parse(p[2], Inv),
                Product: p[3],
                Category: p[4],
                Quantity: int.Parse(p[5], Inv),
                UnitPrice: decimal.Parse(p[6], NumberStyles.Number, Inv)))
            .ToList();

    private static IEnumerable<string[]> ReadRows(string path) =>
        File.ReadLines(path)
            .Skip(1)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => line.Split(',').Select(f => f.Trim()).ToArray());
}