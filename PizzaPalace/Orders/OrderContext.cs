namespace PizzaPalace.Orders;

/*

    The "OrderContext" class forms the State Pattern. It allows that object to take on different states (e.g. Placed, Preparing, Ready, Delivered)
    as the customer's order progresses through the restaurant's order fulfillment process. The behaviors of those different states are encapsulated in the "IOrderState" interface,
    and they are able to be applied to this class without having to refer to the internal implementations defining the behaviors of those states.

    This ensures that there is no violation of the following SOLID principles:
    1) Open-Closed Principle: If a new state gets added to the order process, it can be implemented as a new class that implements the "IOrderState" interface
    2) Dependency Inversion Principle: The order's state DOES NOT depend on the concrete implementations of the states, but rather on the abstraction defined by the "IOrderState" interface.
    3) Single Responsibility Principle: The "OrderContext" class is only responsible for managing the order's particular state one at a time, 
    and it does not have to concern itself with the internal implementations of those states.

*/

public class OrderContext
{
    private IOrderState _currentState = new PlacedState();

    public void SetState(IOrderState newState)
    {
        _currentState = newState;
        Console.WriteLine($"Order status changed to: {_currentState.GetStatusName()}");
    }

    public void AdvanceOrder()
    {
        _currentState.Next(this);
    }

    public string GetCurrentStatus() => _currentState.GetStatusName();
}