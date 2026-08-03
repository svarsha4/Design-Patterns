namespace PizzaPalace.Toppings;

/*

    The "ToppingFactory" class forms the Flyweight Pattern. Instead of a new object being created to represent every possible topping
    that can get added on a pizza, the "ToppingFactory" class ensures that ONLY one object gets created for each UNIQUE topping. 

    This ensures that there is no violation of the following SOLID principles:
    1) Open Closed Principle: If a new type of topping gets added to the restaurant menu, it's info can simply be retrieved from the "ToppingInfo" method
    without having to modify the class itself

*/

public static class ToppingFactory
{
    private static readonly Dictionary<string, ToppingInfo> _toppings = new();

    public static ToppingInfo GetTopping(string name, int calories)
    {
        if (!_toppings.ContainsKey(name))
        {
            Console.WriteLine($"[Flyweight] Creating NEW ToppingInfo for '{name}' (first time seen).");
            _toppings[name] = new ToppingInfo(name, calories);
        }
        else
        {
            Console.WriteLine($"[Flyweight] Reusing EXISTING ToppingInfo for '{name}'.");
        }

        return _toppings[name];
    }
}