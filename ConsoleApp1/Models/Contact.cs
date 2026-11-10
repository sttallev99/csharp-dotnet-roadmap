using System;
using System.Collections.Generic;
using System.Text;

namespace Notifcation_system.Models;

public record Contact(string Name, string? Email, string? Phone, bool HasMobileApp);