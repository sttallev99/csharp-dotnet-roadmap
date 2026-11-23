using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping;

public class Shipment
{
    public Item Item { get; }
    public ShipmentStatus Status { get; private set; } = ShipmentStatus.Created;

    public Shipment(Item item)
    {
        Item = item ?? throw new ArgumentNullException(nameof(item));
    }

    public void Pack()
    {
        EnsureStatus("pack", ShipmentStatus.Created);
        Status = ShipmentStatus.Packed;
    }

    public void Ship()
    {
        EnsureStatus("ship", ShipmentStatus.Packed);
        Status = ShipmentStatus.Shipped;
    }

    public void Deliver()
    {
        EnsureStatus("deliver", ShipmentStatus.Shipped);
        Status = ShipmentStatus.Delivered;
    }

    public void Cancel()
    {
        EnsureStatus("cancel", ShipmentStatus.Created, ShipmentStatus.Packed);
        Status = ShipmentStatus.Cancelled;
    }

    private void EnsureStatus(string action,params ShipmentStatus[] validStatuses)
    {
        if (Array.IndexOf(validStatuses, Status) < 0)
        {
            throw new InvalidOperationException($"Cannot {action} shipment when status is {Status}");
        }
    }
}
