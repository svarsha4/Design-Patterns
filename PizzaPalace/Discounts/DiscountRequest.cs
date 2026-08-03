namespace PizzaPalace.Discounts;

public class DiscountRequest
{
    public decimal OrderAmount { get; }
    public decimal RequestedDiscountPercent { get; }

    public DiscountRequest(decimal orderAmount, decimal requestedDiscountPercent)
    {
        OrderAmount = orderAmount;
        RequestedDiscountPercent = requestedDiscountPercent;
    }
}