using PizzaPalace.Ingredients;

namespace PizzaPalace.Factories;

/*
    Refers to the concrete class that extends the "IPizzaIngredientFactory" interface. This class is responsible for creating the specific family of ingredient types
    that form the basis of pizza in the New York locations.

*/

public class NYIngredientFactory : IPizzaIngredientFactory
{
    public IDough CreateDough() => new ThinCrustDough();
    public ISauce CreateSauce() => new PlumTomatoSauce();
    public ICheese CreateCheese() => new ShreddedMozzarella();
}