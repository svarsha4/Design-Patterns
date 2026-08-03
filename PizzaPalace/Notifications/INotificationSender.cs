namespace PizzaPalace.Notifications;

/*

    The concrete classes below extend the "INotificationSender" interface, which defines the process for reaching out to customers

*/

public interface INotificationSender
{
    void Send(string message);
}

public class EmailSender : INotificationSender
{
    public void Send(string message) => Console.WriteLine($"[Email] {message}");
}

public class SmsSender : INotificationSender
{
    public void Send(string message) => Console.WriteLine($"[SMS] {message}");
}