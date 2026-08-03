namespace PizzaPalace.Interpreter;

using PizzaPalace.Factories;
using PizzaPalace.Models;

/*

    The "OrderInterpreter" class forms the Interpreter Pattern. It interprets a string representation 
    of an order and converts it into a list of Pizza objects using the provided "PizzaFactory" abstract class.

    This ensures that there is no violation of the following SOLID principles:
    1) Single Responsibility Principle: The "OrderInterpreter" class has a distinct, singular responsibility of interpreting order strings

*/

public static class OrderInterpreter
{
    public static List<Pizza> Interpret(string orderText, PizzaFactory factory)
    {
        var pizzas = new List<Pizza>();
        var entries = orderText.Split(',');

        foreach (var entry in entries)
        {
            var trimmedEntry = entry.Trim();
            var parts = trimmedEntry.Split('x');

            if (parts.Length != 2 || !int.TryParse(parts[0], out int quantity))
            {
                Console.WriteLine($"Skipping unrecognized entry: '{trimmedEntry}'");
                continue;
            }

            string pizzaType = parts[1];

            for (int i = 0; i < quantity; i++)
            {
                pizzas.Add(factory.OrderPizza(pizzaType));
            }
        }

        return pizzas;
    }
}