using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping;

public record Item(string Name, decimal WeightKg, ItemTags Tags);
