namespace PizzaPalace.Payments;

/*

    The customer can choose to pay for their order using a credit card, cash, or a digital wallet. 
    The different payment methods are implemented as separate classes that implement the "IPaymentStrategy" interface.

*/

public interface IPaymentStrategy
{
    void Pay(decimal amount);
}

public class CreditCardStrategy : IPaymentStrategy
{
    public void Pay(decimal amount) => Console.WriteLine($"[Credit Card] Charged ${amount}.");
}

public class CashStrategy : IPaymentStrategy
{
    public void Pay(decimal amount) => Console.WriteLine($"[Cash] Received ${amount}.");
}

public class WalletStrategy : IPaymentStrategy
{
    public void Pay(decimal amount) => Console.WriteLine($"[Digital Wallet] Deducted ${amount}.");
}