namespace PizzaPalace.Commands;

using PizzaPalace.Cart;

/*

    The "ICommand" interface forms the Command Pattern. Two conrete classes extend this interface, which specify the actions for adding and removing an
    item that a customer's wants to purhcase. The "Cart" class is encapsulated within the classes, as it DOES NOT need to be known in order to add
    or remove items to the cart.

    This ensures that there is no violation of the following SOLID principles:
    1) Single Responsibility Principle: Each of the conrete classes have distinct, singular responsibilities (i.e. class for adding and another class for removing)
    2) Open/Closed Principle: If a new class, such as exchanging an item, were to be added, it would simply extend the "ICommand" interface

*/

public interface ICommand
{
    void Execute();
    void Undo();
}

public class AddItemCommand : ICommand
{
    private readonly Cart _cart;
    private readonly string _item;

    public AddItemCommand(Cart cart, string item)
    {
        _cart = cart;
        _item = item;
    }

    public void Execute() => _cart.AddItem(_item);
    public void Undo() => _cart.RemoveItem(_item);
}

public class RemoveItemCommand : ICommand
{
    private readonly Cart _cart;
    private readonly string _item;

    public RemoveItemCommand(Cart cart, string item)
    {
        _cart = cart;
        _item = item;
    }

    public void Execute() => _cart.RemoveItem(_item);
    public void Undo() => _cart.AddItem(_item);
}