using PizzaPalace.Decorators;

namespace PizzaPalace.Models;

/*

    The "ComboMeal" class forms the Composite Pattern. A group of "IOrderItem" objects can essentially be treated as a large single "IOrderItem" object.
    The one large single "IOrderItem" object (i.e. "ComboMeal") can be thought of as forming a hierarchy, where the "ComboMeal" acts like a root node,
    and the smaller "IOrderItem" objects (i.e. "Pizza", "Side", and "Drink") act like leaf nodes.

    This ensures that there is no violation of the following SOLID principles:
    1) Single Responsibility Principle: The "ComboMeal" class has a distinct responsibility of being a composite of multiple "IOrderItem" objects, without
    being responsible for the way the individual "IOrderItem" objects behave
    2) Open/Closed Principle: The "IOrderItem" interface can including new order items without being modified
    3) Liskov Substitution Principle: Because a "ComboMeal" is essentially an "IOrderItem", it means a combo meal can also be within a larger combo meal without breaking
    the interface's functionality

*/

public class ComboMeal : IOrderItem
{
    private readonly string _comboName;
    private readonly List<IOrderItem> _items = new();

    public ComboMeal(string comboName)
    {
        _comboName = comboName;
    }

    public void AddItem(IOrderItem item)
    {
        _items.Add(item);
    }

    public string GetDescription()
    {
        var itemDescriptions = _items.Select(i => i.GetDescription());
        return $"{_comboName} [{string.Join(" + ", itemDescriptions)}]";
    }

    public decimal GetPrice()
    {
        return _items.Sum(i => i.GetPrice());
    }
}