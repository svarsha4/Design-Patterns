using PizzaPalace.Decorators;
using PizzaPalace.Visitors;

namespace PizzaPalace.Models;

public class Drink : IOrderItem
{
    private readonly string _name;
    private readonly decimal _price;

    public Drink(string name, decimal price)
    {
        _name = name;
        _price = price;
    }

    public string GetDescription() => _name;
    public decimal GetPrice() => _price;


    public virtual void Accept(IVisitor visitor) => visitor.Visit(this);
}