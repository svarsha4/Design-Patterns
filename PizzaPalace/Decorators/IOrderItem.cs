namespace PizzaPalace.Decorators;

/*

    The "IOrderItem" interface defines the information corresponding to an order item in the Pizza Palace.
    This interface is implemented by the "Pizza" abstract class, which serves as the base class for all the types of pizzas sold at the Pizza Palace (e.g. MargheritaPizza, PepperoniPizza, etc.).
    
*/

public interface IOrderItem
{
    string GetDescription();
    decimal GetPrice();
}