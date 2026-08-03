using PizzaPalace.Factories;

namespace PizzaPalace.Models;

/*
    The "RegionalPizza" class is a concrete implementation of the "Pizza" abstract class, which is part of the Template Method Pattern.
    It represents a specific type of pizza that is prepared using a regional ingredient factory, allowing for the creation of pizzas with a distinct preparation process.

*/

public class RegionalPizza : Pizza
{
    private readonly IPizzaIngredientFactory _ingredientFactory;

    public RegionalPizza(string name, List<string> toppings, decimal price, IPizzaIngredientFactory ingredientFactory)
    {
        Name = name;
        Toppings = toppings;
        Price = price;
        _ingredientFactory = ingredientFactory;
    }

    protected override void PrepareDough()
    {
        var dough = _ingredientFactory.CreateDough();
        Console.WriteLine($"Preparing {dough.Describe()}.");
    }

    protected override void AddSauce()
    {
        var sauce = _ingredientFactory.CreateSauce();
        Console.WriteLine($"Adding {sauce.Describe()}.");
    }

    protected override void AddCheese()
    {
        var cheese = _ingredientFactory.CreateCheese();
        Console.WriteLine($"Adding {cheese.Describe()}.");
    }
}