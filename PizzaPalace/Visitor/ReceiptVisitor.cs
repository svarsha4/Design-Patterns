namespace PizzaPalace.Visitors;

using PizzaPalace.Models;

public class ReceiptVisitor : IVisitor
{
    public void Visit(Pizza pizza) => Console.WriteLine($"{pizza.Name} .......... ${pizza.Price}");
    public void Visit(Drink drink) => Console.WriteLine($"{drink.GetDescription()} .......... ${drink.GetPrice()}");
    public void Visit(Side side) => Console.WriteLine($"{side.GetDescription()} .......... ${side.GetPrice()}");
}