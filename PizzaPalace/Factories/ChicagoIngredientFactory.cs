using PizzaPalace.Ingredients;

namespace PizzaPalace.Factories;

/*
    Refers to the concrete class that extends the "IPizzaIngredientFactory" interface. This class is responsible for creating the specific family of ingredient types
    that form the basis of pizza in the Chicago locations.

*/

public class ChicagoIngredientFactory : IPizzaIngredientFactory
{
    public IDough CreateDough() => new DeepDishDough();
    public ISauce CreateSauce() => new ChunkyTomatoSauce();
    public ICheese CreateCheese() => new BlockMozzarella();
}