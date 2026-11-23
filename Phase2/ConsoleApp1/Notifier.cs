using System;
using System.Collections.Generic;
using System.Text;
using Notifcation_system.Channels;
using Notifcation_system.Loging;
using Notifcation_system.Models;

namespace Notifcation_system;
internal class Notifier
{
    private readonly IReadOnlyList<INotificationChannel> _channels;
    private readonly ILogger _logger;

    public Notifier(IReadOnlyList<INotificationChannel> channels, ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(channels);
        ArgumentNullException.ThrowIfNull(logger);

        if(channels.Count == 0)
        {
            throw new ArgumentException("At least one channel must be provided", nameof(channels));
        }

        _channels = channels;
        _logger = logger;
    }

    public bool Notify(Contact c, string message)
    {
        ArgumentNullException.ThrowIfNull(c);


        INotificationChannel? channel = _channels.FirstOrDefault(ch => ch.CanSend(c));

        if(channel is null)
        {
            _logger.Log($"No channel available to send message to {c.Name}");
            return false;
        }

        string text = channel.PrepareMessage(message);
        channel.Send(c, text);
        _logger.Log($"{channel.Name} → {c.Name}: {text}");   
        return true;
    }
}
