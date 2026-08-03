namespace PizzaPalace.Decorators;

/*
    The "ToppingDecorator" class forms the Decorator Pattern, as it allows the ability to add new functionality (e.g. bing able to add new toppings to a pizza) to existing order items (e.g. pizzas)
    without modifying any of the conrete pizza classes (e.g. MargheritaPizza, PepperoniPizza, etc.). This class implements the "IOrderItem" interface, 
    which defines the information corresponding to an order item in the Pizza Palace.
    
    This ensures that there is no violation of the following SOLID principles:
    1) Open-Closed Principle: The "ToppingDecorator" class allows the ability to add new functionality (e.g. being able to add new toppings to a pizza) to existing order items (e.g. pizzas),
    without needing to modify any of the conrete pizza classes (e.g. MargheritaPizza, PepperoniPizza, etc.).
    2) Liskov Substitution Principle: The "ToppingDecorator" class can be used in place of any other class implementing the "IOrderItem" interface, as it adheres to the same implementation defined by the interface.
    
*/

public class ToppingDecorator : IOrderItem
{
    private readonly IOrderItem _wrappedItem;
    private readonly string _toppingName;
    private readonly decimal _toppingCost;

    public ToppingDecorator(IOrderItem wrappedItem, string toppingName, decimal toppingCost)
    {
        _wrappedItem = wrappedItem;
        _toppingName = toppingName;
        _toppingCost = toppingCost;
    }

    public string GetDescription() => $"{_wrappedItem.GetDescription()} + {_toppingName}";

    public decimal GetPrice() => _wrappedItem.GetPrice() + _toppingCost;
}