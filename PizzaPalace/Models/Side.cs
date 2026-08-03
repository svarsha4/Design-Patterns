using PizzaPalace.Decorators;
using PizzaPalace.Visitors;

namespace PizzaPalace.Models;

public class Side : IOrderItem
{
    private readonly string _name;
    private readonly decimal _price;

    public Side(string name, decimal price)
    {
        _name = name;
        _price = price;
    }

    public string GetDescription() => _name;
    public decimal GetPrice() => _price;


    public virtual void Accept(IVisitor visitor) => visitor.Visit(this);
}