using System;
using System.Collections.Generic;
using System.Text;
using Notifcation_system.Models;

namespace Notifcation_system.Channels;

public class PushChannel : INotificationChannel
{
    public string Name => "Push";

    public bool CanSend(Contact c) => c.HasMobileApp;

    public void Send(Contact c, string message)
    {
        // Simulated: a real app would call a push notification service here
    }
}
