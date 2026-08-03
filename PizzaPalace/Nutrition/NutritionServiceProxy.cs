namespace PizzaPalace.Nutrition;

/*

    The "NutritionServiceProxy" class forms the Proxy Pattern. This class controls access to the "RealNutritionService" class, which is assumed to represent an
    external API service. The "NutritionServiceProxy" class caches the results of the "RealNutritionService" class, so that if the same pizza name is requested again,
    the cached result is returned instead of making an unecessary, extra call to the "RealNutritionService".

    This ensures that there is no violation of the following SOLID principles:
    1) Single Responsibility Principle: The "NutritionServiceProxy" class has a single responsibility of controlling access to the "RealNutritionService" class

*/

public class NutritionServiceProxy : INutritionService
{
    private readonly RealNutritionService _realService = new();
    private readonly Dictionary<string, string> _cache = new();

    public string GetNutritionInfo(string pizzaName)
    {
        if (_cache.ContainsKey(pizzaName))
        {
            Console.WriteLine($"[Proxy] Returning CACHED result for {pizzaName}.");
            return _cache[pizzaName];
        }

        string result = _realService.GetNutritionInfo(pizzaName);
        _cache[pizzaName] = result;
        return result;
    }
}