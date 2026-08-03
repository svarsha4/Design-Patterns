namespace PizzaPalace.Notifications;


/* 

    Together, the "OrderNotifier" and the "INotificationSender" interface form the Bridge Pattern. They both form separate hierarchies with different
    responsibilities, yet it's important for them to be interconnected together.
    Without these hierarchies being interconnected, it becomes very challenging if not impossible to know which exact customer should be notified about their order.

    This ensures that there is no violation of the following SOLID principles:
    1) Single Responsibility Principle: Each of those heirarchies have distinct responsibilities
    2) Dependency Inversion Principle: The "OrderNotifier" class depends on the abstraction of the "INotificationSender" interface, rather than concrete implementations of it

*/

public class OrderNotifier
{
    private readonly INotificationSender _sender;

    public OrderNotifier(INotificationSender sender)
    {
        _sender = sender;
    }

    public void NotifyOrderPlaced(string pizzaName)
    {
        _sender.Send($"Your order for {pizzaName} has been placed!");
    }

    public void NotifyOrderReady(string pizzaName)
    {
        _sender.Send($"Your {pizzaName} is ready for pickup!");
    }
}