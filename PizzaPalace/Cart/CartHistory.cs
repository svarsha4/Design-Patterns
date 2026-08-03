namespace PizzaPalace.Cart;

/*

    The "CartHistory" class also forms the Memento Pattern. It is responsible for managing the history of cart states, allowing the user to save and restore previous states of the cart.
    Whereas the "CartMemento" class is focused on storing the state of a single cart, the "CartHistory" class maintains a stack of "CartMemento" objects, enabling multiple states to be saved and restored.

    This ensures that there is no violation of the following SOLID principles:
    1) Single Responsibility Principle: The "CartHistory" class has a distinct, singular responsibility of managing the history of cart states

*/

public class CartHistory
{
    private readonly Stack<CartMemento> _states = new();

    public void Save(CartMemento memento) => _states.Push(memento);

    public CartMemento? Restore()
    {
        return _states.Count > 0 ? _states.Pop() : null;
    }
}