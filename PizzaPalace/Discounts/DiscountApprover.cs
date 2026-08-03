namespace PizzaPalace.Discounts;

/*

    The "DiscountApprover" abstract class forms the Chain of Responsibility Pattern. 
    The "ProcessRequest" method essentially defines how exactly the request will be fulfilled given the role of the person taked with approving the request.
    The "SetNext" method allows for the creation of a chain of approvers, where each approver 
    can either approve the request or pass it along to the next approver in the chain.

    This ensures that there is no violation of the following SOLID principles:
    1) Single Responsibility Principle: The "DiscountApprover" class has a distinct, singular responsibility of processing discount requests
    2) Open/Closed Principle: New approvers can be easily be added as subclasses

*/

public abstract class DiscountApprover
{
    protected DiscountApprover? NextApprover;

    public void SetNext(DiscountApprover next)
    {
        NextApprover = next;
    }

    public abstract void ProcessRequest(DiscountRequest request);
}

public class Cashier : DiscountApprover
{
    private const decimal MaxApprovalPercent = 5m;

    public override void ProcessRequest(DiscountRequest request)
    {
        if (request.RequestedDiscountPercent <= MaxApprovalPercent)
        {
            Console.WriteLine($"[Cashier] Approved {request.RequestedDiscountPercent}% discount.");
        }
        else if (NextApprover != null)
        {
            Console.WriteLine("[Cashier] Discount too high for me — passing to Manager.");
            NextApprover.ProcessRequest(request);
        }
    }
}

public class Manager : DiscountApprover
{
    private const decimal MaxApprovalPercent = 15m;

    public override void ProcessRequest(DiscountRequest request)
    {
        if (request.RequestedDiscountPercent <= MaxApprovalPercent)
        {
            Console.WriteLine($"[Manager] Approved {request.RequestedDiscountPercent}% discount.");
        }
        else if (NextApprover != null)
        {
            Console.WriteLine("[Manager] Discount too high for me — passing to Owner.");
            NextApprover.ProcessRequest(request);
        }
    }
}

public class Owner : DiscountApprover
{
    public override void ProcessRequest(DiscountRequest request)
    {
        // Owner is the end of the chain — approves anything.
        Console.WriteLine($"[Owner] Approved {request.RequestedDiscountPercent}% discount.");
    }
}