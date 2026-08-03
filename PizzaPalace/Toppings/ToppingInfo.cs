namespace PizzaPalace.Toppings;

/*

    The "ToppingInfo" class holds the information corresponding to any topping that gets added to a pizza.

*/

public class ToppingInfo
{
    public string Name { get; }
    public int Calories { get; }

    public ToppingInfo(string name, int calories)
    {
        Name = name;
        Calories = calories;
    }
}