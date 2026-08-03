namespace PizzaPalace.Payments;

/*

    Let's assume that the "LegacyPaymentGateway" class comes from a third-party package implemented using the "MakePayment" method that cannot be modified

*/

public class LegacyPaymentGateway
{
    public void MakePayment(int amountInCents)
    {
        Console.WriteLine($"[Legacy Gateway] Charged {amountInCents} cents.");
    }
}