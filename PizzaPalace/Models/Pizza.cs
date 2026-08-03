using PizzaPalace.Decorators;
using PizzaPalace.Visitors;

namespace PizzaPalace.Models;

/*
    
    The "Pizza" abstract class serves as the base class for all the types of pizzas sold at the Pizza Palace (e.g. MargheritaPizza, PepperoniPizza, etc.).
    The "Pizza" class implements the "IOrderItem" interface defined, which defines the information corresponding to an order item in the Pizza Palace.
    
    This ensures that there is no violation of the Open-Closed Principle, as the "Pizza" class DOES NOT need to be modified at all.
    Whenever a new type of pizza gets introduced at the Pizza Palance, a new subclass corresponding to the "Pizza" abstract class needs to be added to this file.

    The "CustomerPizza" class represents a special type of pizza that allows customers 
    to customize their own pizza by selecting their desired size, crust, and toppings. 
    Going back to the previous point, notice how this class does not violate the Open-Closed Principle, as it's added as a subclass of the "Pizza" abstract class
    without needing to modify the "Pizza" class itself.

    Since the "ChefSpecialPizza" class represents a special type of pizza created by the chef, it should easily be able to be cloned, in case one of the objects
    representing it gets modified.

*/

public abstract class Pizza : IOrderItem
{
    public string Name { get; set; } = string.Empty;
    public List<string> Toppings { get; set; } = new();
    public decimal Price { get; set; }

    public virtual void Describe()
    {
        Console.WriteLine($"{Name} - ${Price} - Toppings: {string.Join(", ", Toppings)}");
    }

    public virtual string GetDescription() => $"{Name} ({string.Join(", ", Toppings)})";
    public virtual decimal GetPrice() => Price;


    /*

        The "Prepare" method forms the Template Method Pattern. 
        It defines the skeleton of the pizza preparation algorithm, while allowing the subclasses (i.e. MargheritaPizza, PepperoniPizza, etc.) 
        to override specific steps of the algorithm without changing its structure.

        This ensures that there is no violation of the following SOLID principles:
        1) Open-Closed Principle: The "Prepare" method is open for extension for any subclasses of the "Pizza" class
        2) Liskov Substitution Principle: The "Prepare" method can be called in any subclass of the "Pizza" class without altering the correctness of the program

    */

    public void Prepare()
    {
        PrepareDough();
        AddSauce();
        AddCheese();
        AddToppingsStep();
        Bake();
        Cut();
        Box();
    }

    protected virtual void PrepareDough() => Console.WriteLine("Preparing generic dough.");
    protected virtual void AddSauce() => Console.WriteLine("Adding generic tomato sauce.");
    protected virtual void AddCheese() => Console.WriteLine("Adding generic mozzarella.");
    protected virtual void AddToppingsStep() => Console.WriteLine($"Adding toppings: {string.Join(", ", Toppings)}");
    protected virtual void Bake() => Console.WriteLine("Baking at 450°F for 12 minutes.");
    protected virtual void Cut() => Console.WriteLine("Cutting into slices.");
    protected virtual void Box() => Console.WriteLine("Boxing the pizza.");


    public virtual void Accept(IVisitor visitor) => visitor.Visit(this);
}

public class MargheritaPizza : Pizza
{
    public MargheritaPizza()
    {
        Name = "Margherita";
        Toppings = new List<string> {"Tomato", "Mozzarella", "Basil"};
        Price = 8.99m;
    }
}

public class PepperoniPizza : Pizza
{
    public PepperoniPizza()
    {
        Name = "Pepperoni";
        Toppings = new List<string> {"Tomato", "Mozzarella", "Pepperoni"};
        Price = 10.99m;
    }
}

public class VeggiePizza : Pizza
{
    public VeggiePizza()
    {
        Name = "Veggie";
        Toppings = new List<string> { "Tomato", "Peppers", "Onions", "Mushrooms"};
        Price = 9.99m;
    }
}

public class CustomPizza : Pizza
{
    public string Size { get; set; } = string.Empty;
    public string Crust { get; set; } = string.Empty;

    public override void Describe()
    {
        Console.WriteLine($"{Size} {Crust} Custom Pizza - ${Price} - Toppings: {string.Join(", ", Toppings)}");
    }
}

public class ChefSpecialPizza : Pizza, ICloneablePizza
{
    public ChefSpecialPizza()
    {
        Name = "Chef's Special";
        Toppings = new List<string> { "Truffle Oil", "Prosciutto", "Arugula", "Parmesan" };
        Price = 16.99m;
    }

    public Pizza Clone()
    {
        var clone = new ChefSpecialPizza
        {
            Name = this.Name,
            Price = this.Price,
            Toppings = new List<string>(this.Toppings)
        };
        return clone;
    }
}
