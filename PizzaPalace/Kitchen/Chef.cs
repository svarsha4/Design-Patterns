namespace PizzaPalace.Kitchen;

public class Chef
{
    private readonly IKitchenMediator _mediator;

    public Chef(IKitchenMediator mediator)
    {
        _mediator = mediator;
    }

    public void FinishCooking(string pizzaName)
    {
        Console.WriteLine($"[Chef] Finished cooking {pizzaName}.");
        _mediator.NotifyPizzaReady(pizzaName);
    }
}