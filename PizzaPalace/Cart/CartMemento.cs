namespace PizzaPalace.Cart;

/*

    The "CartMemento" class forms the Memento Pattern.
    The "CreateSnapshot" method in the "Cart" class creates a "CartMemento" object that stores the current state of the cart's items.
    Meanwhile, the "RestoreSnapshot" method in the "Cart" class restores the cart's items to a previous state also using a "CartMemento" object.
    In essence, the goal of the "CartMemento" class is to provide a way to save and restore the state of a "Cart" object while ensuring the "Cart"
    object is encapsulated

    This ensures that there is no violation of the following SOLID principles:
    1) Single Responsibility Principle: The "CartMemento" class has a distinct, singular responsibility of storing the state of the cart's items

*/

public class CartMemento
{
    internal List<string> SavedItems { get; }

    internal CartMemento(List<string> items)
    {
        SavedItems = new List<string>(items);
    }
}