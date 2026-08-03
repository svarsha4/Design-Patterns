namespace PizzaPalace.Nutrition;

/*

    Assume the "RealNutritionService" class serves as an external API service

*/

public interface INutritionService
{
    string GetNutritionInfo(string pizzaName);
}

public class RealNutritionService : INutritionService
{
    public string GetNutritionInfo(string pizzaName)
    {
        Console.WriteLine($"[Real Service] Running expensive nutrition lookup for {pizzaName}...");
        Thread.Sleep(1000);
        return $"{pizzaName}: 800 calories, 32g protein, 90g carbs";
    }
}