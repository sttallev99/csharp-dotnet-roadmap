using System;
using System.Collections.Generic;
using System.Text;
using Notifcation_system.Models;

namespace Notifcation_system.Channels
{
    internal interface INotificationChannel
    {
        string Name { get; }
        bool CanSend(Contact c);

        void Send(Contact c, string message);

        string PrepareMessage(string message) => message;
    }   
}
