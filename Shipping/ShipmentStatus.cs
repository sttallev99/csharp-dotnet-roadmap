using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping;

public enum ShipmentStatus
{
    Created,
    Packed,
    Shipped,
    Delivered,
    Cancelled
}