using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping;

public static class ShippingCalculator
{
    private const decimal BaseCost = 5.00m;
    private const decimal CostPerKg = 2.00m;
    private const decimal FragileCost = 3.00m;
    private const decimal PerishableCost = 8.00m;
    private const decimal HeavyCost = 10.00m;
    public static decimal Cost(Item item)
    {
        decimal weightCost = item.WeightKg * CostPerKg; 
        decimal tagCost = 0.00m;
        if (item.Tags.HasFlag(ItemTags.Fragile))
        {
            tagCost += FragileCost; 
        }
        if (item.Tags.HasFlag(ItemTags.Perishable))
        {
            tagCost += PerishableCost; 
        }
        if (item.Tags.HasFlag(ItemTags.Heavy))
        {
            tagCost += HeavyCost; 
        }
        return BaseCost + weightCost + tagCost;
    }
}
