using PizzaPalace.Models;

namespace PizzaPalace.Factories;

/*

    The creation of the "PizzaFactory" class forms the Factory Method Pattern. 
    The "CreatePizza(string type)" method specifies the pizza creation process. Even though this method is defined in the "PizzaFactory" abstract class,
    the actual method gets implemented in the subclasses (e.g. NYPizzaFactory, ChicagoPizzaFactory, etc.).

    This ensures that there is no violation of the following SOLID principles:
    1) Open-Closed Principle: Whenever a new pizza factory opens up, the "PizzaFactory" class DOES NOT need to be modified since it's an abstract class.
    Instead, a new subclass representing the new pizza factory gets created and references the "PizzaFactory" abstract class.
    2) Liskov Substitution Principle: Any subclass of the "PizzaFactory" abstract class can serve as its replacement, while ensuring the subclass can perform the same
    functionality as the "CreatePizza(string type)" method from the abstract class.
    3) Dependency Inversion Principle: The "PizzaFactory" abstract class ensures that ensuring a successful customer order DOES NOT directly depend on the creation of pizzas from the
    concrete subclasses. In order to retain customers, ensuring standaridzed, effective orders across all locations is very important for the business (i.e. high level module); the orders shouldn't slow
    down because of the intricacies involved with creating the pizza corresponding to the customer's order.

*/

public abstract class PizzaFactory
{
    protected abstract Pizza CreatePizza(string type);

    public Pizza OrderPizza(string type)
    {
        Pizza pizza = CreatePizza(type);
        Console.WriteLine($"--- Preparing {pizza.Name} ---");
        pizza.Describe();
        return pizza;
    }
}

public class NYPizzaFactory : PizzaFactory
{
    protected override Pizza CreatePizza(string type)
    {
        return type.ToLower() switch
        {
            "margherita" => new MargheritaPizza(),
            "pepperoni" => new PepperoniPizza(),
            "veggie" => new VeggiePizza(),
            _ => throw new ArgumentException($"Unknown pizza type: {type}")
        };
    }
}

public class ChicagoPizzaFactory : PizzaFactory
{
    protected override Pizza CreatePizza(string type)
    {
        return type.ToLower() switch
        {
            "margherita" => new MargheritaPizza(),
            "pepperoni" => new PepperoniPizza(),
            "veggie" => new VeggiePizza(),
            _ => throw new ArgumentException($"Unknown pizza type: {type}")
        };
    }
}
    
    
    
    