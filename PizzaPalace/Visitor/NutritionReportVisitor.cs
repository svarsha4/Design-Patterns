namespace PizzaPalace.Visitors;

using PizzaPalace.Models;

public class NutritionReportVisitor : IVisitor
{
    public void Visit(Pizza pizza) => Console.WriteLine($"{pizza.Name}: ~800 calories");
    public void Visit(Drink drink) => Console.WriteLine($"{drink.GetDescription()}: ~150 calories");
    public void Visit(Side side) => Console.WriteLine($"{side.GetDescription()}: ~250 calories");
}