using PizzaPalace.Decorators;
using PizzaPalace.Factories;
using PizzaPalace.Logging;
using PizzaPalace.Models;

namespace PizzaPalace.Facades;

/*
    
    The "PlaceOrder" method in the "OrderFacade" class forms the Facade Pattern, as it is used to hide 
    the complexity of the logistics needed to be coordinated to successfully make an order. This allows the PizzaFactory, ToppingDecorators, and OrderLogger to be 
    encapsulated, as the user does not need to know about the intricacies of these objects, as they are utilized as needed in the "PlaceOrder" method.
    
    This ensures that there is no violation of the following SOLID principles:
    1) Single Responsibility Principle (SRP): OrderFacade's ONLY job is orchestrating a full order from start to finish. It doesn't contain anything pertaining to making
    a pizza, adding toppings, etc., as it's all taken care of by the objects themselves (e.g. PizzaFactory, ToppingDecorator, etc.).
    2) Dependency Inversion Principle (DIP): Making an order (i.e. which is how the business generates money) depends solely on the one "PlaceOrder()" method, which
    gets returned as an interface to the calling code (e.g. Program.cs), ensuring the foundation of the business (i.e. generating profit through orders) 
    is not dependent on the implementation details of the objects that make up the order (e.g. PizzaFactory, ToppingDecorator, etc.).
    
*/
public class OrderFacade
{
    private readonly PizzaFactory _factory;

    public OrderFacade(PizzaFactory factory)
    {
        _factory = factory;
    }

    public IOrderItem PlaceOrder(string pizzaType, List<(string name, decimal cost)> extraToppings)
    {
        Pizza pizza = _factory.OrderPizza(pizzaType);

        IOrderItem order = pizza;
        foreach (var (name, cost) in extraToppings)
        {
            order = new ToppingDecorator(order, name, cost);
        }

        OrderLogger.Instance.Log($"Order placed: {order.GetDescription()} - ${order.GetPrice()}");
        return order;
    }
}