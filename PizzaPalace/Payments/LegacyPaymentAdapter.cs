namespace PizzaPalace.Payments;

/*

    The "LegacyPaymentAdapter" class forms the Adapter Pattern.
    In order for the the "LegacyPaymentGateway" class to be legitimately used, the imaginary third-party package that it contains gets used 
    in the "ProcessPayment" method, whose implementation gets defined in the "IPaymentProcessor" interface.

    This ensures that there is no violation of the following SOLID principles:
    1) Interface Segregation Principle: In order for the third-party package to be used to legitimately process payments, it must be defined in any of the methods 
    defined in the "IPaymentProcessor" interface.

*/

public class LegacyPaymentAdapter : IPaymentProcessor
{
    private readonly LegacyPaymentGateway _legacyGateway;

    public LegacyPaymentAdapter(LegacyPaymentGateway legacyGateway)
    {
        _legacyGateway = legacyGateway;
    }

    public void ProcessPayment(decimal amount)
    {
        int amountInCents = (int)(amount * 100);
        _legacyGateway.MakePayment(amountInCents);
    }
}