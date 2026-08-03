namespace PizzaPalace.Ingredients;

/*

    Refers to the specific family of ingredient types (i.e. they extend the interfaces of the ingredient family types) that are the basis of pizza in the Chicago locations.

*/

public class DeepDishDough : IDough
{
    public string Describe() => "Deep Dish Dough";
}

public class ChunkyTomatoSauce : ISauce
{
    public string Describe() => "Chunky Tomato Sauce";
}

public class BlockMozzarella : ICheese
{
    public string Describe() => "Block Mozzarella";
}