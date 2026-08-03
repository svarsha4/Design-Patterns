namespace PizzaPalace.Kitchen;

/*

    The "IKitchenMediator" interface forms the Mediator Pattern. It defines the methods 
    that will be used to essentially facilitate the interaction between different components of the kitchen (e.g. "OrderStation" and "Chef" objects)
    without the objects needing to directly reference each other.

    This ensures that there is no violation of the following SOLID principles:
    1) Single Responsibility Principle: The "IKitchenMediator" interface has a distinct, singular responsibility of facilitating interaction between kitchen components

*/

public interface IKitchenMediator
{
    void NotifyOrderPlaced(string pizzaName);
    void NotifyPizzaReady(string pizzaName);
}

public class KitchenMediator : IKitchenMediator
{
    public void NotifyOrderPlaced(string pizzaName)
    {
        Console.WriteLine($"[Mediator] Notifying Chef: new order for {pizzaName}.");
    }

    public void NotifyPizzaReady(string pizzaName)
    {
        Console.WriteLine($"[Mediator] Notifying Delivery Driver: {pizzaName} is ready for pickup.");
    }
}