namespace PizzaPalace.Payments;

public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}