namespace Sales.Models;

public record OrderSummary(int OrderId, DateOnly Date, int CustomerId, decimal Total, int LineCount);