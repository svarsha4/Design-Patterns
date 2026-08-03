namespace PizzaPalace.Cart;

public class Cart
{
    public List<string> Items { get; } = new();

    public void AddItem(string item)
    {
        Items.Add(item);
        Console.WriteLine($"Added to cart: {item}");
    }

    public void RemoveItem(string item)
    {
        Items.Remove(item);
        Console.WriteLine($"Removed from cart: {item}");
    }

    public void PrintCart()
    {
        Console.WriteLine($"Cart contents: {string.Join(", ", Items)}");
    }

    public CartMemento CreateSnapshot()
    {
        Console.WriteLine("Snapshot saved.");
        return new CartMemento(Items);
    }

    public void RestoreSnapshot(CartMemento memento)
    {
        Items.Clear();
        Items.AddRange(memento.SavedItems);
        Console.WriteLine("Cart restored to snapshot.");
    }
}