using System;
using System.Collections.Generic;
using System.Text;

namespace Notifcation_system.Loging;
internal class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine($"[LOG] {message}");
}
