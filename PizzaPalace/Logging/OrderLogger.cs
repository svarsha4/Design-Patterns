namespace PizzaPalace.Logging;

/*

    The "OrderLogger" class implements the Singleton Pattern by ensuring that there is ONLY one instance of the class needed to be created to be used across the entire application. 
    This is achieved by having a private constructor, which prevents any code outside the class from creating a new instance of the class. Instead, the single shared instance of the class is exposed through a public static property called "Instance".
    This is important because the "OrderLogger" class is responsible for logging all the orders placed at the Pizza Palace, and having multiple instances of the class could lead to inconsistencies in the order logs.

    This ensures that there is no violation of the following SOLID principles:
    1) Single Responsibility Principle (SRP): OrderLogger's ONLY job is recording log messages. It doesn't know about pizzas, orders, or pricing.

*/

public class OrderLogger
{
    private static readonly OrderLogger _instance = new();

    public static OrderLogger Instance => _instance;

    private readonly List<string> _logs = new();

    private OrderLogger() { }

    public void Log(string message)
    {
        var entry = $"[{DateTime.Now:HH:mm:ss}] {message}";
        _logs.Add(entry);
        Console.WriteLine(entry);
    }

    public void PrintAllLogs()
    {
        Console.WriteLine("\n--- Order Log History ---");
        foreach (var entry in _logs)
        {
            Console.WriteLine(entry);
        }
    }
}