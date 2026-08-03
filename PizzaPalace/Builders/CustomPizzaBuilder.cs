using PizzaPalace.Models;

namespace PizzaPalace.Builders;

/*

    The creation of the "CustomPizzaBuilder" class forms the Builder Pattern.
    The process of creating a customized pizza is pretty complex, as it involves going through a series of steps 
    (i.e. setting the size, crust, toppings, and price).

    Instead of having one large constructor with lots of parameters (like the example shown below), the "CustomPizzaBuilder" class
    will have a method representing each step in the process of creating a customized pizza. 
    
    var pizza = new CustomPizza("Large", "Stuffed Crust", new List<string> {"Cheese", "Mushrooms", "Bacon"}, 14.99m);
    
    Thus, the user won't need to have all these parameters 
    in order to create a customized pizza, as they can just call the methods in the "CustomPizzaBuilder" class to set their desired parameters (like the example shown below).

    var pizza = new CustomPizzaBuilder();
    pizza.AddTopping("Mushrooms");

    This ensures that there is no violation of the following SOLID principles:
    1) Single Responsibility Principle: The ONLY objective of the "CustomPizzaBuilder" class is to create a customized pizza.
    2) Open/Closed Principle: The "CustomPizzaBuilder" class can be extended with new methods for additional customization options without modifying its existing code.
    For example, if creating a customized pizza now involves deciding on which cheese to have, a new method for setting the cheese can simply be added to the "CustomPizzaBuilder" class 
    without modifying any of the existing methods.

*/

public class CustomPizzaBuilder
{
    private readonly CustomPizza _pizza = new();

    public CustomPizzaBuilder SetSize(string size)
    {
        _pizza.Size = size;
        return this;
    }

    public CustomPizzaBuilder SetCrust(string crust)
    {
        _pizza.Crust = crust;
        return this;
    }

    public CustomPizzaBuilder AddTopping(string topping)
    {
        _pizza.Toppings.Add(topping);
        return this;
    }

    public CustomPizzaBuilder SetPrice(decimal price)
    {
        _pizza.Price = price;
        return this;
    }

    public CustomPizza Build()
    {
        _pizza.Name = "Custom";
        return _pizza;
    }
}