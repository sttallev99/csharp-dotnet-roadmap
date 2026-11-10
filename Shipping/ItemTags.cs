using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping;

[Flags]
public enum ItemTags
{
    None = 0,
    Fragile = 1,
    Perishable = 2,
    Heavy = 4,
}