namespace PizzaPalace.Kitchen;

public class OrderStation
{
    private readonly IKitchenMediator _mediator;

    public OrderStation(IKitchenMediator mediator)
    {
        _mediator = mediator;
    }

    public void PlaceOrder(string pizzaName)
    {
        Console.WriteLine($"[OrderStation] Order received: {pizzaName}.");
        _mediator.NotifyOrderPlaced(pizzaName);
    }
}