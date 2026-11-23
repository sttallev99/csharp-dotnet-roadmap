using Notifcation_system.Channels;
using Notifcation_system.Models;

namespace Task06_Notifications.Channels;

public class EmailChannel : INotificationChannel
{
    public string Name => "Email";

    public bool CanSend(Contact contact) => contact.Email?.Contains('@') == true;

    public void Send(Contact contact, string message)
    {
        // Simulated: a real app would send an email to contact.Email here
    }
}