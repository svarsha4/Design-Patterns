using System.Collections;
using PizzaPalace.Decorators;

namespace PizzaPalace.Menu;

/*

    The "Menu" class forms the Iterator Pattern. It allows for the iteration of a collection of "IOrderItem" objects, which can be a combination of "Pizza", "Side", and "Drink" objects.
    The "Menu" class implements the IEnumerable interface, which allows the ability to iterate through the collection of "IOrderItem" objects.
    When iterating through the objects, none of their internal implementation and behavior needs to be known

    This ensures that there is no violation of the following SOLID principles:
    1) Single Responsibility Principle: The "Menu" class has a distinct responsibility of being a collection of multiple "IOrderItem" objects, without
    being responsible for the way the individual "IOrderItem" objects behave
    2) Interface Segregation Principle: The "Menu" class implements the IEnumerable interface, which allows for the iteration of a collection of "IOrderItem" objects without requiring any additional methods to be implemented

*/



public class Menu : IEnumerable<IOrderItem>
{
    private readonly List<IOrderItem> _items = new();

    public void AddItem(IOrderItem item)
    {
        _items.Add(item);
    }

    public IEnumerator<IOrderItem> GetEnumerator()
    {
        foreach (var item in _items)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}