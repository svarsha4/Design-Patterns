namespace PizzaPalace.Orders;





public interface IOrderState
{
    void Next(OrderContext context);
    string GetStatusName();
}

public class PlacedState : IOrderState
{
    public void Next(OrderContext context) => context.SetState(new PreparingState());
    public string GetStatusName() => "Placed";
}

public class PreparingState : IOrderState
{
    public void Next(OrderContext context) => context.SetState(new ReadyState());
    public string GetStatusName() => "Preparing";
}

public class ReadyState : IOrderState
{
    public void Next(OrderContext context) => context.SetState(new DeliveredState());
    public string GetStatusName() => "Ready";
}

public class DeliveredState : IOrderState
{
    public void Next(OrderContext context) => Console.WriteLine("Order already delivered.");
    public string GetStatusName() => "Delivered";
}