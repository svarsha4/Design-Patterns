using PizzaPalace.Payments;

namespace PizzaPalace.Checkout;

/*

    The "Checkout" class forms the Strategy Pattern. It allows the customer to choose their desired payment method (e.g. credit card, cash, or digital wallet)
    at the time of purchase. The behaviors of those different payment methods are encapsulated in the "IPaymentStrategy" interface,
    and they are able to be applied to this class without having to refer to the internal implementations defining the behaviors of those payment methods.

    This ensures that there is no violation of the following SOLID principles:
    1) Open-Closed Principle: If a new payment method gets added to the restaurant, it can be implemented as a new class that implements the "IPaymentStrategy" interface
    2) Dependency Inversion Principle: The customer's payment DOES NOT depend on the concrete implementations of the payment methods, but rather on the abstraction defined by the "IPaymentStrategy" interface.

*/

public class Checkout
{
    private IPaymentStrategy _paymentStrategy;

    public Checkout(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void CompletePurchase(decimal amount)
    {
        _paymentStrategy.Pay(amount);
    }
}