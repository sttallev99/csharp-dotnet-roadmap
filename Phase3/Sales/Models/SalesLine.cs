namespace Sales.Models;

public record SaleLine(int OrderId, DateOnly Date, int CustomerId, string Product,
                       string Category, int Quantity, decimal UnitPrice)
{
    public decimal Total => Quantity * UnitPrice;
}