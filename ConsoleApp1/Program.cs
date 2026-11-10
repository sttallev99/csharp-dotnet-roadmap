using Notifcation_system;
using Notifcation_system.Channels;
using Notifcation_system.Loging;
using Notifcation_system.Models;
using System.Text;
using Task06_Notifications.Channels;

Console.OutputEncoding = Encoding.UTF8;   // so the → arrow prints correctly

var notifier = new Notifier(
    [new PushChannel(), new SmsChannel(), new EmailChannel()],
    new ConsoleLogger());

var ana = new Contact("Ana", "ana@mail.com", "0888123456", HasMobileApp: true);
var ivan = new Contact("Ivan", "ivan@mail.com", "0899111222", HasMobileApp: false);
var maria = new Contact("Maria", "maria@mail.com", null, HasMobileApp: false);
var petar = new Contact("Petar", null, null, HasMobileApp: false);

notifier.Notify(ana, "Your order #42 was shipped.");
notifier.Notify(ivan, "Your order #43 was shipped.");
notifier.Notify(maria, "Your order #44 was shipped.");
bool ok = notifier.Notify(petar, "Your order #45 was shipped.");
Console.WriteLine($"Petar notified: {ok}");

notifier.Notify(ivan, new string('x', 200));