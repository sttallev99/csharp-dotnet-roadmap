using System;
using System.Collections.Generic;
using System.Text;
using Notifcation_system.Models;

namespace Notifcation_system.Channels;

public class SmsChannel : INotificationChannel
{
    private const int MaxMessageLength = 160;
    private const string Elipsis = "...";
    public string Name => "SMS";

    public bool CanSend(Contact c) => !string.IsNullOrWhiteSpace(c.Phone);

    public void Send(Contact c, string message)
    {
        string text = PrepareMessage(message);
        // Simulated: a real app would send `text` to contact.Phone through an SMS provider
    }

    public string PrepareMessage(string message) =>
        message.Length <= MaxMessageLength
            ? message
            : message[..(MaxMessageLength - Elipsis.Length)] + Elipsis;
}
