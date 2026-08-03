using PizzaPalace.Ingredients;

namespace PizzaPalace.Factories;

/*

    The creation of the "IPizzaIngredientFactory" interface forms the Abstract Factory Pattern.
    The variables defined in the interface represent the family of ingredient types defined in IIngredients.cs. When the concrete classes extending the
    "IPizzaIngredientFactory" interface get called (e.g. NYIngredientFactory, ChicagoIngredientFactory, etc.), it means that 
    the specific family of ingredient types (e.g. those from NYIngredients, ChicagoIngredients, etc.) will be created 
    to form the basis of the pizza in the given locations (e.g. New York, Chicago, etc.).
    Because they are created through the factory interface, it means the objects representing the specific family of ingredients are effectively encapsulated.

    This ensures that there is no violation of the following SOLID principles:
    1) Single Responsibility Principle: The ONLY objective of the "IPizzaIngredientFactory" interface is to create the specific family of ingredient types
    that form the basis of pizza in the given locations (e.g. New York, Chicago, etc.).
    2) Open-Closed Principle: Whenever a new location is being opened up, the "IPizzaIngredientFactory" interface DOES NOT need to be modified. 
    Instead, a new concrete class representing the new location gets created and extends the "IPizzaIngredientFactory" interface.
    3) Dependency Inversion Principle: The ingredient family types DO NOT depend on the locations where the pizza is ordered, as the interface prevents that dependency as
    it can't be modified. 


*/

public interface IPizzaIngredientFactory
{
    IDough CreateDough();
    ISauce CreateSauce();
    ICheese CreateCheese();
}