namespace PizzaPalace.Ingredients;

/*

    Refers to the specific family of ingredient types (i.e. they extend the interfaces of the ingredient family types) that are the basis of pizza in the New York locations.

*/

public class ThinCrustDough : IDough
{
    public string Describe() => "Thin Crust Dough";
}

public class PlumTomatoSauce : ISauce
{
    public string Describe() => "Plum Tomato Sauce";
}

public class ShreddedMozzarella : ICheese
{
    public string Describe() => "Shredded Mozzarella";
}